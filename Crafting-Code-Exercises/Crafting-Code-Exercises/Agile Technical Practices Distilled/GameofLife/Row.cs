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

        public LiveNeighbourCount GetNumberOfLiveNeighboursForBorderingRow(ColumnPosition columnPosition)
        {
            var neighbourCount = 0;
            var loopStart = columnPosition.Value - 1;
            var loopEnd = columnPosition.Value + 1;

            if (loopStart < 0) loopStart = 0;
            if (loopEnd >= _cells.Count) loopEnd = _cells.Count - 1;

            for (var loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
            {
                if (_cells[loopCounter].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForContainingRow(ColumnPosition columnPosition)
        {
            var neighbourCount = 0;
            var start = columnPosition.Value - 1;
            var end = columnPosition.Value + 1;

            if (start >= 0 && _cells[start].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            if (end < _cells.Count && _cells[end].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(neighbourCount);
        }
    }
}
