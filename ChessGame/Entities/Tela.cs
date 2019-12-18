using System;
using System.Collections.Generic;
using Tabuleiro;
using JogoXadrez;
using Entities.Enums;

namespace ChessGame.Entities
{
    class Tela
    {
        public static void ImprimirPartida(PartidaXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("\nTurno {0}", partida.Turno);

            if (!partida.Terminada)
            {
                Console.WriteLine($"Aguardando jogador: {partida.JogadorAtual}");

                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE MATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjuntos(partida.PecaCapturadas(Cor.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            ImprimirConjuntos(partida.PecaCapturadas(Cor.Black));
            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjuntos (HashSet<Peca> hash)
        {
            Console.Write("[");
            foreach (Peca p in hash)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro (GameBoard tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i+" > ");// ->
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.PegaPeca(i, j));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("    ^  ^  ^  ^  ^  ^  ^  ^");
            Console.WriteLine("    A  B  C  D  E  F  G  H");
        }

        public static void ImprimirTabuleiro (GameBoard tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " > ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.PegaPeca(i, j));
                    Console.Write(" ");
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("    ^  ^  ^  ^  ^  ^  ^  ^");
            Console.WriteLine("    A  B  C  D  E  F  G  H");

        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            int linha = int.Parse(s[1] + "");
            char coluna = s[0];            
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }

        }
    }
}
