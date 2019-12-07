using Tabuleiro;
using ChessGame.Entities.Exceptions;

namespace JogoXadrez
{
    class PartidaXadrez
    {
        public GameBoard Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set;  }
        public PartidaXadrez()
        {
            Tab = new GameBoard(8, 8);
            Turno = 1;
            JogadorAtual = Cor.White;
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

        public void ValidarOrigem(Posicao pos)
        {
            if (Tab.PegaPeca(pos) == null)
                throw new GameBoardException("Não existe peça no local selecionado");

            if (Tab.PegaPeca(pos).Color != JogadorAtual)
                throw new GameBoardException("A peça de origem é não é sua");

            if (!Tab.PegaPeca(pos).ExisteMovimentosPossiveis())
                throw new GameBoardException("Não há movimentos possíveis para a peça de origem escolhida");
        }

        public void ValidaDestino (Posicao origem,Posicao destino)
        {
            if (origem == destino)
                throw new GameBoardException("A peça tem que ser movida");
            if (!Tab.PegaPeca(origem).PodeMoverPara(destino))
            {
                throw new GameBoardException("Posição de destino inválida");
            }
        }

        public void RealizaJogada (Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.White)
            {
                JogadorAtual = Cor.Black;
            }
            else
            {
                JogadorAtual = Cor.White;
            }
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
