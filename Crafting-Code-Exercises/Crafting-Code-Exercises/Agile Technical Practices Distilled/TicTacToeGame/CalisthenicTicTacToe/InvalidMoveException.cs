namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class InvalidMoveException : Exception
    {
        public InvalidMoveException() : base()
        {
        }

        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}