using System;
using ChessGame.Entities;
using Tabuleiro;
using JogoXadrez;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard tab = new GameBoard(8, 8);
            tab.colocarPeca(new Rook(tab, Cor.Black),new Posicao(0, 0));
            tab.colocarPeca(new Rook(tab, Cor.Black), new Posicao(1, 3));
            tab.colocarPeca(new King(tab, Cor.Black), new Posicao(2, 4));
            Tela.imprimirTabuleiro(tab);
            
            
        }
    }
}
