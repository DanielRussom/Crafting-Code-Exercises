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
                throw new InvalidMoveException();
            }

            if (moveHistory.CompareLastPlayer(move))
            {
                throw new InvalidMoveException();
            }

            if (currentMoveNumber > 0)
            {
                moveHistory.AddMove(move);
                currentMoveNumber++;
                return;
            }

            if (move.ComparePlayer(new Player("X")))
            {
                moveHistory.AddMove(move);
                currentMoveNumber++;
                return;
            }
            
            throw new InvalidMoveException();
        }
    }
}