namespace JogoDaVelhaCSharp
{
    public class Jogo
    {
        public void Jogada()
        {
            Console.WriteLine("Chegou no programa correto!");

            char[,] tabuleiro = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            int jogadas = 0;
            int jogador = 2;
            int linha, coluna;
            bool jogadaValida = false;

            while (jogadas < 9)
            {
                Console.Clear();
                Console.WriteLine("JOGO DA VELHA C#\n");

                // Desenha o tabuleiro
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[i, 0], tabuleiro[i, 1], tabuleiro[i, 2]);
                    if (i < 2)
                        Console.WriteLine("---|---|---");
                }

                // Verifica se houve vencedor
                if (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2] ||
                    tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2] ||
                    tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[2, 1] == tabuleiro[2, 2] ||
                    tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[1, 0] == tabuleiro[2, 0] ||
                    tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1] ||
                    tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2] ||
                    tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2] ||
                    tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
                {
                    Console.WriteLine("\nParabéns! Jogador {0} venceu!", jogador == 1 ? 'O' : 'X');
                    break;
                }

                // Verifica se deu empate
                if (jogadas == 8)
                {
                    Console.WriteLine("\nDeu empate!");
                    break;
                }

                // Lê a jogada do jogador
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

                // Alterna o jogador
                jogador = jogador == 1 ? 2 : 1;
                jogadas++;
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
