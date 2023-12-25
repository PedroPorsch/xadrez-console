using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    public class PartidaDeXadrez
    {

        public Tabuleiro Tab { get; set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; set; }
        public HashSet<Peca> Pecas;
        public HashSet<Peca> Capturadas;
        public bool Xeque { get; set; }


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
            Xeque = false;
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RemovePeca(origem);
            p.IncrementarMovimentos();
            Peca pecaCapturada = Tab.RemovePeca(destino);
            Tab.AddPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }


        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Capturadas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturdada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturdada);
                throw new TabuleiroException("Não se pode colocar em xeque!"); 
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            } 
            else
            {
                Xeque = false;
            }
            if (TesteXeque(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
            
         


        }


        public bool TesteXeque (Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca peca in PecasEmJogo(cor))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                for(int i = 0; i < Tab.Linhas; i++)
                {
                    for(int j = 0; j< Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;  
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RemovePeca(destino);
            p.DecrementarMovimentos();
            if(pecaCapturada!= null)
            {
                Tab.AddPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.AddPeca(p, origem);
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possívies para a peça de origem escolhida!");

            }
        }


        private Peca Rei(Cor cor)
        {
            foreach(Peca peca in PecasEmJogo(cor)){
                if(peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if(rei == null)
            {
                throw new TabuleiroException("Não há rei no tabuleiro!");
            }
            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;

        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição destino inválida");
            }
        }

        private void MudaJogador()
        {

            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.AddPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }


        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));

            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('f', 8, new Bispo(Tab ,Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta));



            /** ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
             ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
             ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
             ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
             ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));


             ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
             ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
             ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
             ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
             ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
             ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
            **/
        }
    }
}

