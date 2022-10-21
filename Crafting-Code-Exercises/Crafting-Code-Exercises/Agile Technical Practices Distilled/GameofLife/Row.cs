namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row
    {
        private readonly List<Cell> _cells;

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        public Row Tick(RowPosition rowPosition, NeighbouringRows neighbouringRows)
        {
            var newCellsRow = new List<Cell>();

            for (var columnLoopCounter = 0; columnLoopCounter < _cells.Count; columnLoopCounter++)
            {
                newCellsRow.Add(GetCellStateUsingNeighbours(new CellPosition(rowPosition.Value, columnLoopCounter), neighbouringRows));
            }

            return new(newCellsRow);
        }

        internal Cell GetCellStateUsingNeighbours(CellPosition cellPosition, NeighbouringRows neighbouringRows)
        {
            var neighbourCount = GetNumberOfLiveNeighboursForContainingRow(cellPosition);
            neighbourCount.IncrementBy(neighbouringRows.GetNumberOfLiveNeighboursForBorderingRow(cellPosition));
            return new Cell(neighbourCount.GetPopulationState());
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForBorderingRow(CellPosition cellPosition)
        {
            var neighbourCount = new LiveNeighbourCount(0);
            var loopStart = cellPosition.Column - 1;
            var loopEnd = cellPosition.Column + 1;

            if (loopStart < 0) loopStart = 0;
            if (loopEnd >= _cells.Count) loopEnd = _cells.Count - 1;

            for (var loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
            {
                neighbourCount.IncrementIfAlive(_cells[loopCounter].State);
            }

            return neighbourCount;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForContainingRow(CellPosition cellPosition)
        {
            var neighbourCount = new LiveNeighbourCount(0);
            var start = cellPosition.Column - 1;
            var end = cellPosition.Column + 1;

            if (start >= 0) neighbourCount.IncrementIfAlive(_cells[start].State);
            if (end < _cells.Count) neighbourCount.IncrementIfAlive(_cells[end].State);

            return new LiveNeighbourCount(_cells[cellPosition.Column].State, neighbourCount);
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

        private void PadWithEmptyCells(Row rowWithTargetSize)
        {
            while (_cells.Count < rowWithTargetSize._cells.Count)
            {
                _cells.Add(new(CellState.Dead));
            }
        }
    }
}
