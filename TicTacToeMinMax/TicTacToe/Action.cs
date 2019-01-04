namespace TicTacToeMinMax.TicTacToe {
    public enum Score { Min = -10, Max = 10, Zero = 0 }
    public class Action {
        public int Index { get; set; }
        public Score Score { get; set; }
    }
}
