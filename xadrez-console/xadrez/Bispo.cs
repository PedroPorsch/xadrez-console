using System;
namespace tabuleiro;

public class Bispo : Peca
{


	public Bispo(Tabuleiro Tab, Cor cor) : base(Tab, cor)
	{
	}


    public override string ToString()
    {
        return "B";
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

        //NO

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.Linha = pos.Linha - 1;
        }


        //Ne

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.Linha = pos.Linha + 1;
        }


        //SE

        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.Coluna = pos.Coluna + 1;
        }


        //SO

        pos.DefinirValores(Posicao.Linha +1 , Posicao.Coluna - 1);

        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }

            pos.Coluna = pos.Coluna - 1;
        }

        return mat;
    }
}

