using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToeMinMax.TicTacToe.Board;

namespace TicTacToeMinMax.TicTacToe {
    public class Game {
        static readonly Random random = new Random();
        readonly Board board = new Board();

        readonly Player player1 = new Player(State.O);
        readonly Player player2 = new Player(State.X);
        private Player currentPlayer;

        public void Play() {
            currentPlayer = player1;
            while (!IsEndGame()) {
                Console.WriteLine("Now move: " + currentPlayer.State);
                int index = 0;

                if (currentPlayer == player1) {
                    index = MinMaxFunction(currentPlayer).Index;
                } else {
                    // be carefull, you might override player1's move
                    index = int.Parse(Console.ReadLine());
                }


                board[index] = currentPlayer.State;
                board.Display();
                ChangePlayer();
            }
            EndGameMessage();
        }

        public Action MinMaxFunction(Player player) {
            var blankPositions = board.GetPositionsOf(State.Blank);

            // check winner
            if (board.IsWinner(player1.State)) {
                return new Action() { Score = Score.Max };
            } else if (board.IsWinner(player2.State)) {
                return new Action() { Score = Score.Min };
            } else if (!blankPositions.Any()) {
                return new Action() { Score = Score.Zero };
            }
            // for each posible move, calculate score
            List<Action> moves = new List<Action>();
            for (int i = 0 ; i < blankPositions.Length ; i++) {
                Action move = new Action {
                    Index = blankPositions[i]
                };

                // set temporary
                board.BoardArray[blankPositions[i]] = player.State;

                if (player == player1) {
                    move.Score = MinMaxFunction(player2).Score;
                } else if (player == player2) {
                    move.Score = MinMaxFunction(player1).Score;
                }

                // reset
                board.BoardArray[blankPositions[i]] = State.Blank;

                moves.Add(move);
            }


            var possibleMoves = moves.Where(it => it.Score == ((player == player1) ? Score.Max : Score.Min)).ToList();
            if (!possibleMoves.Any()) {
                possibleMoves = moves.Where(it => it.Score == Score.Zero).ToList();
            }
            if (!possibleMoves.Any()) {
                possibleMoves = moves;
            }
            int randomIndex = random.Next(0, possibleMoves.Count());

            Action bestMove = possibleMoves[randomIndex];
            return bestMove;
        }

        void ChangePlayer() {
            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }

        bool IsEndGame() {
            return board.IsWinner(player1.State) || board.IsWinner(player2.State) || !board.GetPositionsOf(State.Blank).Any();
        }
        void EndGameMessage() {
            if (board.IsWinner(player1.State)) {
                Console.WriteLine("Player1 won!");
            } else if (board.IsWinner(player2.State)) {
                Console.WriteLine("Player2 won!");
            } else if (!board.GetPositionsOf(State.Blank).Any()) {
                Console.WriteLine("Tie!");
            }
        }
    }
}
