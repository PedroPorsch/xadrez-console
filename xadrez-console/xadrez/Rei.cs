using System;
using tabuleiro;
namespace xadrez
{
	public class Rei : Peca
	{
		public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
		{
		}

        private bool Podemover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.Cor != Cor;
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

            return mat;
        }


        public override string ToString()
        {
            return "R";
        }
    }
}

