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

        public bool Equals(Row other)
        {
            var isEqual = true;
            var index = 0;

            while (other.GetCellCount() < GetCellCount())
            {
                other._cells.Add(new(false));
            }

            while (GetCellCount() < other.GetCellCount())
            {
                _cells.Add(new(false));
            }

            while (index < GetCellCount() && isEqual)
            {
                isEqual = GetCellCount() >= index + 1 && _cells[index].Equals(other._cells[index]);
                index++;
            }

            return isEqual;
        }
    }
}
