﻿using Tabuleiro;

namespace Xadrez_Console
{

    class Program 
    { 
        static void Main(string[] args)
        {
            Posicao posicao;

            posicao = new Posicao(3, 4);

            Console.WriteLine($"Posicao : {posicao.ToString()}");

        }
    }
}