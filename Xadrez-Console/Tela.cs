using System.Collections.Generic;
using tabuleiro;
using xadrez;
namespace Xadrez_Console
{
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);

            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {partida.jogadorAtual}");
            }


        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca p in conjunto)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.linhas; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tab.colunas; c++)
                {
                    imprimirPeca(tab.peca(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int l = 0; l < tab.linhas; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tab.colunas; c++)
                {
                    if (posicoesPossiveis[l, c])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(l, c));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s) || s.Length < 2)
            {
                throw new TabuleiroException("Erro: A entrada deve ter pelo menos dois caracteres.");
            }

            char coluna = char.ToLower(s[0]);
            if (!char.IsLetter(coluna) || coluna < 'a' || coluna > 'h')
            {
                throw new TabuleiroException("Erro: O primeiro caractere deve ser uma letra entre 'a' e 'h'.");
            }

            if (!int.TryParse(s[1].ToString(), out int linha))
            {
                throw new TabuleiroException("Erro: O segundo caractere deve ser um número.");
            }

            if (linha < 1 || linha > 8)
            {
                throw new TabuleiroException("Erro: O número da linha deve estar entre 1 e 8");
            }

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor corPeca = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = corPeca;
                }

                Console.Write(" ");
            }
        }
    }
}
