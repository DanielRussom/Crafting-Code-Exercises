namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class GameOfLifeEngine
    {
        private readonly Board _board;

        public GameOfLifeEngine(Board seed)
        {
            _board = seed;
        }

        internal bool BoardIsEqualTo(Board expectedBoard)
        {
            return _board.Equals(expectedBoard);
        }

        public void Tick()
        {
            _board.Tick();
        }
    }
}