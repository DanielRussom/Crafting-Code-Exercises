namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class NeighbouringRows
    {
        private readonly Row _rowAbove;
        private readonly Row _rowBelow;

        internal NeighbouringRows(Row rowAbove, Row rowBelow)
        {
            _rowAbove = rowAbove;
            _rowBelow = rowBelow;
        }

        internal LiveNeighbourCount GetNumberOfLiveNeighboursForBorderingRow(CellPosition cellPosition)
        {
            var neighbourCount = _rowAbove.GetNumberOfLiveNeighboursForBorderingRow(cellPosition);
            neighbourCount.IncrementBy(_rowBelow.GetNumberOfLiveNeighboursForBorderingRow(cellPosition));
            return neighbourCount;
        }

        internal void PadRowWithEmptyCells(Row rowToBePadded)
        {
            rowToBePadded.PadWithEmptyCells(_rowAbove);
            rowToBePadded.PadWithEmptyCells(_rowBelow);
        }
    }
}
