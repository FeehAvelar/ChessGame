using Tabuleiro;

namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao Position { get; set; }
        public Cor Color { get; protected set; }
        public int AmountMoviment { get; set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca (Posicao position, Tabuleiro tab, Cor color)
        {
            Position = position;
            Tab = tab;
            Color = color;
            AmountMoviment = 0;
        }

        public abstract void Mover(Posicao newPosition);

    }
}
