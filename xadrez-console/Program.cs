using System;
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

                tab.AddPeca(new Rei(tab, Cor.Branca), new Posicao(0, 0));
                tab.AddPeca(new Rei(tab, Cor.Amarela), new Posicao(0, 2));
                tab.AddPeca(new Rei(tab, Cor.Branca), new Posicao(2, 2));
                tab.AddPeca(new Rei(tab, Cor.Amarela), new Posicao(3, 2));
                
                
               

                Tela.ImprimirTabuleiro(tab);
            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}