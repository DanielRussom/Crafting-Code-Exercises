namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class GameOfLifeEngine
    {
        private Board _board;

        public GameOfLifeEngine(List<Row> seed)
        {
            _board = new Board(seed);
        }

        internal BoardEqualityState IsBoardStateEqualTo(Board expectedBoard)
        {
            return _board.Equals(expectedBoard);
        }
    }
}