namespace JogoDaVelhaCSharp
{
    public class Jogo
    {
        public static void Jogada()
        {
            Console.WriteLine("Jogo da #");

            char[,] tabuleiro = InicializarTabuleiro();
            int jogadas = 0;
            int jogador = 2;
            int linha, coluna;

            while (jogadas < 9)
            {
                MostrarTabuleiro(tabuleiro);

                if (VerificarVencedor(tabuleiro, jogador))
                {
                    Console.WriteLine("\nParabéns! Jogador {0} venceu!", jogador == 1 ? 'O' : 'X');
                    break;
                }

                if (jogadas == 8)
                {
                    Console.WriteLine("\nDeu empate!");
                    break;
                }

                Jogar(tabuleiro, ref jogador, out linha, out coluna);
                jogadas++;
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        public static char[,] InicializarTabuleiro()
        {
            return new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        public static void MostrarTabuleiro(char[,] tabuleiro)
        {
            //Console.Clear();
            Console.WriteLine("JOGO DA VELHA C#\n");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[i, 0], tabuleiro[i, 1], tabuleiro[i, 2]);
                if (i < 2)
                    Console.WriteLine("---|---|---");
            }
        }

        public static bool VerificarVencedor(char[,] tabuleiro, int jogador)
        {
            return tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2] ||
                   tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2] ||
                   tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[2, 1] == tabuleiro[2, 2] ||
                   tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[1, 0] == tabuleiro[2, 0] ||
                   tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1] ||
                   tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2] ||
                   tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2] ||
                   tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0];
        }

        private static void Jogar(char[,] tabuleiro, ref int jogador, out int linha, out int coluna)
        {
            bool jogadaValida;
            do
            {
                Console.Write("\nJogador {0}, digite a posição desejada (1-9): ", jogador);
                int posicao = int.Parse(Console.ReadLine());

                linha = (posicao - 1) / 3;
                coluna = (posicao - 1) % 3;

                if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
                {
                    jogadaValida = true;
                    tabuleiro[linha, coluna] = jogador == 1 ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("\nJogada inválida! Tente novamente.");
                    jogadaValida = false;
                }

            } while (!jogadaValida);

            jogador = jogador == 1 ? 2 : 1;
        }
    }
}
