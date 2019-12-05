using System;
using ChessGame.Entities;
using Tabuleiro;
using JogoXadrez;
using ChessGame.Entities.Exceptions;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.Write("Digtie a origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConvertPosition();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConvertPosition();

                    partida.ExecutaMovimento(origem, destino);
                }



            }
            catch (GameBoardException e)
            {
                Console.WriteLine("Chess game error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
