namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class Move
    {
        private Player player;
        private Coordinate coordinate;

        public Move(Player player, Coordinate coordinate)
        {
            this.player = player;
            this.coordinate = coordinate;
        }

        internal bool CompareCoordinates(Move lastMove)
        {
            return coordinate.Equals(lastMove.coordinate);
        }

        internal bool ComparePlayer(Move lastMove)
        {
            return player.Equals(lastMove.player);
        }

        internal bool ComparePlayer(Player player)
        {
            return player.Equals(player);
        }
    }
}
