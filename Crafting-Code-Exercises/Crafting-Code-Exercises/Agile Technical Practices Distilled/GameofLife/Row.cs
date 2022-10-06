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

        public LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCell()
        {
            var neighourCount = 0;
            var loopCounter = 0;

            while (loopCounter <= 2)
            {
                if (_cells[loopCounter].Equals(new(true)) == EqualityState.IsEqual) neighourCount++;
                loopCounter++;
            }

            return new LiveNeighbourCount(neighourCount);
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCellInCentreRow()
        {
            var neighourCount = 0;

            if (_cells[0].Equals(new(true)) == EqualityState.IsEqual) neighourCount++;
            if (_cells[2].Equals(new(true)) == EqualityState.IsEqual) neighourCount++;

            return new LiveNeighbourCount(neighourCount);
        }
    }
}
