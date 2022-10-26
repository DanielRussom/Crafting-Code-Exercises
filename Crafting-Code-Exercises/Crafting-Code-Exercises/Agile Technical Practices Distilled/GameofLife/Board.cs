namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private List<Row> _rows;

        private int RowCount => _rows.Count;

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public void Tick()
        {
            var newRows = new List<Row>();
            AddBlankRows();
            AddBlankColumn(); // matt King 26/10/22 - when in refactor stage rename this and use dead instead of blank.

            for (var rowLoopCounter = 0; rowLoopCounter < RowCount; rowLoopCounter++)
            {
                var rowAbove = GetRowAtPosition(new(rowLoopCounter - 1));
                var rowBelow = GetRowAtPosition(new(rowLoopCounter + 1));

                var neighbouringRows = new NeighbouringRows(rowAbove, rowBelow);
                var newRow = _rows[rowLoopCounter].Tick(new (rowLoopCounter), neighbouringRows);
                newRows.Add(newRow);
            }

            _rows = newRows;
            RemoveBlankColumn();
            RemoveBlankRowFromTheTop();
        }

        private void RemoveBlankRowFromTheTop()
        {
            if (_rows[0].Equals(new(new List<Cell> { new(CellState.Dead), new(CellState.Dead), new(CellState.Dead) })) == EqualityState.IsEqual)
            {
                _rows.RemoveAt(0);
            }
        }

        private void RemoveBlankColumn()
        {
            var isFirstColumnCompletelyBlank = _rows.All(row => row.IsFirstColumnDead());

            if (isFirstColumnCompletelyBlank)
            {
                _rows.ForEach(row => row.RemoveBlankColumn());
            }
        }

        private void AddBlankColumn()
        {
            _rows.ForEach(row => row.AddBlankColumn());
        }

        private void AddBlankRows()
        {
            _rows.Insert(0, new Row(new List<Cell> { new(CellState.Dead), new(CellState.Dead), new(CellState.Dead) }));
            _rows.Add(new Row(new List<Cell> { new(CellState.Dead), new(CellState.Dead), new(CellState.Dead) }));
        }

        private Row GetRowAtPosition(RowPosition position)
        {
            if (position.Value >= 0 && position.Value < RowCount) return _rows[position.Value];
            return new Row(new List<Cell>());
        }

        private void PadWithEmptyRows(Board boardWithTargetSize)
        {
            while (RowCount < boardWithTargetSize.RowCount)
            {
                _rows.Add(new(new List<Cell>()));
            }
        }

        public EqualityState Equals(Board boardToCompare)
        {
            PadWithEmptyRows(boardToCompare);
            boardToCompare.PadWithEmptyRows(this);

            var index = 0;
            var isEqual = true;

            while (index < RowCount && isEqual)
            {
                isEqual &= _rows[index].Equals(boardToCompare._rows[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }
    }
}
