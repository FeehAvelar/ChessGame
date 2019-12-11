using System;
using System.Collections.Generic;
using Tabuleiro;

namespace JogoXadrez
{
    class Pawn : Peca
    {
        public PartidaXadrez Partida { get; private set; }
        public Pawn (GameBoard tab, Cor cor, PartidaXadrez partida) : base (tab, cor)
        {
            Partida = partida;
        }

        private bool ExisteInimigo (Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p != null && p.Color != Color;
        }

        private bool Livre (Posicao pos)
        {
            return Tab.PegaPeca(pos) == null;
        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Color == Cor.White)
            {
                pos.DefinirValores(Position.Linha - 1, Position.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha - 2, Position.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && AmountMoviment == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#JogadaEspecial EnPasant
                if (Position.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Position.Linha, Position.Coluna - 1);
                    if(Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.PegaPeca(esquerda) == Partida.VuneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Position.Linha, Position.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.PegaPeca(direita) == Partida.VuneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Position.Linha + 1, Position.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha + 2, Position.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && AmountMoviment == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#JogadaEspecial EnPasant
                if (Position.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Position.Linha, Position.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.PegaPeca(esquerda) == Partida.VuneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Position.Linha, Position.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.PegaPeca(direita) == Partida.VuneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
