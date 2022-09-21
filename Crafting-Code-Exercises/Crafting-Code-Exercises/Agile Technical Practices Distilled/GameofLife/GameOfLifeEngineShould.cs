﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    [TestClass]
    public class GameOfLifeEngineShould
    {
        [TestMethod]
        public void PassEqualityCheckForZeroByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<Row>());
            var gameOfLifeEngine = new GameOfLifeEngine(new Board(new List<Row>()));

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(expectedBoard));
        }

        [TestMethod]
        public void PassEqualityCheckForOneByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<Row> { new(new List<Cell>()) });
            var gameOfLifeEngine = new GameOfLifeEngine(new Board(new List<Row> { new(new List<Cell>()) }));

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(expectedBoard));
        }

        [TestMethod]
        public void FailEqualityCheckTwoSingleCellBoardsAreDifferent()
        {
            // 1
            var seed = new Board((new List<Row>
            {
                new(new List<Cell>
                {
                  new(true)
                })
            }));

            // 0
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(false)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckTwoSingleCellBoardsAreTheSame()
        {
            // 1
            var seed = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(true)
                })
            });

            // 0
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(true)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAOneDimensionalSeedAndAnEmptyBoard()
        {
            // 1
            var seed = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(true)
                })
            });

            //
            var boardToCompare = new Board(new List<Row>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAnEmptySeedAndAOneDimensionalBoard()
        {
            // 
            var seed = new Board(new List<Row>());

            // 1
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>{new (true)})
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForTrueTrueVsFalse()
        {
            var seed = new Board(new List<Row>
            {
                new (new List<Cell>
                {
                    new (true), new (true)
                })
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(false)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        [DataRow(new[] { true, true }, new[] { true, false }, BoardEqualityState.IsNotEqual)]
        [DataRow(new[] { true, true }, new[] { true, true }, BoardEqualityState.IsEqual)]
        [DataRow(new[] { true, true }, new[] { false, true }, BoardEqualityState.IsNotEqual)]
        [DataRow(new[] { true, true }, new[] { false, false }, BoardEqualityState.IsNotEqual)]
        [DataRow(new[] { true, true, true }, new[] { true, true, false }, BoardEqualityState.IsNotEqual)]
        [DataRow(new[] { true, true, true }, new[] { true, true, true }, BoardEqualityState.IsEqual)]
        [DataRow(new[] { true, false, true }, new[] { true, true, true }, BoardEqualityState.IsNotEqual)]
        public void CheckEqualityOfTheseSingleRowBoards(bool[] seedData, bool[] boardToCompareData, BoardEqualityState expectedBoardEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(seedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompareDataCells = boardToCompareData.Select(cellState => new Cell(cellState)).ToList();

            var boardToCompare = new Board(new List<Row> { new(boardToCompareDataCells) });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedBoardEqualityState, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        [DataRow(new[] { true }, new[] { true }, new[] { true }, new[] { true }, BoardEqualityState.IsEqual)]
        public void CheckEqualityOfTheseDoubleRowBoards(bool[] row1SeedData, bool[] row2SeedData,
            bool[] boardToCompareRow1, bool[] boardToCompareData2, BoardEqualityState expectedBoardEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList())

            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareData2.Select(cellState => new Cell(cellState)).ToList())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedBoardEqualityState, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }
    }
}
