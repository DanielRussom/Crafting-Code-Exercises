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

            you are here - changing the logic that adds a new row into which expansion can occur as at the moment we only create a 3 cell row.
            // Dan would like to see ths tate of rows on line 33 for the failing test

            _rows = newRows;
            RemoveDeadColumnsFromTheLeft();
            RemoveDeadRowFromTheTop();
        }

        private void RemoveDeadRowFromTheTop()
        {
            if (_rows[0].IsDead())
            {
                _rows.RemoveAt(0);
            }
        }

        private void RemoveDeadColumnsFromTheLeft()
        {
            var populatedRows = _rows.Where(row => !row.IsRowEmpty()).ToList();

            while (populatedRows.Any() && populatedRows.All(row => row.IsFirstColumnDead()))
            {
                _rows.ForEach(row => row.RemoveDeadColumn());
                populatedRows = _rows.Where(row => !row.IsRowEmpty()).ToList();
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

            RemoveDeadColumnsFromTheLeft();
            boardToCompare.RemoveDeadColumnsFromTheLeft();

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
