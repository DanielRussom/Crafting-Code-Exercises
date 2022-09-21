namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class Board
    {
        private readonly List<Row> _rows;

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public BoardEqualityState Equals(Board boardToCompare)
        {
            if (_rows.Count != boardToCompare._rows.Count) return BoardEqualityState.IsNotEqual;

            if (_rows.Count == 0
                || _rows[0].GetCellCount() == 0
                || boardToCompare._rows.Count == 0
                || boardToCompare._rows[0].GetCellCount() == 0)
            {
                return BoardEqualityState.IsEqual;
            }

            var isEqual = _rows[0].Equals(boardToCompare._rows[0]);

            return isEqual ? BoardEqualityState.IsEqual : BoardEqualityState.IsNotEqual;
        }
    }
}
