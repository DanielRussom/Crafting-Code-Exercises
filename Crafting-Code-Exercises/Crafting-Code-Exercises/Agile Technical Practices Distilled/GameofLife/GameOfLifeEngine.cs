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
            var numberOfLiveNeighboursForCell = _board.GetNumberOfLiveNeighboursForCell(new CellPosition(cellPosition.Row, cellPosition.Column));
            return numberOfLiveNeighboursForCell.GetPopulationState();
        }
    }
}