using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        // Row 2 // [X]    [ ]
        // Row 1 // [X] vs [X]
        [DataRow(new[] { true }, new[] { true }, new[] { true }, new[] { false }, BoardEqualityState.IsNotEqual, DisplayName = "1")]

        // Row 2 // [X]     [X ]
        // Row 1 // [X] vs  [X ] 
        [DataRow(new[] { true }, new[] { true }, new[] { true, false }, new[] { true, false }, BoardEqualityState.IsEqual, DisplayName = "2")]

        // Row 2 // [XX]    [X ]
        // Row 1 // [X] vs  [X ] 
        [DataRow(new[] { true }, new[] { true, true }, new[] { true, false }, new[] { true, false }, BoardEqualityState.IsNotEqual, DisplayName = "3")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [XX] vs [XX] 
        [DataRow(new[] { true, true }, new[] { false, true }, new[] { true, true }, new[] { false, true }, BoardEqualityState.IsEqual, DisplayName = "4")]

        // Row 2 // [XX]    [XX]
        // Row 1 // [X] vs  [X ] 
        [DataRow(new[] { true }, new[] { true, true }, new[] { true, false }, new[] { true, true }, BoardEqualityState.IsEqual, DisplayName = "5")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X ] vs [X] 
        [DataRow(new[] { true, false }, new[] { false, true }, new[] { true }, new[] { false, true }, BoardEqualityState.IsEqual, DisplayName = "6")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X] vs  [X ] 
        [DataRow(new[] { true }, new[] { false, true }, new[] { true, false }, new[] { false, true }, BoardEqualityState.IsEqual, DisplayName = "7")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X] vs  [XX] 
        [DataRow(new[] { true }, new[] { false, true }, new[] { true, true }, new[] { false, true }, BoardEqualityState.IsNotEqual, DisplayName = "8")]
        public void CheckEqualityOfTheseDoubleRowBoards(bool[] row1SeedData, bool[] row2SeedData,
            bool[] boardToCompareRow1, bool[] boardToCompareRow2, BoardEqualityState expectedBoardEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedBoardEqualityState, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 3 // [X]    [ ]
        // Row 2 // [X]    [X]
        // Row 1 // [X] vs [X] 
        [DataRow(new[] { true }, new[] { true }, new[] { true }, new[] { true }, new[] { true }, new[] { false }, BoardEqualityState.IsNotEqual, DisplayName = "1")]
        public void CheckEqualityOfTheseTripleRowBoards(bool[] row1SeedData, bool[] row2SeedData, bool[] row3SeedData,
            bool[] boardToCompareRow1, bool[] boardToCompareRow2, bool[] boardToCompareRow3, BoardEqualityState expectedBoardEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedBoardEqualityState, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }
    }
}
