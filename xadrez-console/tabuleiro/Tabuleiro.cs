using System;
namespace tabuleiro
{
    public class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public void AddPeca(Peca p, Posicao pos)
        {   
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
    }
}

