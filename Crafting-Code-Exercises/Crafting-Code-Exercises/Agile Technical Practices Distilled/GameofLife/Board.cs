namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private readonly List<Row> _rows;
        public List<Row> Rows => _rows;

        public Board(List<Row> rows)
        {
            _rows = rows;
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

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForCell(CellPosition cellPosition)
        {
            var neighbourCount = new LiveNeighbourCount(0);

            if (_rows.Count < 3) return neighbourCount;

            var startRow = cellPosition.Row - 1;
            var endRow = cellPosition.Row + 1;

            if (startRow >= 0)
            {
                neighbourCount.IncrementBy(_rows[startRow].GetNumberOfLiveNeighboursForBorderingRow(cellPosition));
            }

            neighbourCount.IncrementBy(_rows[cellPosition.Row].GetNumberOfLiveNeighboursForContainingRow(cellPosition));
            neighbourCount.IncrementBy(_rows[endRow].GetNumberOfLiveNeighboursForBorderingRow(cellPosition));

            return neighbourCount;
        }
    }
}
