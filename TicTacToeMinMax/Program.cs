﻿using System;
using TicTacToeMinMax.TicTacToe;

namespace TicTacToeMinMax {
    public class Program {
        static void Main(string[] args) {
            Game game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
}