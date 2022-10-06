using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    [TestClass]
    public class GameOfLifeEngineShould
    {
        [TestMethod]
        // Zero rows vs Zero rows - IsEqual
        public void PassEqualityCheckForZeroByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<Row>());
            var gameOfLifeEngine = new GameOfLifeEngine(new Board(new List<Row>()));

            Assert.AreEqual(EqualityState.IsEqual, gameOfLifeEngine.BoardIsEqualTo(expectedBoard));
        }

        [TestMethod]
        // One row with zero cells vs One row with zero cells - IsEqual
        public void PassEqualityCheckForOneByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<Row> { new(new List<Cell>()) });
            var gameOfLifeEngine = new GameOfLifeEngine(new Board(new List<Row> { new(new List<Cell>()) }));

            Assert.AreEqual(EqualityState.IsEqual, gameOfLifeEngine.BoardIsEqualTo(expectedBoard));
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

            Assert.AreEqual(EqualityState.IsNotEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
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

            Assert.AreEqual(EqualityState.IsEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
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

            Assert.AreEqual(EqualityState.IsNotEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckForAOneDimensionalSeedAndAnEmptyBoard()
        {
            // 1
            var seed = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(false)
                })
            });

            //
            var boardToCompare = new Board(new List<Row>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(EqualityState.IsEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckForAnEmptySeedAndAOneDimensionalBoard()
        {
            // 1
            var seed = new Board(new List<Row>());

            //
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(false)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(EqualityState.IsEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckForAnEmptySeedAndATwoDimensionalBoard()
        {
            // 1
            var seed = new Board(new List<Row>());

            //
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(false)
                }),
                new(new List<Cell>())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(EqualityState.IsEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
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

            Assert.AreEqual(EqualityState.IsNotEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
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

            Assert.AreEqual(EqualityState.IsNotEqual, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 1 // [XX] vs [X ] - IsNotEqual
        [DataRow(new[] { true, true }, new[] { true, false }, EqualityState.IsNotEqual)]

        // Row 1 // [XX] vs [XX] - IsEqual
        [DataRow(new[] { true, true }, new[] { true, true }, EqualityState.IsEqual)]

        // Row 1 // [XX] vs [ X] - IsNotEqual
        [DataRow(new[] { true, true }, new[] { false, true }, EqualityState.IsNotEqual)]

        // Row 1 // [XX] vs [  ] - IsNotEqual
        [DataRow(new[] { true, true }, new[] { false, false }, EqualityState.IsNotEqual)]

        // Row 1 // [XXX] vs [XX ] - IsNotEqual
        [DataRow(new[] { true, true, true }, new[] { true, true, false }, EqualityState.IsNotEqual)]

        // Row 1 // [XXX] vs [XXX] - IsEqual
        [DataRow(new[] { true, true, true }, new[] { true, true, true }, EqualityState.IsEqual)]

        // Row 1 // [X X] vs [XXX] - IsNotEqual
        [DataRow(new[] { true, false, true }, new[] { true, true, true }, EqualityState.IsNotEqual)]
        public void CheckEqualityOfTheseSingleRowBoards(bool[] seedData, bool[] boardToCompareData, EqualityState expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(seedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompareDataCells = boardToCompareData.Select(cellState => new Cell(cellState)).ToList();

            var boardToCompare = new Board(new List<Row> { new(boardToCompareDataCells) });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 2 // [X]    [ ]
        // Row 1 // [X] vs [X] - IsNotEqual
        [DataRow(new[] { true }, new[] { true }, new[] { true }, new[] { false }, EqualityState.IsNotEqual, DisplayName = "1")]

        // Row 2 // [X]     [X ]
        // Row 1 // [X] vs  [X ] - IsEqual
        [DataRow(new[] { true }, new[] { true }, new[] { true, false }, new[] { true, false }, EqualityState.IsEqual, DisplayName = "2")]

        // Row 2 // [XX]    [X ]
        // Row 1 // [X] vs  [X ]  - IsNotEqual
        [DataRow(new[] { true }, new[] { true, true }, new[] { true, false }, new[] { true, false }, EqualityState.IsNotEqual, DisplayName = "3")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [XX] vs [XX] - IsEqual 
        [DataRow(new[] { true, true }, new[] { false, true }, new[] { true, true }, new[] { false, true }, EqualityState.IsEqual, DisplayName = "4")]

        // Row 2 // [XX]    [XX]
        // Row 1 // [X] vs  [X ] - IsEqual 
        [DataRow(new[] { true }, new[] { true, true }, new[] { true, false }, new[] { true, true }, EqualityState.IsEqual, DisplayName = "5")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X ] vs [X] - IsEqual 
        [DataRow(new[] { true, false }, new[] { false, true }, new[] { true }, new[] { false, true }, EqualityState.IsEqual, DisplayName = "6")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X] vs  [X ] - IsEqual 
        [DataRow(new[] { true }, new[] { false, true }, new[] { true, false }, new[] { false, true }, EqualityState.IsEqual, DisplayName = "7")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X] vs  [XX]  - IsNotEqual
        [DataRow(new[] { true }, new[] { false, true }, new[] { true, true }, new[] { false, true }, EqualityState.IsNotEqual, DisplayName = "8")]
        public void CheckEqualityOfTheseDoubleRowBoards(bool[] row1SeedData, bool[] row2SeedData,
            bool[] boardToCompareRow1, bool[] boardToCompareRow2, EqualityState expectedEqualityState)
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

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 1 // [X] vs [X] - IsNotEqual 
        // Row 2 // [X]    [X]
        // Row 3 // [X]    [ ]
        [DataRow(new[] { true }, new[] { true }, 
            new[] { true }, new[] { true }, 
            new[] { true }, new[] { false }, EqualityState.IsNotEqual, DisplayName = "1")]

        // Row 1 // [X X] vs [X X] - IsNotEqual 
        // Row 2 // [XXX]    [XXX]
        // Row 3 // [XX ]    [ X ]
        [DataRow(new[] { true, false, true }, new[] { true, false, true }, 
            new[] { true, true, true }, new[] { true, true, true }, 
            new[] { true, true, false }, new[] { false, true, false}, EqualityState.IsNotEqual, DisplayName = "2")]

        // Row 1 // [X X] vs [X X] - IsNotEqual 
        // Row 2 // [  X]    [XXX]
        // Row 3 // [ X ]    [ X ]
        [DataRow(new[] { true, false, true }, new[] { true, false, true }, 
            new[] { false, false, true}, new[] { true, true, true }, 
            new[] { false, true, false}, new[] { false, true, false}, EqualityState.IsNotEqual, DisplayName = "3")]

        // Row 1 // [  X] vs [X X] - IsNotEqual 
        // Row 2 // [  X]    [XXX]
        // Row 3 // [XX ]    [ X ]
        [DataRow(new[] { false, false, true, }, new[] { true, false, true }, 
            new[] { false, false, true }, new[] { true, true, true }, 
            new[] { true, true, false }, new[] { false, true, false }, EqualityState.IsNotEqual, DisplayName = "4")]

        // Row 1 // [ X ] vs [ X] - IsEqual 
        // Row 2 // [  X]    [  X]
        // Row 3 // [XX ]    [XX]
        [DataRow(new[] { false, true, false, }, new[] { false, true },
            new[] { false, false, true }, new[] { false, false, true },
            new[] { true, true, false }, new[] { true, true}, EqualityState.IsEqual, DisplayName = "5")]

        // Row 1 // [ X ] vs [ X] - IsEqual 
        // Row 2 // [  X]    [  X]
        // Row 3 // [XX ]    [XX]
        [DataRow(new[] { false, true, false, }, new[] { false, true },
            new[] { false, false, true }, new[] { false, false, true },
            new[] { true, true, false }, new[] { true, true }, EqualityState.IsEqual, DisplayName = "6")]
        public void CheckEqualityOfTheseTripleRowBoards(bool[] row1SeedData, bool[] boardToCompareRow1, 
            bool[] row2SeedData, bool[] boardToCompareRow2, 
            bool[] row3SeedData, bool[] boardToCompareRow3, EqualityState expectedEqualityState)
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

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 1 // [ X ] vs [ X] - IsNotEqual 
        // Row 2 // [  X]    [  X]
        // Row 3 // [XX ]   
        [DataRow(new[] { false, true, false, }, new[] { false, true },
            new[] { false, false, true }, new[] { false, false, true },
            new[] { true, true, false }, EqualityState.IsNotEqual, DisplayName = "FailEqualityOfThisThreeRowSeedVsTwoRowBoard")]
        public void FailEqualityOfThisThreeRowSeedVsTwoRowBoard(bool[] row1SeedData, bool[] boardToCompareRow1, 
            bool[] row2SeedData, bool[] boardToCompareRow2, 
            bool[] row3SeedData, EqualityState expectedEqualityState)
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
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 1 // [ X ] vs [ X] - IsNotEqual 
        // Row 2 // [  X]    [  X]
        // Row 3 //          [XX ]   
        [DataRow(new[] { false, true, false, }, new[] { false, true },
            new[] { false, false, true }, new[] { false, false, true },
            new[] { true, true, false }, EqualityState.IsNotEqual, DisplayName = "FailEqualityOfThisTwoRowSeedVsThreeRowBoard")]
        public void FailEqualityOfThisTwoRowSeedVsThreeRowBoard(bool[] row1SeedData, bool[] boardToCompareRow1, 
            bool[] row2SeedData, bool[] boardToCompareRow2, 
            bool[] boardToCompareRow3, EqualityState expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        [DataRow(new[] { true }, EqualityState.IsEqual, DisplayName = "ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstEmptyBoard")]
        public void ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstEmptyBoard(bool[] row1SeedData,
            EqualityState expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
            });

            var boardToCompare = new Board(new List<Row>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        [DataRow(new[] { true }, new[] { false }, EqualityState.IsEqual, DisplayName = "ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstFalse")]
        public void ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstFalse(bool[] row1SeedData, bool[] boardToCompareRow1,
            EqualityState expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 1 // [  X] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [   ]
        // Row 3 // [   ]    [   ]
        [DataRow(new[] { false, false, true, }, new[] { false, false, false },
            new[] { false, true, false }, new[] { false, false, false },
            new[] { false, false, false }, new[] { false, false, false }, EqualityState.IsEqual, DisplayName = "ApplyUnderPopulationRuleTo3By3SeedComparingAfterOneTick 1")]
        
        // Row 1 // [   ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [   ]
        // Row 3 // [   ]    [   ]
        [DataRow(new[] { false, false, false, }, new[] { false, false, false},
            new[] { false, true, false }, new[] { false, false, false },
            new[] { false, false, false }, new[] { false, false, false }, EqualityState.IsEqual, DisplayName = "ApplyUnderPopulationRuleTo3By3SeedComparingAfterOneTick 2")]
        public void ApplyUnderPopulationRuleTo3By3SeedComparingAfterOneTick(bool[] row1SeedData, bool[] boardToCompareRow1, 
            bool[] row2SeedData, bool[] boardToCompareRow2, 
            bool[] row3SeedData, bool[] boardToCompareRow3, EqualityState expectedEqualityState)
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
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }


        [TestMethod]
        // Row 1 // [  X] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [ X ]
        // Row 3 // [X  ]    [   ]
        [DataRow(new[] { false, false, true, }, new[] { false, false, false },
            new[] { false, true, false }, new[] { false, true, false },
            new[] { true, false, false }, new[] { false, false, false }, EqualityState.IsEqual, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 1")]
        
        // Row 1 // [X  ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [ X ]
        // Row 3 // [  X]    [   ]
        [DataRow(new[] { true, false, false, }, new[] { false, false, false },
            new[] { false, true, false }, new[] { false, true, false },
            new[] { false, false, true }, new[] { false, false, false }, EqualityState.IsEqual, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 2")]
        
        // Row 1 // [ X ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [ X ]
        // Row 3 // [ X ]    [   ]
        [DataRow(new[] { false, true, false, }, new[] { false, false, false },
            new[] { false, true, false }, new[] { false, true, false },
            new[] { false, true, false }, new[] { false, false, false }, EqualityState.IsEqual, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 3")]

        public void ApplySurvivalRuleTo3By3SeedComparingAfterOneTick(bool[] row1SeedData, bool[] boardToCompareRow1,
            bool[] row2SeedData, bool[] boardToCompareRow2,
            bool[] row3SeedData, bool[] boardToCompareRow3, EqualityState expectedEqualityState)
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
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }
    }
}
