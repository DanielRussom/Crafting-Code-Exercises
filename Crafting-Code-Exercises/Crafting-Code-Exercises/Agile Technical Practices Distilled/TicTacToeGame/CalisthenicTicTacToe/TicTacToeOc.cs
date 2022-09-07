namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class TicTacToeObjectCalisthenics
    {
        private int currentMoveNumber = 0;
        private MoveHistory moveHistory = new();

        internal void PlaceCounter(Move move)
        {
            if (moveHistory.HaveCoordinatesBeenUsed(move))
            {
                var errorMessage = $"Coordinate {move.CoordinateToString()} already played";
                throw new InvalidMoveException(errorMessage);
            }

            if (moveHistory.CompareLastPlayer(move))
            {
                var errorMessage = $"Player {move.PlayerToString()} is not allowed to play this turn";
                throw new InvalidMoveException(errorMessage);
            }

            if (currentMoveNumber == 0 && !move.ComparePlayer(new Player("X")))
            {
                var errorMessage = $"Player {move.PlayerToString()} is not allowed to play this turn";
                throw new InvalidMoveException(errorMessage);
            }

            moveHistory.AddMove(move);
            currentMoveNumber++;
            return;
        }
    }
}