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

            for (var loopCounter = 0; loopCounter <=2; loopCounter++)
            {
                var numberOfLiveNeighboursForCell = _board.GetNumberOfLiveNeighboursForCell(new ColumnPosition(loopCounter));
                if (numberOfLiveNeighboursForCell.GetPopulationState() == PopulationState.UnderPopulated)
                {
                    newCellState = CellState.Dead;
                }

                if (numberOfLiveNeighboursForCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
                {
                    var currentLeftCentreCellState = _board.Rows[1].Cells[loopCounter].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                    newCellState = currentLeftCentreCellState;
                }

                newCellsRow.Add(new Cell(newCellState));
            }

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