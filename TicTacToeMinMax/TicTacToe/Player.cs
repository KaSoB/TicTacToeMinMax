using static TicTacToeMinMax.TicTacToe.Board;

namespace TicTacToeMinMax.TicTacToe {
    public class Player {
        public State State { get; private set; }
        public Player(State state) {
            State = state;
        }
    }
}
