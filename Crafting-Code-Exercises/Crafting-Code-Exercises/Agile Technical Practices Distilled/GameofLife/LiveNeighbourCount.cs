namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class LiveNeighbourCount
    {
        private int _liveNeighourCount;
        private readonly Cell _cell;

        private bool IsPerfectlyPopulated => _liveNeighourCount == 2 || _liveNeighourCount == 3;
        private bool IsNewlyPopulated => _liveNeighourCount == 3;

        public LiveNeighbourCount(int liveNeighourCount)
        {
            _cell = new(CellState.Dead);
            _liveNeighourCount = liveNeighourCount;
        }

        public LiveNeighbourCount(Cell cell, LiveNeighbourCount neighbourCount)
        {
            _cell = cell;
            _liveNeighourCount = neighbourCount._liveNeighourCount;
        }
        
        public void IncrementBy(LiveNeighbourCount liveNeighbourCount)
        {
            _liveNeighourCount += liveNeighbourCount._liveNeighourCount;
        }

        public void IncrementIfAlive(Cell cell)
        {
            if (cell.IsAlive()) _liveNeighourCount += 1;
        }

        public CellState GetPopulationState()
        {
            if (_cell.IsAlive() && IsPerfectlyPopulated)
            {
                return CellState.Alive;
            }

            if (!_cell.IsAlive() && IsNewlyPopulated)
            {
                return CellState.Alive;
            }

            return CellState.Dead;
        }
    }
}
