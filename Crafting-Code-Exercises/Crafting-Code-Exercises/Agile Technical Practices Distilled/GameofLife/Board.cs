﻿namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
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

        public EqualityState Equals(Board boardToCompare)
        {
            PadWithEmptyRows(boardToCompare.GetRowCount());
            boardToCompare.PadWithEmptyRows(GetRowCount());

            var index = 0;
            var isEqual = true;

            while (index < GetRowCount() && isEqual)
            {
                isEqual &= _rows[index].Equals(boardToCompare._rows[index]) == EqualityState.IsEqual;
                index++;
            }

            return isEqual ? EqualityState.IsEqual : EqualityState.IsNotEqual;
        }

        internal int GetNumberOfLiveNeighboursForCentreCell()
        {
            if (_rows.Count < 3) return 0;

            var neighourCount = 0;

            neighourCount += _rows[0].GetNumberOfLiveNeighboursForCentreCell();
            neighourCount += _rows[2].GetNumberOfLiveNeighboursForCentreCell();

            return neighourCount;
        }
    }
}
