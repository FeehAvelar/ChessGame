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
    }
}
