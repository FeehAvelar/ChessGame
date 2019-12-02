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
                
    }
}
