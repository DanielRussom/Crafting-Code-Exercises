namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private List<Row> _rows;

        private int RowCount => _rows.Count;
        private bool RowsArePopulated => RowCount > 0;
        private bool FirstRowIsDead => _rows[0].IsDead();
        private bool LastRowIsDead => _rows[^1].IsDead();

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

        private void RemoveDeadColumnsFromTheLeft()
        {
            var populatedRows = GetPopulatedRows();

            while (populatedRows.Any() && populatedRows.All(row => row.IsFirstColumnDead()))
            {
                _rows.ForEach(row => row.RemoveDeadColumn());
                populatedRows = GetPopulatedRows();
            }
        }

        private List<Row> GetPopulatedRows()
        {
            return _rows.Where(row => row.IsPopulated()).ToList();
        }

        private void AddDeadColumnToTheLeft()
        {
            _rows.ForEach(row => row.AddDeadColumn());
        }

        private void AddDeadRows()
        {
            if (!RowsArePopulated) return;
            _rows.Insert(0, new());
            _rows.Add(new());
        }

        private Row GetRowAtPosition(RowPosition position)
        {
            if (position.Position >= 0 && position.Position < RowCount) return _rows[position.Position];
            return new Row();
        }

        private void PadWithEmptyRows(Board boardWithTargetSize)
        {
            while (RowCount < boardWithTargetSize.RowCount)
            {
                _rows.Add(new());
            }
        }

        public bool Equals(Board boardToCompare)
        {
            PadWithEmptyRows(boardToCompare);
            boardToCompare.PadWithEmptyRows(this);

            RemoveDeadColumnsFromTheLeft();
            boardToCompare.RemoveDeadColumnsFromTheLeft();

            var index = 0;
            var isEqual = true;

            while (index < RowCount && isEqual)
            {
                isEqual &= _rows[index].Equals(boardToCompare._rows[index]);
                index++;
            }

            return isEqual;
        }
    }
}
