using System;
namespace tabuleiro;

public class Cavalo : Peca
{


    public Cavalo(Tabuleiro Tab, Cor cor) : base(Tab, cor)
    {
    }


    public override string ToString()
    {
        return "C";
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

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
        if (tab.PoisicaoValida(pos) && Podemover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        return mat;
    }
}