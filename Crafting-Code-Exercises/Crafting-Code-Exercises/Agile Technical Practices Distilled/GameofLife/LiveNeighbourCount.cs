namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class LiveNeighbourCount
    {
        private int _value;
        private CellState _cellState;

        public LiveNeighbourCount(int value)
        {
            _value = value;
        }

        public LiveNeighbourCount(CellState cellState, int value)
        {
            _cellState = cellState;
            _value = value;
        }
        
        public void IncrementBy(LiveNeighbourCount liveNeighbourCount)
        {
            _value += liveNeighbourCount._value;
        }

        public CellState GetPopulationState()
        {
            if (_cellState == CellState.Alive && (_value == 2 || _value == 3))
            {
                return CellState.Alive;
            }

            if (_cellState == CellState.Dead && _value == 3)
            {
                return CellState.Alive;
            }

            return CellState.Dead;
        }
    }
}
