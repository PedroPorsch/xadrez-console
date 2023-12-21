﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.AddPeca(new Rei(tab, Cor.Preta), new Posicao(0, 0));
                tab.AddPeca(new Rei(tab, Cor.Preta), new Posicao(0, 9));


                Tela.ImprimirTabuleiro(tab);
            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}