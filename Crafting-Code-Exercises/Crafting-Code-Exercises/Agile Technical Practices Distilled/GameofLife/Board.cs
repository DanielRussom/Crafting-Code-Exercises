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

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForCentreCell()
        {
            var neighbourCount = new LiveNeighbourCount(0);

            if (_rows.Count < 3) return neighbourCount;

            neighbourCount.IncrementBy(_rows[0].GetNumberOfLiveNeighboursForCentreCell());
            neighbourCount.IncrementBy(_rows[1].GetNumberOfLiveNeighboursForCentreCellInCentreRow());
            neighbourCount.IncrementBy(_rows[2].GetNumberOfLiveNeighboursForCentreCell());

            return neighbourCount;
        }
        
        internal LiveNeighbourCount GetNumberOfLiveNeighboursForLeftCentreCell()
        {
            var neighbourCount = new LiveNeighbourCount(0);

            if (_rows.Count < 3) return neighbourCount;

            neighbourCount.IncrementBy(_rows[0].GetNumberOfLiveNeighboursForLeftCentreCell());
            neighbourCount.IncrementBy(_rows[1].GetNumberOfLiveNeighboursForLeftCentreCellInCentreRow());
            neighbourCount.IncrementBy(_rows[2].GetNumberOfLiveNeighboursForLeftCentreCell());

            return neighbourCount;
        }

        public LiveNeighbourCount GetNumberOfLiveNeighboursForRightCentreCell()
        {
            var neighbourCount = new LiveNeighbourCount(0);

            if (_rows.Count < 3) return neighbourCount;

            neighbourCount.IncrementBy(_rows[0].GetNumberOfLiveNeighboursForRightCentreCell());
            neighbourCount.IncrementBy(_rows[1].GetNumberOfLiveNeighboursForRightCentreCellInCentreRow());
            neighbourCount.IncrementBy(_rows[2].GetNumberOfLiveNeighboursForRightCentreCell());

            return neighbourCount;
        }
    }
}
