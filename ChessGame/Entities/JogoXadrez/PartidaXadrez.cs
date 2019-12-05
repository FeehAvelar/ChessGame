using Tabuleiro;

namespace JogoXadrez
{
    class PartidaXadrez
    {
        public GameBoard Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set;  }
        public PartidaXadrez()
        {
            Tab = new GameBoard(8, 8);
            Turno = 1;
            jogadorAtual = Cor.White;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento (Posicao origem, Posicao destino)
        {
            Peca p = Tab.retirarPeca(origem);
            p.IncrementMoviment();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);            
        }

        private void ColocarPecas()
        {
            Tab.colocarPeca(new Rook(Tab, Cor.White), new PosicaoXadrez('c', 1).ConvertPosition());
            Tab.colocarPeca(new King(Tab, Cor.White), new PosicaoXadrez('d', 1).ConvertPosition());
            Tab.colocarPeca(new Rook(Tab, Cor.Black), new PosicaoXadrez('e', 1).ConvertPosition());
            Tab.colocarPeca(new Rook(Tab, Cor.Black), new PosicaoXadrez('f', 1).ConvertPosition());
        }
    }
}
