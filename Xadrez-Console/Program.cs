﻿using tabuleiro;

namespace Xadrez_Console
{

    class Program 
    { 
        static void Main(string[] args)
        {
            Posicao posicao;

            Tabuleiro tab = new Tabuleiro(8,8);

            Tela.imprimirTabuleiro(tab);

        }
    }
}