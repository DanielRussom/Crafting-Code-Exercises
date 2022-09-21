namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class Cell
    {
        private readonly bool _state;

        public Cell(bool state)
        {
            _state = state;
        }

        public bool Equals(Cell other)
        {
            return _state == other._state;
        } 
    }
}
