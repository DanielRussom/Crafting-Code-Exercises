namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class Row 
    {
        private readonly List<Cell> _cells;

        public Row(List<Cell> cells)
        {
            _cells = cells;
        }

        public int GetCellCount()
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

        public bool Equals(Row other)
        {
            var isEqual = true;
            var index = 0;
            
            other.PadWithEmptyCells(GetCellCount());
            PadWithEmptyCells(other.GetCellCount());

            while (index < GetCellCount() && isEqual)
            {
                isEqual = _cells[index].Equals(other._cells[index]);
                index++;
            }

            return isEqual;
        }
    }
}
