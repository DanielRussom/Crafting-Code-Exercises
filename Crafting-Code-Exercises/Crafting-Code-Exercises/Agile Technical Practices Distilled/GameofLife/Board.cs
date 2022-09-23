namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private readonly List<Row> _rows;

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        private int GetRowCount()
        {
            return _rows.Count;
        }

        private void PadWithEmptyRows(int upperLimit)
        {
            while (GetRowCount() < upperLimit)
            {
                _rows.Add(new(new List<Cell>()));
            }
        }

        public BoardEqualityState Equals(Board boardToCompare)
        {
            PadWithEmptyRows(boardToCompare.GetRowCount());
            boardToCompare.PadWithEmptyRows(GetRowCount());

            var index = 0;
            var isEqual = true;

            while (index < GetRowCount())
            {
                isEqual &= _rows[index].Equals(boardToCompare._rows[index]);
                index++;
            }

            return isEqual ? BoardEqualityState.IsEqual : BoardEqualityState.IsNotEqual;
        }
    }
}
