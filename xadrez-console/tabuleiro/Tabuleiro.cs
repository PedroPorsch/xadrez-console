﻿using System;
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

        public Peca Peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public void AddPeca(Peca p, Posicao pos)
        {
            if (ExsitePeça(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RemovePeca(Posicao pos)
        {
            if (Peca(pos) == null)
            {
                return null;
            }
            Peca aux = Peca(pos);
            aux.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool ExsitePeça(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public bool PoisicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;

        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PoisicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}

