namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class MoveHistory
    {
        private List<Move> moveHistory = new();

        internal void AddMove(Move move)
        {
            moveHistory.Add(move);
        }

        internal bool CompareLastPlayer(Move move)
        {
            if (!moveHistory.Any())
            {
                return false;
            }

            var lastPlayer = moveHistory.Last();
            return lastPlayer.ComparePlayer(move);
        }

        internal bool HaveCoordinatesBeenUsed(Move move)
        {
            if (!moveHistory.Any())
            {
                return false;
            }

            return moveHistory.Any(x => x.CompareCoordinates(move));
        }
    }
}
