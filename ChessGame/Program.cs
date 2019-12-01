using System;
using Tabuleiro;
using ChessGame.Entities;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard tab = new GameBoard(8, 8);

            Tela.imprimirTabuleiro(tab);
            
            
        }
    }
}
