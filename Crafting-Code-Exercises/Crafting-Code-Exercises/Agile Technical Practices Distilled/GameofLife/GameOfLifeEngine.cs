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
            var newCellsRow = new List<Cell>();
            var newCellState = CellState.Dead;

            var numberOfLiveNeighboursForLeftCentreCell = _board.GetNumberOfLiveNeighboursForLeftCentreCell();
            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newCellState = CellState.Dead;
            }

            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                var currentLeftCentreCellState = _board.Rows[1].Cells[0].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                newCellState = currentLeftCentreCellState;
            }

            newCellsRow.Add(new Cell(newCellState));

            var numberOfLiveNeighboursForCentreCell = _board.GetNumberOfLiveNeighboursForCentreCell();
            if (numberOfLiveNeighboursForCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newCellState = CellState.Dead;
            }

            if (numberOfLiveNeighboursForCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                var currentCentreCellState = _board.Rows[1].Cells[1].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                newCellState = currentCentreCellState;
            }

            newCellsRow.Add(new Cell(newCellState));

            var numberOfLiveNeighboursForRightCentreCell = _board.GetNumberOfLiveNeighboursForRightCentreCell();
            if (numberOfLiveNeighboursForRightCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newCellState = CellState.Dead;
            }

            if (numberOfLiveNeighboursForRightCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                var currentRightCentreCellState = _board.Rows[1].Cells[2].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                newCellState = currentRightCentreCellState;
            }

            newCellsRow.Add(new Cell(newCellState));

            var newBoard = new Board(new List<Row>
            {
                new ( new() {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead) }),
                new (newCellsRow),
                new ( new() {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead) })
            });

            _board = newBoard;
        }
    }
}