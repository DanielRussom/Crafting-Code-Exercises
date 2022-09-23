namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class GameOfLifeEngine
    {
        private Board _board;

        public GameOfLifeEngine(Board seed)
        {
            _board = seed;
        }

        internal EqualityState IsBoardStateEqualTo(Board expectedBoard)
        {
            return _board.Equals(expectedBoard);
        }
    }
}