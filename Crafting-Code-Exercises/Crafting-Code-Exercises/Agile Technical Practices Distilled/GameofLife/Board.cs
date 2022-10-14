﻿using System.Data;

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
                
        internal void SetCellState(int xCoordinate, int yCoordinate, bool cellState)
        {
            _rows[yCoordinate].SetCellState(xCoordinate, cellState);
        }
    }
}
