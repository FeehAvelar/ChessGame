using System.Collections.Generic;

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
        public HashSet<Peca> Pecas { get; private set; }
        public HashSet<Peca> Capturadas { get; set; }

        public bool Xeque { get; private set; }


        public PartidaXadrez()
        {
            Tab = new GameBoard(8, 8);
            Turno = 1;
            JogadorAtual = Cor.White;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            Xeque = false;
            ColocarPecas();            
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.White)
            {
                return Cor.Black;
            }
            return Cor.White;
        }

        private Peca Rei (Cor cor)
        {
            foreach(Peca p in PecasEmJogo(cor))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool EstaXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new GameBoardException($"Não tem rei da cor {cor} no tabuleiro");
            }
            foreach (Peca p in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = p.MovimentosPossiveis();
                if (mat[rei.Position.Linha, rei.Position.Coluna] == true)
                {
                    return true;
                }
            }

            return false;
        }

        public Peca ExecutaMovimento (Posicao origem, Posicao destino)
        {
            Peca p = Tab.retirarPeca(origem);
            p.IncrementMoviment();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;                 
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.retirarPeca(destino);
            p.DecrementMoviment();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
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
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new GameBoardException("Você não pode se colocar em xeque!");
            }
            if (EstaXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
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

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in Pecas)
            {
                if (p.Color == cor)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(PecaCapturadas(cor));

            return aux;
        }

        public HashSet<Peca> PecaCapturadas (Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca p in Capturadas)
            {
                if (p.Color == cor)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConvertPosition());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Rook(Tab, Cor.White));
            ColocarNovaPeca('c', 2, new Rook(Tab, Cor.White));
            ColocarNovaPeca('d', 2, new Rook(Tab, Cor.White));
            ColocarNovaPeca('e', 2, new Rook(Tab, Cor.White));
            ColocarNovaPeca('e', 1, new Rook(Tab, Cor.White));
            ColocarNovaPeca('d', 1, new King(Tab, Cor.White));

            ColocarNovaPeca('c', 7, new Rook(Tab, Cor.Black));
            ColocarNovaPeca('c', 8, new Rook(Tab, Cor.Black));
            ColocarNovaPeca('d', 7, new Rook(Tab, Cor.Black));
            ColocarNovaPeca('e', 7, new Rook(Tab, Cor.Black));
            ColocarNovaPeca('e', 8, new Rook(Tab, Cor.Black));
            ColocarNovaPeca('d', 8, new King(Tab, Cor.Black));
        }
    }
}
