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

        private void PadWithEmptyCells(Row rowWithTargetSize)
        {
            while (_cells.Count < rowWithTargetSize._cells.Count)
            {
                _cells.Add(new(CellState.Dead));
            }
        }

        public EqualityState Equals(Row rowToCompare)
        {
            rowToCompare.PadWithEmptyCells(this);
            PadWithEmptyCells(rowToCompare);
            
            var index = 0;
            var isEqual = true;

            while (index < _cells.Count && isEqual)
            {
                isEqual = _cells[index].Equals(rowToCompare._cells[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCell()
        {
            var neighbourCount = 0;

            for (var loopCounter = 0; loopCounter <= 2; loopCounter++)
            {
                if (_cells[loopCounter].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForLeftCentreCell()
        {
            var neighbourCount = 0;

            for (var loopCounter = 0; loopCounter <= 1; loopCounter++)
            {
                if (_cells[loopCounter].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForRightCentreCell()
        {
            var neighbourCount = 0;

            for (var loopCounter = 1; loopCounter <= 2; loopCounter++)
            {
                if (_cells[loopCounter].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCellInCentreRow()
        {
            var neighbourCount = 0;

            if (_cells[0].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            if (_cells[2].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(neighbourCount);
        }

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForLeftCentreCellInCentreRow()
        {
            var neighbourCount = 0;

            if (_cells[1].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(neighbourCount);
        }
        
        public LiveNeighbourCount GetNumberOfLiveNeighboursForRightCentreCellInCentreRow()
        {
            var neighbourCount = 0;

            if (_cells[1].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(neighbourCount);
        }
    }
}
