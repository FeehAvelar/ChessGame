using Tabuleiro;

namespace JogoXadrez
{
    sealed class King : Peca
    {
        public King(GameBoard tab, Cor color) : base (tab, color)
        {            
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
