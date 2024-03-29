﻿using ChessGame.Entities.Exceptions;

namespace Tabuleiro
{
    class GameBoard
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        public GameBoard(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca PegaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca PegaPeca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca (Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new GameBoardException("Position is invalid!");
            }

            return PegaPeca(pos) != null;
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new GameBoardException("Position is occuped!");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Position = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (PegaPeca(pos) == null)
            {
                return null;
            }

            Peca aux = PegaPeca(pos);
            aux.Position = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida (Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
    }
}
