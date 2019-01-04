using System;
using System.Linq;

namespace TicTacToeMinMax.TicTacToe {
    public class Board {
        // note: Blank = 0 by default 
        public enum State { Blank, X, O };

        public State[] BoardArray { get; private set; } = new State[9];

        public void Pick(int position, State state) {
            BoardArray[position] = state;
        }

        public bool IsWinner(State state) {
            if ((BoardArray[0] == state && BoardArray[1] == state && BoardArray[2] == state) ||
                (BoardArray[3] == state && BoardArray[4] == state && BoardArray[5] == state) ||
                (BoardArray[6] == state && BoardArray[7] == state && BoardArray[8] == state) ||
                (BoardArray[0] == state && BoardArray[3] == state && BoardArray[6] == state) ||
                (BoardArray[1] == state && BoardArray[4] == state && BoardArray[7] == state) ||
                (BoardArray[2] == state && BoardArray[5] == state && BoardArray[8] == state) ||
                (BoardArray[0] == state && BoardArray[4] == state && BoardArray[8] == state) ||
                (BoardArray[2] == state && BoardArray[4] == state && BoardArray[6] == state)) {
                return true;
            } else {
                return false;
            }
        }
        public int[] GetPositionsOf(State state) {
            return BoardArray
                .Select((f, i) => new { f, i })
                .Where(x => x.f == state)
                .Select(x => x.i)
                .ToArray();
        }
        public State this[int key] {
            get {
                return BoardArray[key];
            }
            set {
                BoardArray[key] = value;
            }
        }
        public void Display() {
            for (int i = 0 ; i < 3 ; i++) {
                for (int j = 0 ; j < 3 ; j++) {
                    var state = BoardArray[i * 3 + j];
                    var eChar = state == State.Blank ? "-" : state.ToString();
                    Console.Write($" {eChar} ");
                }
                Console.WriteLine();
            }
        }
    }
}

