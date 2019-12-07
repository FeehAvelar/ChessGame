using Tabuleiro;

namespace JogoXadrez
{
    class Rook : Peca
    {
        public Rook(GameBoard tab, Cor color) : base(tab, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                {
                    break;
                }
                pos.Linha -= 1;
            }

            //Abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                    break;
                pos.Linha += 1;
            }

            //Direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                    break;
                pos.Coluna += 1;
            }

            //Esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Color != Color)
                    break;
                pos.Coluna -= 1;
            }

            return mat;
        }
    }
}
