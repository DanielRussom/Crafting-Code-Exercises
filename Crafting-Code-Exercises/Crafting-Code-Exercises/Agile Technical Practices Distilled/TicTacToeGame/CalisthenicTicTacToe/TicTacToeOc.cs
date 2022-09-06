namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class TicTacToeObjectCalisthenics
    {
        private int currentMoveNumber = 0;
        private Player lastPlayer;

        internal void PlaceCounter(Coordinate coordinate, Player player)
        {
            if (player.Equals(lastPlayer))
            {
                throw new InvalidMoveException();
            }

            if (currentMoveNumber > 0)
            {
                lastPlayer = player;
                currentMoveNumber++;
                return;
            }

            if (player.Equals(new Player("X")))
            {
                lastPlayer = player;
                currentMoveNumber++;
                return;
            }
            
            throw new InvalidMoveException();
        }
    }
}