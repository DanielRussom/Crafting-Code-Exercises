namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row
    {
        private readonly List<Cell> _cells;

        private int CellsCount => _cells.Count;

        public Row()
        {
            _cells = new List<Cell> { new(CellState.Dead), new(CellState.Dead), new(CellState.Dead) };
        }

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        public Row Tick(RowPosition rowPosition, NeighbouringRows neighbouringRows)
        {
            var newCellsRow = new List<Cell>();
            _cells.Add(new(CellState.Dead));

            for (var columnLoopCounter = 0; columnLoopCounter < CellsCount; columnLoopCounter++)
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
            if (loopEnd >= CellsCount) loopEnd = CellsCount - 1;

            for (var loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
            {
                neighbourCount.IncrementIfAlive(_cells[loopCounter]);
            }

            return neighbourCount;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForContainingRow(CellPosition cellPosition)
        {
            var neighbourCount = new LiveNeighbourCount(0);
            var start = cellPosition.Column - 1;
            var end = cellPosition.Column + 1;

            if (start >= 0) neighbourCount.IncrementIfAlive(_cells[start]);
            if (end < CellsCount) neighbourCount.IncrementIfAlive(_cells[end]);

            return new LiveNeighbourCount(_cells[cellPosition.Column], neighbourCount);
        }

        public EqualityState Equals(Row rowToCompare)
        {
            rowToCompare.PadWithEmptyCells(this);
            PadWithEmptyCells(rowToCompare);

            var index = 0;
            var isEqual = true;

            while (index < CellsCount && isEqual)
            {
                isEqual = _cells[index].Equals(rowToCompare._cells[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }

        private void PadWithEmptyCells(Row rowWithTargetSize)
        {
            while (CellsCount < rowWithTargetSize.CellsCount)
            {
                _cells.Add(new(CellState.Dead));
            }
        }

        public void AddDeadColumn()
        {
            _cells.Insert(0, new(CellState.Dead));
        }

        public bool IsFirstColumnDead()
        {
            return !_cells.First().IsAlive();
        }

        public void RemoveDeadColumn()
        {
            _cells.RemoveAt(0);
        }

        public bool IsDead()
        {
            return _cells.All(cell => !cell.IsAlive());
        }
    }
}
