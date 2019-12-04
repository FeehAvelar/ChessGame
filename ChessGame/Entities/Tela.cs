using System;
using Tabuleiro;

namespace ChessGame.Entities
{
    class Tela
    {
        public static void imprimirTabuleiro (GameBoard tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i+" > ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.PegaPeca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.ImprimirPeca(tab.PegaPeca(i, j));
                        Console.Write(" ");
                    }                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("    ^ ^ ^ ^ ^ ^ ^ ^");
            Console.WriteLine("    A B C D E F G H");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Color == Cor.White)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
