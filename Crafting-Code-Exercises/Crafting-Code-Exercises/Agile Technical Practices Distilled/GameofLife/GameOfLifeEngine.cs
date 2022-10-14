﻿namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
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
            var newCellState = false;

            var numberOfLiveNeighboursForLeftCentreCell = _board.GetNumberOfLiveNeighboursForLeftCentreCell();
            if (numberOfLiveNeighboursForLeftCentreCell.GetPopulationState() == PopulationState.UnderPopulated)
            {
                newCellState = false;
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
                newCellState = false;
            }

            if (numberOfLiveNeighboursForCentreCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
            {
                var currentCentreCellState = _board.Rows[1].Cells[1].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                newCellState = currentCentreCellState;
            }

            newCellsRow.Add(new Cell(newCellState));

            var newBoard = new Board(new List<Row>
            {
                new ( new() {new Cell(false), new Cell(false), new Cell(false) }),
                new (newCellsRow),
                new ( new() {new Cell(false), new Cell(false), new Cell(false) })
            });

            _board = newBoard;
        }
    }
}