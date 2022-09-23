namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row 
    {
        private readonly List<Cell> _cells;

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        private int GetCellCount()
        {
            return _cells.Count;
        }

        private void PadWithEmptyCells(int upperLimit)
        {
            while (GetCellCount() < upperLimit)
            {
                _cells.Add(new(false));
            }
        }

        public EqualityState Equals(Row rowToCompare)
        {
            rowToCompare.PadWithEmptyCells(GetCellCount());
            PadWithEmptyCells(rowToCompare.GetCellCount());
            
            var index = 0;
            var isEqual = true;

            while (index < GetCellCount() && isEqual)
            {
                isEqual = _cells[index].Equals(rowToCompare._cells[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }
    }
}
