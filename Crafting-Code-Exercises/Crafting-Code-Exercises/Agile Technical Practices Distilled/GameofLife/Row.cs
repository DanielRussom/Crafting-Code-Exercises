namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row
    {
        private readonly List<Cell> _cells;

        private int CellsCount => _cells.Count;

        public Row()
        {
            _cells = new List<Cell>();
        }

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        public Row Tick(NeighbouringRows neighbouringRows)
        {
            var newCellsRow = new List<Cell>();
            neighbouringRows.PadRowWithEmptyCells(this);
            if (_cells.Last().IsAlive()) _cells.Add(new(CellState.Dead));

            for (var columnLoopCounter = 0; columnLoopCounter < CellsCount; columnLoopCounter++)
            {
                newCellsRow.Add(GetCellStateUsingNeighbours(new ColumnPosition(columnLoopCounter), neighbouringRows));
            }

            return new(newCellsRow);
        }

        internal Cell GetCellStateUsingNeighbours(ColumnPosition columnPosition, NeighbouringRows neighbouringRows)
        {
            var neighbourCount = GetNumberOfLiveNeighboursForContainingRow(columnPosition);
            neighbourCount.IncrementBy(neighbouringRows.GetNumberOfLiveNeighboursForBorderingRow(columnPosition));
            return new Cell(neighbourCount.GetPopulationState());
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForBorderingRow(ColumnPosition columnPosition)
        {
            var neighbourCount = new LiveNeighbourCount(0);
            var loopStart = columnPosition.PositionToTheLeft;
            var loopEnd = columnPosition.PositionToTheRight;

            if (loopStart < 0) loopStart = 0;
            if (loopEnd >= CellsCount) loopEnd = CellsCount - 1;

            for (var loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
            {
                neighbourCount.IncrementIfAlive(_cells[loopCounter]);
            }

            return neighbourCount;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForContainingRow(ColumnPosition columnPosition)
        {
            var neighbourCount = new LiveNeighbourCount(0);

            if (columnPosition.PositionToTheLeft >= 0) neighbourCount.IncrementIfAlive(_cells[columnPosition.PositionToTheLeft]);
            if (columnPosition.PositionToTheRight < CellsCount) neighbourCount.IncrementIfAlive(_cells[columnPosition.PositionToTheRight]);

            return new LiveNeighbourCount(_cells[columnPosition.Position], neighbourCount);
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

        internal void PadWithEmptyCells(Row rowWithTargetSize)
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
            if (CellsCount == 0) return true;

            return !_cells.First().IsAlive();
        }

        public bool IsPopulated()
        {
            return CellsCount > 0;
        }

        public void RemoveDeadColumn()
        {
            if (!_cells.Any()) return;

            _cells.RemoveAt(0);
        }

        public bool IsDead()
        {
            return _cells.All(cell => !cell.IsAlive());
        }
    }
}
