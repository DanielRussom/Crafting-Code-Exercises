namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private List<Row> _rows;
        public List<Row> Rows => _rows;

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public void Tick()
        {
            var newRows = new List<Row>();

            for (var rowLoopCounter = 0; rowLoopCounter < _rows.Count; rowLoopCounter++)
            {
                var rowAboveIndex = rowLoopCounter - 1;
                var rowBelowIndex = rowLoopCounter + 1;
                Row? rowAbove = null;
                Row? rowBelow = null;

                if (rowAboveIndex >= 0) rowAbove = _rows[rowAboveIndex];
                if (rowBelowIndex < _rows.Count) rowBelow = _rows[rowBelowIndex];
                var newRow = _rows[rowLoopCounter].Tick(new CellPosition(rowLoopCounter, -1), rowAbove, rowBelow);
                newRows.Add(newRow);
            }

            _rows = newRows;
        }
        
        private void PadWithEmptyRows(Board boardWithTargetSize)
        {
            while (_rows.Count < boardWithTargetSize._rows.Count)
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

            while (index < _rows.Count && isEqual)
            {
                isEqual &= _rows[index].Equals(boardToCompare._rows[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }
    }
}
