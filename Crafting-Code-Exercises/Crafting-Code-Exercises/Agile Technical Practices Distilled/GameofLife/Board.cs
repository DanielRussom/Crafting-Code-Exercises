namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private List<Row> _rows;

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public void Tick()
        {
            var newRows = new List<Row>();

            for (var rowLoopCounter = 0; rowLoopCounter < _rows.Count; rowLoopCounter++)
            {
                var rowAbove = GetRowAtPosition(new(rowLoopCounter - 1));
                var rowBelow = GetRowAtPosition(new(rowLoopCounter + 1));

                var neighbouringRows = new NeighbouringRows(rowAbove, rowBelow);
                var newRow = _rows[rowLoopCounter].Tick(new (rowLoopCounter), neighbouringRows);
                newRows.Add(newRow);
            }

            _rows = newRows;
        }

        private Row GetRowAtPosition(RowPosition position)
        {
            if (position.Value >= 0 && position.Value < _rows.Count) return _rows[position.Value];
            return new Row(new List<Cell>());
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
