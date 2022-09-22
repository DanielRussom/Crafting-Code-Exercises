namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Board
    {
        private readonly List<Row> _rows;

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public BoardEqualityState Equals(Board boardToCompare)
        {
            if (_rows.Count != boardToCompare._rows.Count) return BoardEqualityState.IsNotEqual;

            if (_rows.Count == 0)
            {
                return BoardEqualityState.IsEqual;
            }

            var isEqual = _rows[0].Equals(boardToCompare._rows[0]);

            if (_rows.Count > 1) 
            {
                isEqual &= _rows[1].Equals(boardToCompare._rows[1]);
            }

            return isEqual ? BoardEqualityState.IsEqual : BoardEqualityState.IsNotEqual;
        }
    }
}
