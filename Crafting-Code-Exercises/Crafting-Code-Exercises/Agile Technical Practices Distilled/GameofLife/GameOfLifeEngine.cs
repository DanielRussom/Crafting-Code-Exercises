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
            var newBoard = new Board(new List<Row>
            {
                new ( new() {new Cell(false), new Cell(false), new Cell(false) }),
                new ( new() {new Cell(false), new Cell(false), new Cell(false) }),
                new ( new() {new Cell(false), new Cell(false), new Cell(false) })
            });
            
            var numberOfLiveNeighboursForCentreCell = _board.GetNumberOfLiveNeighboursForCentreCell();
            if (numberOfLiveNeighboursForCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newBoard.SetCellState(1, 1, false);
            }
            
            if (numberOfLiveNeighboursForCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                var cellState = _board.Rows[1].Cells[1].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                if (cellState) newBoard.SetCellState(1, 1, true);
            }

            var numberOfLiveNeighboursForLeftCentreCell = _board.GetNumberOfLiveNeighboursForLeftCentreCell();
            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newBoard.SetCellState(0, 1, false);
            }

            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                var cellState = _board.Rows[1].Cells[0].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                if (cellState) newBoard.SetCellState(0, 1, true);
            }

            _board = newBoard;
        }
    }
}