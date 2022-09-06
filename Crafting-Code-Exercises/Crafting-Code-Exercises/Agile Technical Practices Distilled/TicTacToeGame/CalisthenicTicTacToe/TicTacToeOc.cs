namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class TicTacToeObjectCalisthenics
    {
        private int currentMoveNumber = 0;
        private Move LastMove = new(new Player(String.Empty), new Coordinate(-1, -1));
        
        internal void PlaceCounter(Move move)
        {
            if (move.CompareCoordinates(LastMove))
            {
                throw new InvalidMoveException();
            }

            if (move.ComparePlayer(LastMove))
            {
                throw new InvalidMoveException();
            }

            if (currentMoveNumber > 0)
            {
                LastMove = move;
                currentMoveNumber++;
                return;
            }

            if (move.ComparePlayer(new Player("X")))
            {
                LastMove = move;
                currentMoveNumber++;
                return;
            }
            
            throw new InvalidMoveException();
        }
    }
}