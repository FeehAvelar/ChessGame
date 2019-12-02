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
                GameBoard tab = new GameBoard(8, 8);
                tab.colocarPeca(new Rook(tab, Cor.Black), new Posicao(0, 0));
                tab.colocarPeca(new Rook(tab, Cor.Black), new Posicao(1, 3));
                tab.colocarPeca(new King(tab, Cor.Black), new Posicao(0, 2));
                Tela.imprimirTabuleiro(tab);
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
