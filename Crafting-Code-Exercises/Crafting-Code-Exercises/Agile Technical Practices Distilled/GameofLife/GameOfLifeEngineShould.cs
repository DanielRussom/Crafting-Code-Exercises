using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    [TestClass]
    public class GameOfLifeEngineShould
    {
        [TestMethod]
        public void GenerateZeroByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<Row>());
            var gameOfLifeEngine = new GameOfLifeEngine(new List<Row>());

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(expectedBoard));
        }

        [TestMethod]
        public void FailEqualityCheckTwoSingleCellBoardsAreDifferent()
        {
            // 1
            var seed = new List<Row>
            {
                new(new List<Cell>
                {
                  new(true)
                })
            };

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
            var seed = new List<Row>
            {
                new(new List<Cell>
                {
                    new(true)
                })
            };

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
            var seed = new List<Row>
            {
                new(new List<Cell>
                {
                    new(true)
                })
            };

            //
            var boardToCompare = new Board(new List<Row>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAnEmptySeedAndAOneDimensionalBoard()
        {
            // 
            var seed = new List<Row>();
            
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
            var seed = new List<Row>
            {
                new (new List<Cell>
                {
                    new (true), new (true)
                })
            };

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
        [DataRow(new[] { true, true, true }, new[] { true, true, false}, BoardEqualityState.IsNotEqual)]
        [DataRow(new[] { true, true, true }, new[] { true, true, true}, BoardEqualityState.IsEqual)]
        [DataRow(new[] { true, false, true }, new[] { true, true, true}, BoardEqualityState.IsNotEqual)]
        public void CheckEqualityOfTheseBoards(bool[] seedData, bool[] boardToCompareData, BoardEqualityState expectedBoardEqualityState)
        {
            var seed = new List<Row>();
            var seedDataCells = seedData.Select(cellState => new Cell(cellState)).ToList();
            seed.Add(new Row(seedDataCells));

            var boardToCompareDataCells = boardToCompareData.Select(cellState => new Cell(cellState)).ToList();

            var boardToCompare = new Board(new List<Row> { new (boardToCompareDataCells) });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedBoardEqualityState, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }
    }
}
