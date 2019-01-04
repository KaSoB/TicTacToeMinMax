namespace TicTacToeMinMax.TicTacToe {
    public class Action {
        public enum Score { Min = -10, Max = 10, Zero = 0 }
        public int Index { get; set; }
        public Score Result { get; set; }
    }
}
