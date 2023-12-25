using System;
using System.Runtime.ConstrainedExecution;

namespace tabuleiro;

public class Dama : Peca
{


    public Dama(Tabuleiro Tab, Cor cor) : base(Tab, cor)
    {
    }


    public override string ToString()
    {
        return "D";
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

        // esquerda
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // direita
        // esquerda
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // acima
        // esquerda
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // abaixo
        // esquerda
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // NO
        // esquerda
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // NE
        // esquerda
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - +1);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // SE
        // esquerda
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // SO
        // esquerda
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        while (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (tab.Peca(pos) != null && tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        return mat;

    }
}