using System;
using tabuleiro;
namespace xadrez
{
	public class Rei : Peca
	{

        private PartidaDeXadrez Partida;

		public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
		{
            Partida = partida;
		}

        private bool Podemover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }


        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QuantidadeMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(Posicao.Linha -1, Posicao.Coluna);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //ne
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //se
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            // so
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //no

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (tab.PoisicaoValida(pos) && Podemover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            // Jogada especial roque

            if(QuantidadeMovimentos == 0 && !Partida.Xeque)
            {
                Posicao PosT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(PosT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (tab.Peca(p1)== null && tab.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
            }


            // Jogada especial grande

            if (QuantidadeMovimentos == 0 && !Partida.Xeque)
            {
                Posicao PosT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(PosT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (tab.Peca(p1) == null && tab.Peca(p2) == null && tab.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }


        public override string ToString()
        {
            return "R";
        }
    }
}

