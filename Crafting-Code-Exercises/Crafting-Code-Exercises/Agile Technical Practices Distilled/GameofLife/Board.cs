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
            AddDeadRows();
            AddDeadColumnToTheLeft();
            UpdateBoard();
            RemoveDeadColumnsFromTheLeft();
            RemoveDeadRows();
        }

        private void UpdateBoard()
        {
            var newRows = new List<Row>();
            for (var rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                var neighbouringRows = BuildNeighbouringRows(rowIndex);
                var newRow = _rows[rowIndex].Tick(neighbouringRows);
                newRows.Add(newRow);
            }

            _rows = newRows;
        }

        private NeighbouringRows BuildNeighbouringRows(int rowIndex)
        {
            var rowAbove = GetRowAtPosition(new(rowIndex - 1));
            var rowBelow = GetRowAtPosition(new(rowIndex + 1));

            var neighbouringRows = new NeighbouringRows(rowAbove, rowBelow);
            return neighbouringRows;
        }

        private void RemoveDeadRows()
        {
            RemoveDeadRowFromTheTop();
            RemoveDeadRowFromTheBottom();
        }

        private void RemoveDeadRowFromTheTop()
        {
            while (_rows.Any() && _rows[0].IsDead())
            {
                _rows.RemoveAt(0);
            }
        }

        private void RemoveDeadRowFromTheBottom()
        {
            while (_rows.Any() && _rows[^1].IsDead())
            {
                _rows.RemoveAt(_rows.Count - 1);
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
            if (_rows.Count == 0) return;
            _rows.Insert(0, new(_rows.First()));
            _rows.Add(new(_rows.Last()));
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
