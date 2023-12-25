using System;
using System.Runtime.ConstrainedExecution;

namespace tabuleiro;

public class Peao : Peca
{


    public Peao(Tabuleiro Tab, Cor cor) : base(Tab, cor)
    {
    }

    private bool existeInimigo(Posicao pos)
    {
        Peca p = tab.Peca(pos);
        return p != null && p.Cor != Cor;
    }

    private bool livre(Posicao pos)
    {
        return tab.Peca(pos) == null;
    }

    public override string ToString()
    {
        return "P";
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

        if (Cor == Cor.Branca)
        {
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (tab.PoisicaoValida(pos) && livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
            Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
            if (tab.PoisicaoValida(p2) && livre(p2) && tab.PoisicaoValida(pos) && livre(pos) && QuantidadeMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (tab.PoisicaoValida(pos) && existeInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (tab.PoisicaoValida(pos) && existeInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
        }
        else
        {
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.PoisicaoValida(pos) && livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
            Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.PoisicaoValida(p2) && livre(p2) && tab.PoisicaoValida(pos) && livre(pos) && QuantidadeMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (tab.PoisicaoValida(pos) && existeInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (tab.PoisicaoValida(pos) && existeInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
        }

        return mat;
    }


}

