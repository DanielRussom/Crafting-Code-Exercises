namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row
    {
        private readonly List<Cell> _cells;
        private bool FirstCellIsAlive => _cells.First().IsAlive();
        private bool LastCellIsAlive => _cells.Last().IsAlive();

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
            neighbouringRows.PadRowWithDeadCells(this);
            AppendDeadCellIfNecessary();
            return BuildNewRow(neighbouringRows);
        }

        private Row BuildNewRow(NeighbouringRows neighbouringRows)
        {
            var newCellsRow = new List<Cell>();
            for (var columnLoopCounter = 0; columnLoopCounter < CellsCount; columnLoopCounter++)
            {
                newCellsRow.Add(GetCellStateUsingNeighbours(new ColumnPosition(columnLoopCounter), neighbouringRows));
            }

            return new Row(newCellsRow);
        }

        private void AppendDeadCellIfNecessary()
        {
            if (LastCellIsAlive) AppendSingleDeadCell();
        }

        internal Cell GetCellStateUsingNeighbours(ColumnPosition columnPosition, NeighbouringRows neighbouringRows)
        {
            var neighbourCount = GetNumberOfLiveNeighboursForContainingRow(columnPosition);
            neighbourCount.IncrementBy(neighbouringRows.GetNumberOfLiveNeighboursForBorderingRow(columnPosition));
            return new Cell(neighbourCount.GetPopulationState());
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForBorderingRow(ColumnPosition columnPosition)
        {
            var loopStart = columnPosition.PositionToTheLeft;
            var loopEnd = columnPosition.PositionToTheRight;

            if (loopStart < 0) loopStart = 0;
            if (loopEnd >= CellsCount) loopEnd = CellsCount - 1;

            var neighbourCount = new LiveNeighbourCount(0);
            for (var loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
            {
                neighbourCount.IncrementIfAlive(_cells[loopCounter]);
            }

            return neighbourCount;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForContainingRow(ColumnPosition columnPosition)
        {
            var positionToLeftOfColumn = columnPosition.PositionToTheLeft;
            var positionToRightOfColumn = columnPosition.PositionToTheRight;
            var neighbourCount = new LiveNeighbourCount(0);

            if (positionToLeftOfColumn >= 0) neighbourCount.IncrementIfAlive(_cells[positionToLeftOfColumn]);
            if (positionToRightOfColumn < CellsCount) neighbourCount.IncrementIfAlive(_cells[positionToRightOfColumn]);

            return new LiveNeighbourCount(_cells[columnPosition.Position], neighbourCount);
        }

        public bool Equals(Row rowToCompare)
        {
            AlignRowDimensions(rowToCompare);

            var index = 0;
            var isEqual = true;

            while (index < CellsCount && isEqual)
            {
                isEqual = CompareCell(rowToCompare, index);
                index++;
            }

            return isEqual;
        }

        private bool CompareCell(Row rowToCompare, int index)
        {
            return _cells[index].Equals(rowToCompare._cells[index]);
        }

        private void AlignRowDimensions(Row rowToCompare)
        {
            rowToCompare.PadWithDeadCells(this);
            PadWithDeadCells(rowToCompare);
        }

        internal void PadWithDeadCells(Row rowWithTargetSize)
        {
            while (CellsCount < rowWithTargetSize.CellsCount)
            {
                AppendSingleDeadCell();
            }
        }

        private void AppendSingleDeadCell()
        {
            _cells.Add(new(CellState.Dead));
        }

        public void InsertSingleDeadCell()
        {
            _cells.Insert(0, new(CellState.Dead));
        }

        public bool IsFirstColumnDeadOrEmpty()
        {
            if (!IsPopulated()) return true;

            return !FirstCellIsAlive;
        }

        public bool IsPopulated()
        {
            return CellsCount > 0;
        }

        public void RemoveDeadColumn()
        {
            if (!IsPopulated()) return;

            _cells.RemoveAt(0);
        }

        public bool IsDead()
        {
            return _cells.All(cell => !cell.IsAlive());
        }
    }
}
