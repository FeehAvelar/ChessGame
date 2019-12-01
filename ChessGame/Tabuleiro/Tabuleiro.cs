namespace Tabuleiro
{
    class GameBoard
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        public GameBoard(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca PegaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
    }
}
