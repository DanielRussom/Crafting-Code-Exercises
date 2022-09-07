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

        internal bool CompareCoordinates(Move toCompare)
        {
            return coordinate.Equals(toCompare.coordinate);
        }

        internal bool ComparePlayer(Move toCompare)
        {
            return player.Equals(toCompare.player);
        }

        internal bool ComparePlayer(Player toCompare)
        {
            return player.Equals(toCompare);
        }
    }
}
