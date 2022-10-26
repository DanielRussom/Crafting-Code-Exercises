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
            AddDeadRows();
            AddDeadColumnToTheLeft();

            for (var rowLoopCounter = 0; rowLoopCounter < RowCount; rowLoopCounter++)
            {
                var rowAbove = GetRowAtPosition(new(rowLoopCounter - 1));
                var rowBelow = GetRowAtPosition(new(rowLoopCounter + 1));

                var neighbouringRows = new NeighbouringRows(rowAbove, rowBelow);
                var newRow = _rows[rowLoopCounter].Tick(new (rowLoopCounter), neighbouringRows);
                newRows.Add(newRow);
            }

            _rows = newRows;
            RemoveDeadColumnFromTheLeft();
            RemoveDeadRowFromTheTop();
        }

        private void RemoveDeadRowFromTheTop()
        {
            if (_rows[0].IsDead())
            {
                _rows.RemoveAt(0);
            }
        }

        private void RemoveDeadColumnFromTheLeft()
        {
            var isFirstColumnCompletelyDead = _rows.All(row => row.IsFirstColumnDead());

            if (isFirstColumnCompletelyDead)
            {
                _rows.ForEach(row => row.RemoveDeadColumn());
            }
        }

        private void AddDeadColumnToTheLeft()
        {
            _rows.ForEach(row => row.AddDeadColumn());
        }

        private void AddDeadRows()
        {
            _rows.Insert(0, new());
            _rows.Add(new());
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
