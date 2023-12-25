using System;
using System.Runtime.ConstrainedExecution;
using xadrez;

namespace tabuleiro;

public class Peao : Peca
{
    private PartidaDeXadrez Partida { get; set; }

    public Peao(Tabuleiro Tab, Cor cor, PartidaDeXadrez partida) : base(Tab, cor)
    {
        Partida = partida;
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

            //en passant branca

            if (Posicao.Linha == 3)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if (tab.PoisicaoValida(esquerda) && existeInimigo(esquerda) && tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                }

                if (Posicao.Linha == 3)
                {
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tab.PoisicaoValida(direita) && existeInimigo(direita) && tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
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
            Posicao P2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
            if (tab.PoisicaoValida(P2) && livre(P2) && tab.PoisicaoValida(pos) && livre(pos) && QuantidadeMovimentos == 0)
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


            //en passant branca

            if (Posicao.Linha == 4)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if (tab.PoisicaoValida(esquerda) && existeInimigo(esquerda) && tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                }

                if (Posicao.Linha == 3)
                {
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tab.PoisicaoValida(direita) && existeInimigo(direita) && tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }

                }

            }

        }
        return mat;
    }
}
