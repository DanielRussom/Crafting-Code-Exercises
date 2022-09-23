namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Cell
    {
        private readonly bool _state;

        public Cell(bool state)
        {
            _state = state;
        }

        public EqualityState Equals(Cell other)
        {
            return _state == other._state ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        } 
    }
}
