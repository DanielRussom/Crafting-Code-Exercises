namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row 
    {
        private readonly List<Cell> _cells;

        public List<Cell> Cells => _cells;

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        private int GetCellCount()
        {
            return _cells.Count;
        }

        private void PadWithEmptyCells(int upperLimit)
        {
            while (GetCellCount() < upperLimit)
            {
                _cells.Add(new(false));
            }
        }

        public EqualityState Equals(Row rowToCompare)
        {
            rowToCompare.PadWithEmptyCells(GetCellCount());
            PadWithEmptyCells(rowToCompare.GetCellCount());
            
            var index = 0;
            var isEqual = true;

            while (index < GetCellCount() && isEqual)
            {
                isEqual = _cells[index].Equals(rowToCompare._cells[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCell()
        {
            var neighbourCount = 0;
            var loopCounter = 0;

            while (loopCounter <= 2)
            {
                if (_cells[loopCounter].Equals(new(true)) == EqualityState.IsEqual) neighbourCount++;
                loopCounter++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForLeftCentreCell()
        {
            var neighbourCount = 0;
            var loopCounter = 0;

            while (loopCounter <= 1)
            {
                if (_cells[loopCounter].Equals(new(true)) == EqualityState.IsEqual) neighbourCount++;
                loopCounter++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCellInCentreRow()
        {
            var neighbourCount = 0;

            if (_cells[0].Equals(new(true)) == EqualityState.IsEqual) neighbourCount++;
            if (_cells[2].Equals(new(true)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(neighbourCount);
        }

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForLeftCentreCellInCentreRow()
        {
            var neighbourCount = 0;

            if (_cells[1].Equals(new(true)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(neighbourCount);
        }

        internal void SetCellState(int xCoordinate, bool cellState)
        {
            _cells[xCoordinate].SetCellState(cellState);
        }
    }
}
