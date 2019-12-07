using Tabuleiro;

namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao Position { get; set; }
        public Cor Color { get; protected set; }
        public int AmountMoviment { get; set; }
        public GameBoard Tab { get; protected set; }

        public Peca (GameBoard tab, Cor color)
        {
            Position = null;
            Tab = tab;
            Color = color;
            AmountMoviment = 0;
        }

        public void IncrementMoviment()
        {
            AmountMoviment++;
        }

        protected bool PodeMover(Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p == null || p.Color != this.Color;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool PodeMoverPara (Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna] == true;
        }

        abstract public bool[,] MovimentosPossiveis();        
    }
}
