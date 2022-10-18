namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class GameOfLifeEngine
    {
        private Board _board;

        public GameOfLifeEngine(Board seed)
        {
            _board = seed;
        }

        internal EqualityState BoardIsEqualTo(Board expectedBoard)
        {
            return _board.Equals(expectedBoard);
        }

        public void Tick()
        {
            var newRows = new List<Row>();

            for (var rowLoopCounter = 0; rowLoopCounter <= 2; rowLoopCounter++)
            {
                var newCellsRow = new List<Cell>();
                var newCellState = CellState.Dead;

                for (var columnLoopCounter = 0; columnLoopCounter <= 2; columnLoopCounter++)
                {
                    var numberOfLiveNeighboursForCell = _board.GetNumberOfLiveNeighboursForCell(new CellPosition(rowLoopCounter, columnLoopCounter));
                    if (numberOfLiveNeighboursForCell.GetPopulationState() == PopulationState.UnderPopulated)
                    {
                        newCellState = CellState.Dead;
                    }

                    if (numberOfLiveNeighboursForCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
                    {
                        var currentLeftCentreCellState = _board.Rows[rowLoopCounter].Cells[columnLoopCounter].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Remove this!!
                        newCellState = currentLeftCentreCellState;
                    }

                    newCellsRow.Add(new Cell(newCellState));
                }

                newRows.Add(new(newCellsRow));
            }

            var newBoard = new Board(newRows);
            _board = newBoard;
        }
    }
}