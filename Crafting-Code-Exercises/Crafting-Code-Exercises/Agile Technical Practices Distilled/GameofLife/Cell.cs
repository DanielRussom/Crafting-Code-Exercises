namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Cell
    {
        private readonly CellState _state;

        public Cell(CellState state)
        {
            _state = state;
        }

        public bool IsAlive()
        {
            return _state == CellState.Alive;
        }

        public bool Equals(Cell other)
        {
            return _state == other._state;
        }
    }
}