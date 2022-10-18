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
                var newCellsRow = CreateNewRow(new CellPosition(rowLoopCounter, -1));
                newRows.Add(new(newCellsRow));
            }

            var newBoard = new Board(newRows);
            _board = newBoard;
        }

        private List<Cell> CreateNewRow(CellPosition cellPosition)
        {
            var newCellsRow = new List<Cell>();

            for (var columnLoopCounter = 0; columnLoopCounter <= 2; columnLoopCounter++)
            {
                var newCellState = CreateNewCell(new CellPosition(cellPosition.Row, columnLoopCounter));
                newCellsRow.Add(new Cell(newCellState));
            }

            return newCellsRow;
        }

        private CellState CreateNewCell(CellPosition cellPosition)
        {
            var newCellState = CellState.Dead;
            var numberOfLiveNeighboursForCell = _board.GetNumberOfLiveNeighboursForCell(new CellPosition(cellPosition.Row, cellPosition.Column));
            var populatedState = numberOfLiveNeighboursForCell.GetPopulationState();
            
            // Matt King 14/10/2022 - See if we can remove this at the end and rely on a default newCellState of Dead instead.
            if (populatedState == PopulationState.UnderPopulated)
            {
                newCellState = CellState.Dead;
            }

            var currentCellState = CellState.Dead;

            // Matt King 18/10/22 - Remove this check and push this logic down into the Get PopulationState method.
            if (_board.Rows.Count > cellPosition.Row &&
                _board.Rows[cellPosition.Row].Cells.Count > cellPosition.Column)
            {
                currentCellState = _board.Rows[cellPosition.Row].Cells[cellPosition.Column].State;
            }
            
            if (currentCellState == CellState.Dead && populatedState == PopulationState.NewlyPopulated)
            {
                newCellState = CellState.Alive;
                return newCellState;
            }

            if (populatedState == PopulationState.PerfectlyPopulated || populatedState == PopulationState.NewlyPopulated)
            {
                // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Remove this!!
                newCellState = currentCellState;
            }

            return newCellState;
        }
    }
}