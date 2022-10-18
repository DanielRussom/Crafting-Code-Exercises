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
            var newCellState = CellState.Dead;
            var newRows = new List<Row>();

            for (var loopCounter = 0; loopCounter <= 2; loopCounter++)
            {
                var numberOfLiveNeighboursForCell = _board.GetNumberOfLiveNeighboursForCell(0, new ColumnPosition(loopCounter));
                if (numberOfLiveNeighboursForCell.GetPopulationState() == PopulationState.UnderPopulated)
                {
                    newCellState = CellState.Dead;
                }

                if (numberOfLiveNeighboursForCell.GetPopulationState() == PopulationState.PerfectlyPopulated)
                {
                    var currentLeftCentreCellState = _board.Rows[0].Cells[loopCounter].State; // Matt King 14/10/2022 - This is a temporary workaround to enable us to continue to defer moving to using a loop.  Ramove this!!
                    newCellState = currentLeftCentreCellState;
                }

                newCellsRow.Add(new Cell(newCellState));
            }

            // you are here - tests are passing - need to refactor the integer row position out then do next test of bottom row.

            newRows.Add(new (newCellsRow));
            newCellsRow = new List<Cell>();

            for (var loopCounter = 0; loopCounter <=2; loopCounter++)
            {
                var numberOfLiveNeighboursForCell = _board.GetNumberOfLiveNeighboursForCell(1, new ColumnPosition(loopCounter));
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

            newRows.Add(new(newCellsRow));

            var newBoard = new Board(newRows);
            _board = newBoard;
        }
    }
}