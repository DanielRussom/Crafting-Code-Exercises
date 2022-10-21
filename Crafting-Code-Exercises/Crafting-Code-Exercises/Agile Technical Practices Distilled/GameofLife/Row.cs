namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row
    {
        private readonly List<Cell> _cells;

        public List<Cell> Cells => _cells;  You are here - remove these public accesors that broke the OC rules.

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        public Row Tick(CellPosition cellPosition, Row? rowAbove, Row? rowBelow)
        {
            var newCellsRow = new List<Cell>();

            for (var columnLoopCounter = 0; columnLoopCounter < _cells.Count; columnLoopCounter++)
            {
                var numberOfLiveNeighboursForCell = GetNumberOfLiveNeighboursForCell(new CellPosition(cellPosition.Row, columnLoopCounter), rowAbove, rowBelow);
                var newCellState  = numberOfLiveNeighboursForCell.GetPopulationState();
                newCellsRow.Add(new Cell(newCellState));
            }

            return new(newCellsRow);
        }

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForCell(CellPosition cellPosition, Row? rowAbove, Row? rowBelow)
        {
            //if (_rows.Count < 3) return new LiveNeighbourCount(0);

            var neighbourCount = GetNumberOfLiveNeighboursForContainingRow(cellPosition);

            if (rowAbove != null)
            {
                neighbourCount.IncrementBy(rowAbove.GetNumberOfLiveNeighboursForBorderingRow(cellPosition));
            }

            if (rowBelow != null)
            {
                neighbourCount.IncrementBy(rowBelow.GetNumberOfLiveNeighboursForBorderingRow(cellPosition));
            }

            return neighbourCount;
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

        public LiveNeighbourCount GetNumberOfLiveNeighboursForBorderingRow(CellPosition cellPosition)
        {
            var neighbourCount = 0;
            var loopStart = cellPosition.Column - 1;
            var loopEnd = cellPosition.Column + 1;

            if (loopStart < 0) loopStart = 0;
            if (loopEnd >= _cells.Count) loopEnd = _cells.Count - 1;

            for (var loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
            {
                if (_cells[loopCounter].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            }

            return new LiveNeighbourCount(neighbourCount);
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForContainingRow(CellPosition cellPosition)
        {
            var neighbourCount = 0;
            var start = cellPosition.Column - 1;
            var end = cellPosition.Column + 1;

            if (start >= 0 && _cells[start].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;
            if (end < _cells.Count && _cells[end].Equals(new(CellState.Alive)) == EqualityState.IsEqual) neighbourCount++;

            return new LiveNeighbourCount(_cells[cellPosition.Column].State, neighbourCount);
        }
    }
}
