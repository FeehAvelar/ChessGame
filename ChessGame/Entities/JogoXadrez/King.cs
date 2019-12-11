using Tabuleiro;

namespace JogoXadrez
{
    sealed class King : Peca
    {

        public PartidaXadrez Partida { get; private set; }
        public King(GameBoard tab, Cor color, PartidaXadrez partida) : base (tab, color)
        {
            this.Partida = partida;
        }

        private bool TestaTorreRoque (Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p != null && p is Rook && p.AmountMoviment == 0 && p.Color == this.Color;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            
            //Acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Nordeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sudeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sul
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sudoeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //#jogadaEspecial Roque
            if (AmountMoviment == 0 && !Partida.Xeque)
            {
                //Roque pequeno
                Posicao posT = new Posicao(Position.Linha, Position.Coluna + 3);
                if (TestaTorreRoque(posT))
                {
                    Posicao p1 = new Posicao(Position.Linha, Position.Coluna + 1);
                    Posicao p2 = new Posicao(Position.Linha, Position.Coluna + 2);
                    if (Tab.PegaPeca(p1) == null && Tab.PegaPeca(p2) == null)
                    {
                        mat[Position.Linha, Position.Coluna + 2] = true;
                    }
                }
                //Roque Grande
                posT = new Posicao(Position.Linha, Position.Coluna - 4);
                if (TestaTorreRoque(posT))
                {
                    Posicao p1 = new Posicao(Position.Linha, Position.Coluna - 1);
                    Posicao p2 = new Posicao(Position.Linha, Position.Coluna - 2);
                    Posicao p3 = new Posicao(Position.Linha, Position.Coluna - 3);
                    if (Tab.PegaPeca(p1) == null && Tab.PegaPeca(p2) == null && Tab.PegaPeca(p3) == null)
                    {
                        mat[Position.Linha, Position.Coluna - 2] = true;
                    }
                }                
            }

                return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
