using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.AddPeca(new Rei(tab, Cor.Preta), new Posicao(0, 0));
            

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}