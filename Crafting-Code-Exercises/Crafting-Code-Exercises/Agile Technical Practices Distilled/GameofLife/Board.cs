namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private List<Row> _rows;
        private int RowCount => _rows.Count;
        private bool RowsArePopulated => RowCount > 0;
        private bool FirstRowIsDead => _rows.First().IsDead();
        private bool LastRowIsDead => _rows.Last().IsDead();

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public bool Equals(Board boardToCompare)
        {
            AlignBoardDimensions(boardToCompare);

            var index = 0;
            var isEqual = true;

            while (index < RowCount && isEqual)
            {
                isEqual &= CompareRow(boardToCompare, index);
                index++;
            }

            return isEqual;
        }

        public void Tick()
        {
            AddDeadRows();
            AddDeadColumnToTheLeft();
            UpdateBoard();
            RemoveDeadColumnsFromTheLeft();
            RemoveDeadRows();
        }

        private void AlignBoardDimensions(Board boardToCompare)
        {
            PadWithEmptyRows(boardToCompare);
            boardToCompare.PadWithEmptyRows(this);

            RemoveDeadColumnsFromTheLeft();
            boardToCompare.RemoveDeadColumnsFromTheLeft();
        }

        private void PadWithEmptyRows(Board boardWithTargetSize)
        {
            while (RowCount < boardWithTargetSize.RowCount)
            {
                _rows.Add(new());
            }
        }

        private void RemoveDeadColumnsFromTheLeft()
        {
            var populatedRows = GetPopulatedRows();

            while (populatedRows.Any() && populatedRows.All(row => row.IsFirstColumnDeadOrEmpty()))
            {
                _rows.ForEach(row => row.RemoveDeadColumn());
                populatedRows = GetPopulatedRows();
            }
        }

        private List<Row> GetPopulatedRows()
        {
            return _rows.Where(row => row.IsPopulated()).ToList();
        }

        private bool CompareRow(Board boardToCompare, int index)
        {
            var row = _rows[index];
            var rowToCompare = boardToCompare._rows[index];

            return row.Equals(rowToCompare);
        }

        private void AddDeadRows()
        {
            if (!RowsArePopulated) return;
            _rows.Insert(0, new());
            _rows.Add(new());
        }

        private void AddDeadColumnToTheLeft()
        {
            _rows.ForEach(row => row.InsertSingleDeadCell());
        }

        private void UpdateBoard()
        {
            var newRows = new List<Row>();
            for (var rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                newRows.Add(BuildNewRow(new RowPosition(rowIndex)));
            }

            _rows = newRows;
        }

        private Row BuildNewRow(RowPosition rowPosition)
        {
            var neighbouringRows = BuildNeighbouringRows(rowPosition);
            var newRow = _rows[rowPosition.Position].Tick(neighbouringRows);
            return newRow;
        }

        private NeighbouringRows BuildNeighbouringRows(RowPosition rowPosition)
        {
            var rowAbove = GetRowAtPosition(rowPosition.PositionAbove);
            var rowBelow = GetRowAtPosition(rowPosition.PositionBelow);

            var neighbouringRows = new NeighbouringRows(rowAbove, rowBelow);
            return neighbouringRows;
        }

        private Row GetRowAtPosition(RowPosition position)
        {
            if (position.Position >= 0 && position.Position < RowCount) return _rows[position.Position];
            return new Row();
        }

        private void RemoveDeadRows()
        {
            RemoveDeadRowFromTheTop();
            RemoveDeadRowFromTheBottom();
        }

        private void RemoveDeadRowFromTheTop()
        {
            while (RowsArePopulated && FirstRowIsDead)
            {
                RemoveFirstRow();
            }
        }
        private void RemoveDeadRowFromTheBottom()
        {
            while (RowsArePopulated && LastRowIsDead)
            {
                RemoveLastRow();
            }
        }

        private void RemoveFirstRow()
        {
            _rows.RemoveAt(0);
        }

        private void RemoveLastRow()
        {
            _rows.RemoveAt(RowCount - 1);
        }
    }
}
