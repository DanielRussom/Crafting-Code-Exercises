﻿namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row
    {
        private readonly List<Cell> _cells;

        private int CellsCount => _cells.Count;

        public Row(Row rowToAlignWith)
        {
            _cells = new List<Cell>();
            for (var loopCounter = 1; loopCounter <= rowToAlignWith.CellsCount; loopCounter++)
            {
                _cells.Add(new(CellState.Dead));
            }
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
            var loopStart = columnPosition.Value - 1;
            var loopEnd = columnPosition.Value + 1;

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
            var start = columnPosition.Value - 1;
            var end = columnPosition.Value + 1;

            if (start >= 0) neighbourCount.IncrementIfAlive(_cells[start]);
            if (end < CellsCount) neighbourCount.IncrementIfAlive(_cells[end]);

            return new LiveNeighbourCount(_cells[columnPosition.Value], neighbourCount);
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
            if (_cells.Count == 0) return true;

            return !_cells.First().IsAlive();
        }

        public bool IsRowEmpty()
        {
            return _cells.Count == 0;
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
