using System.Collections.Generic;
using Tabuleiro;
using Entities.Enums;

namespace JogoXadrez
{
    sealed class Bishop : Peca
    {
        public Bishop (GameBoard tab, Cor color) : base (tab, color)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Nordeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                {
                    break;
                }
                pos.Linha--;
                pos.Coluna++;
            }
            //Sudeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                {
                    break;
                }
                pos.Linha++;
                pos.Coluna++;
            }
            //Sudoeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                {
                    break;
                }
                pos.Linha++;
                pos.Coluna--;
            }
            //Noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                {
                    break;
                }
                pos.Linha--;
                pos.Coluna--;
            }


            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
