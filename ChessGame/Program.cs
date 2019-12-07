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
                    Console.WriteLine("\nTurno {0}",partida.Turno);
                    Console.WriteLine($"Aguardando jogado: {partida.JogadorAtual}");

                    Console.Write("\nDigtie a origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConvertPosition();
                    partida.ValidarOrigem(origem);

                    Console.Clear();
                    bool[,] posicoesPossiveis = partida.Tab.PegaPeca(origem).MovimentosPossiveis();

                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                    

                    Console.Write("\nDestino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConvertPosition();
                    partida.ValidaDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);
                }
            }
            catch (GameBoardException e)
            {
                Console.WriteLine("Chess game error: " + e.Message);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
