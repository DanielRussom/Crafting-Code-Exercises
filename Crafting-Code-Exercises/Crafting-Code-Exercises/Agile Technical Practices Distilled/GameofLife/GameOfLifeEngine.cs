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
                newBoard.SetCellState(1, 1, true);
            }

            var numberOfLiveNeighboursForLeftCentreCell = _board.GetNumberOfLiveNeighboursForLeftCentreCell();
            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newBoard.SetCellState(0, 1, false);
            }

            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                newBoard.SetCellState(0, 1, true);
            }

            _board = newBoard;
        }
    }
}