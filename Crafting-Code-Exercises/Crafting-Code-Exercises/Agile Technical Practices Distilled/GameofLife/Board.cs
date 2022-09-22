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

        public BoardEqualityState Equals(Board boardToCompare)
        {
            if (GetRowCount() != boardToCompare.GetRowCount()) return BoardEqualityState.IsNotEqual;

            if (GetRowCount() == 0)
            {
                return BoardEqualityState.IsEqual;
            }

            var isEqual = _rows[0].Equals(boardToCompare._rows[0]);

            if (GetRowCount() > 1) 
            {
                isEqual &= _rows[1].Equals(boardToCompare._rows[1]);
            }

            if (GetRowCount() > 2)
            {
                isEqual &= _rows[2].Equals(boardToCompare._rows[2]);
            }

            return isEqual ? BoardEqualityState.IsEqual : BoardEqualityState.IsNotEqual;
        }
    }
}
