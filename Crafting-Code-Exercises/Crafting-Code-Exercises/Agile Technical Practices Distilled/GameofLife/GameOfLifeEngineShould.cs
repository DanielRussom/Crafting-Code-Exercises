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

            Assert.AreEqual(true, gameOfLifeEngine.BoardIsEqualTo(expectedBoard));
        }

        [TestMethod]
        // One row with zero cells vs One row with zero cells - IsEqual
        public void PassEqualityCheckForOneByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<Row> { new(new List<Cell>()) });
            var gameOfLifeEngine = new GameOfLifeEngine(new Board(new List<Row> { new(new List<Cell>()) }));

            Assert.AreEqual(true, gameOfLifeEngine.BoardIsEqualTo(expectedBoard));
        }

        [TestMethod]
        public void FailEqualityCheckTwoSingleCellBoardsAreDifferent()
        {
            // 1
            var seed = new Board((new List<Row>
            {
                new(new List<Cell>
                {
                  new(CellState.Alive)
                })
            }));

            // 0
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(CellState.Dead)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(false, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckTwoSingleCellBoardsAreTheSame()
        {
            // 1
            var seed = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(CellState.Alive)
                })
            });

            // 0
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(CellState.Alive)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(true, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAOneDimensionalSeedAndAnEmptyBoard()
        {
            // 1
            var seed = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(CellState.Alive)
                })
            });

            //
            var boardToCompare = new Board(new List<Row>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(false, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckForAOneDimensionalSeedAndAnEmptyBoard()
        {
            // 1
            var seed = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(CellState.Dead)
                })
            });

            //
            var boardToCompare = new Board(new List<Row>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(true, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
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
                    new(CellState.Dead)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(true, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
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
                    new(CellState.Dead)
                }),
                new(new List<Cell>())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(true, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAnEmptySeedAndAOneDimensionalBoard()
        {
            // 
            var seed = new Board(new List<Row>());

            // 1
            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>{new(CellState.Alive)})
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(false, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForTrueTrueVsFalse()
        {
            var seed = new Board(new List<Row>
            {
                new (new List<Cell>
                {
                    new(CellState.Alive), new(CellState.Alive)
                })
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(new List<Cell>
                {
                    new(CellState.Dead)
                })
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(false, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        [TestMethod]
        // Row 1 // [XX] vs [X ] - IsNotEqual
        [DataRow(new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Dead }, false)]

        // Row 1 // [XX] vs [XX] - IsEqual
        [DataRow(new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive }, true)]

        // Row 1 // [XX] vs [ X] - IsNotEqual
        [DataRow(new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, false)]

        // Row 1 // [XX] vs [  ] - IsNotEqual
        [DataRow(new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Dead }, false)]

        // Row 1 // [XXX] vs [XX ] - IsNotEqual
        [DataRow(new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Dead }, false)]

        // Row 1 // [XXX] vs [XXX] - IsEqual
        [DataRow(new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive }, true)]

        // Row 1 // [X X] vs [XXX] - IsNotEqual
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive }, false)]
        public void CheckEqualityOfTheseSingleRowBoards(CellState[] seedData, CellState[] boardToCompareData, bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Alive }, new[] { CellState.Alive }, new[] { CellState.Dead }, false, DisplayName = "1")]

        // Row 2 // [X]     [X ]
        // Row 1 // [X] vs  [X ] - IsEqual
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Alive }, new[] { CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Dead }, true, DisplayName = "2")]

        // Row 2 // [XX]    [X ]
        // Row 1 // [X] vs  [X ]  - IsNotEqual
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Dead }, false, DisplayName = "3")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [XX] vs [XX] - IsEqual 
        [DataRow(new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, true, DisplayName = "4")]

        // Row 2 // [XX]    [XX]
        // Row 1 // [X] vs  [X ] - IsEqual 
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Alive }, true, DisplayName = "5")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X ] vs [X] - IsEqual 
        [DataRow(new[] { CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive }, new[] { CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, true, DisplayName = "6")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X] vs  [X ] - IsEqual 
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive }, true, DisplayName = "7")]

        // Row 2 // [ X]    [ X]
        // Row 1 // [X] vs  [XX]  - IsNotEqual
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive }, false, DisplayName = "8")]
        public void CheckEqualityOfTheseDoubleRowBoards(CellState[] row1SeedData, CellState[] row2SeedData,
            CellState[] boardToCompareRow1, CellState[] boardToCompareRow2, bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Alive }, 
            new[] { CellState.Alive }, new[] { CellState.Alive }, 
            new[] { CellState.Alive }, new[] { CellState.Dead }, false, DisplayName = "1")]

        // Row 1 // [X X] vs [X X] - IsNotEqual 
        // Row 2 // [XXX]    [XXX]
        // Row 3 // [XX ]    [ X ]
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Dead, CellState.Alive }, 
            new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive }, 
            new[] { CellState.Alive, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead}, false, DisplayName = "2")]

        // Row 1 // [X X] vs [X X] - IsNotEqual 
        // Row 2 // [  X]    [XXX]
        // Row 3 // [ X ]    [ X ]
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Dead, CellState.Alive }, 
            new[] { CellState.Dead, CellState.Dead, CellState.Alive}, new[] { CellState.Alive, CellState.Alive, CellState.Alive }, 
            new[] { CellState.Dead, CellState.Alive, CellState.Dead}, new[] { CellState.Dead, CellState.Alive, CellState.Dead}, false, DisplayName = "3")]

        // Row 1 // [  X] vs [X X] - IsNotEqual 
        // Row 2 // [  X]    [XXX]
        // Row 3 // [XX ]    [ X ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Alive, }, new[] { CellState.Alive, CellState.Dead, CellState.Alive }, 
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive }, 
            new[] { CellState.Alive, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead }, false, DisplayName = "4")]

        // Row 1 // [ X ] vs [ X] - IsEqual 
        // Row 2 // [  X]    [  X]
        // Row 3 // [XX ]    [XX]
        [DataRow(new[] { CellState.Dead, CellState.Alive, CellState.Dead, }, new[] { CellState.Dead, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Alive}, true, DisplayName = "5")]

        // Row 1 // [ X ] vs [ X] - IsEqual 
        // Row 2 // [  X]    [  X]
        // Row 3 // [XX ]    [XX]
        [DataRow(new[] { CellState.Dead, CellState.Alive, CellState.Dead, }, new[] { CellState.Dead, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Alive }, true, DisplayName = "6")]
        public void CheckEqualityOfTheseTripleRowBoards(CellState[] row1SeedData, CellState[] boardToCompareRow1, 
            CellState[] row2SeedData, CellState[] boardToCompareRow2, 
            CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Dead, CellState.Alive, CellState.Dead, }, new[] { CellState.Dead, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Dead }, false, DisplayName = "FailEqualityOfThisThreeRowSeedVsTwoRowBoard")]
        public void FailEqualityOfThisThreeRowSeedVsTwoRowBoard(CellState[] row1SeedData, CellState[] boardToCompareRow1, 
            CellState[] row2SeedData, CellState[] boardToCompareRow2, 
            CellState[] row3SeedData, bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Dead, CellState.Alive, CellState.Dead, }, new[] { CellState.Dead, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Dead }, false, DisplayName = "FailEqualityOfThisTwoRowSeedVsThreeRowBoard")]
        public void FailEqualityOfThisTwoRowSeedVsThreeRowBoard(CellState[] row1SeedData, CellState[] boardToCompareRow1, 
            CellState[] row2SeedData, CellState[] boardToCompareRow2, 
            CellState[] boardToCompareRow3, bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Alive }, true, DisplayName = "ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstEmptyBoard")]
        public void ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstEmptyBoard(CellState[] row1SeedData,
            bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Alive }, new[] { CellState.Dead }, true, DisplayName = "ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstCellState.Dead")]
        public void ApplyUnderPopulationRuleToASingleCellSeedComparingAgainstFalse(CellState[] row1SeedData, CellState[] boardToCompareRow1,
            bool expectedEqualityState)
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
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Alive, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead }, true, DisplayName = "ApplyUnderPopulationRuleTo3By3SeedComparingAfterOneTick 1")]
        
        // Row 1 // [   ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [   ]
        // Row 3 // [   ]    [   ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead},
            new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead }, true, DisplayName = "ApplyUnderPopulationRuleTo3By3SeedComparingAfterOneTick 2")]
        public void ApplyUnderPopulationRuleTo3By3SeedComparingAfterOneTick(CellState[] row1SeedData, CellState[] boardToCompareRow1, 
            CellState[] row2SeedData, CellState[] boardToCompareRow2, 
            CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
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
        // Row 1 // [   ] vs [ X ] - IsEqual after one tick
        // Row 2 // [XXX]    [ X ]
        // Row 3 // [   ]    [ X ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead }, 
            true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 4")]

        public void ApplySurvivalRuleTo3By3SeedComparingAfterOneTick3RowsExpected(CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
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

        // Row 1 // [  X] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [ X ]
        // Row 3 // [X  ]    [   ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Alive, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
    new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
    new[] { CellState.Alive, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead }, true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 1")]

        // Row 1 // [X  ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [ X ]
        // Row 3 // [  X]    [   ]
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
    new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
    new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Dead }, true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 2")]

        // Row 1 // [ X ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [XXX]
        // Row 3 // [ X ]    [   ]
        [DataRow(new[] { CellState.Dead, CellState.Alive, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
    new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Alive, CellState.Alive },
    new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead }, true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 3")]

        [TestMethod]
        public void ApplySurvivalRuleTo3By3SeedComparingAfterOneTickOneRowExpected(CellState[] row1SeedData, CellState[] boardToCompareRow1,
    CellState[] row2SeedData, CellState[] boardToCompareRow2,
    CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 1 // [   ] vs [   ] - IsEqual after one tick
        // Row 2 // [ XX]    [ X ]
        // Row 3 // [X  ]    [ X ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
    new[] { CellState.Dead, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
    new[] { CellState.Alive, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead }, true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 5")]

        // Row 1 // [   ] vs [   ] - IsEqual after one tick
        // Row 2 // [ X ]    [ X ]
        // Row 3 // [X X]    [ X ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
    new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
    new[] { CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead }, true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterOneTick 6")]

        [TestMethod]
        public void ApplySurvivalRuleTo3By3SeedComparingAfterOneTickTwoRowsExpected(CellState[] row1SeedData, CellState[] boardToCompareRow1,
    CellState[] row2SeedData, CellState[] boardToCompareRow2,
    CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 1 // [X X] vs [ X ] - IsEqual after one tick
        // Row 2 // [ X ]    [X X]
        // Row 3 // [X X]    [ X ]
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Alive, }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead }, true, DisplayName = "ApplyOverPopulationRuleTo3By3SeedComparingAfterOneTick 1")]

        // Row 1 // [XX ] vs [X X] - IsEqual after one tick
        // Row 2 // [XXX]    [X X]
        // Row 3 // [   ]    [ X ]
        [DataRow(new[] { CellState.Alive, CellState.Alive, CellState.Dead, }, new[] { CellState.Alive, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Dead, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },true, DisplayName = "ApplyOverPopulationRuleTo3By3SeedComparingAfterOneTick 2")]

        [TestMethod]
        public void ApplyOverPopulationRuleTo3By3SeedComparingAfterOneTick(CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
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

        // Row 1 // [  X] vs      - IsEqual after one tick
        // Row 2 // [   ]    [ X ]
        // Row 3 // [X X]    
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Alive, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Dead }, true, DisplayName = "ApplyNewPopulationRuleTo3By3SeedComparingAfterOneTick 1")]

        [TestMethod]
        public void ApplyNewPopulationRuleTo3By3SeedComparingAfterOneTick(CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 1 // [X  X] vs [ XX ] - IsEqual after one tick
        // Row 2 // [ XX ]    [X  X]
        // Row 3 // [ XX ]    [   X]
        // Row 4 // [XX X]    [XX  ]
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead }, new[] { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive },
            new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyRulesTo4By4SeedComparingAfterOneTick 2")]

        [TestMethod]
        public void ApplyRulesTo4By4SeedComparingAfterOneTick2(
            CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
            CellState[] row4SeedData, CellState[] boardToCompareRow4,
            bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row4SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow4.Select(cellState => new Cell(cellState)).ToList())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }


        // Row 1 // [  X ] vs        - IsEqual after one tick
        // Row 2 // [    ]    [ X  ]
        // Row 3 // [X X ]    
        // Row 3 // [    ]    
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead, CellState.Dead },
            new[] { CellState.Alive, CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyRulesTo4By4SeedComparingAfterOneTick 1")]

        [TestMethod]
        public void ApplyRulesTo4By4SeedComparingAfterOneTick1(
            CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
            CellState[] row4SeedData, CellState[] boardToCompareRow4,
            bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row4SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }
        
        // Row 1 // [   ] vs [ X ] - IsEqual after one tick
        // Row 2 // [   ]    [ X ]
        // Row 3 // [XXX]    [ X ]
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
                                                                        new[] { CellState.Dead, CellState.Alive, CellState.Dead }, 
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickExpandingDownwards 1")]

        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickExpandingDownwards(CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3, CellState[] boardToCompareRow4, bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow4.Select(cellState => new Cell(cellState)).ToList())
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 1 // [  X] vs       - IsEqual after one tick
        // Row 2 // [  X]    [ XXX]
        // Row 3 // [  X]    
        [DataRow(new[] { CellState.Dead, CellState.Dead, CellState.Alive, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickExpandingToTheRight 1")]

        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickExpandingToTheRight
            (CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3, 
            bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 1 // [X  ] vs       - IsEqual after one tick
        // Row 2 // [X  ]    [XXX]
        // Row 3 // [X  ]    
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Dead, }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Alive, CellState.Dead, CellState.Dead }, new[] { CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickExpandingToTheLeft 1")]

        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickExpandingToTheLeft
        (CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
            bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 0 //          [ X ]
        // Row 1 // [XXX]    [ X ]
        // Row 2 // [   ] vs [ X ] - IsEqual after one tick
        // Row 3 // [   ]    [   ]

        [DataRow(                                                                new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickExpandingUpwards 1")]

        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickExpandingUpwards(
            
                                      CellState[] boardToCompareRow0,
            CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
                                      bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow0.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 0 //           [ X ]
        // Row 1 // [ XXX]    [ X ]
        // Row 2 // [    ] vs [ X ] - IsEqual after one tick
        // Row 3 // [    ]    [   ]

        [DataRow(                                                                new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickTo4By3BoardExpandingUpwards 1")]

        // Row 0 //           [ XX]
        // Row 1 // [XXXX]    [ XX]
        // Row 2 // [    ] vs [ XX] - IsEqual after one tick
        // Row 3 // [    ]    [   ]

        [DataRow(                                                                 new[] { CellState.Dead, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Dead },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickTo4By3BoardExpandingUpwards 1")]

        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickTo4By3BoardExpandingUpwards(

                                      CellState[] boardToCompareRow0,
            CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
                                      bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow0.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 0 // [X  X]    
        // Row 1 // [X  X]    [XXXXXX]
        // Row 2 // [X  X] vs [XXXXXX] - IsEqual after one tick
        // Row 3 // [X  X]   
        
        [DataRow(new[] { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead },
            new[] { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead } ,
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickOn4By4BoardExpandingLeftAndRight 1")]
        
        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickOn4By4BoardExpandingLeftAndRight(
        
            CellState[] row0SeedData, CellState[] boardToCompareRow0,
            CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
                                      bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row0SeedData.Select(cellState => new Cell(cellState)).ToList()),
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
            gameOfLifeEngine.Tick();
        
            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 0 //           [ XX ]
        // Row 1 // [XXXX]    [ XX ]
        // Row 2 // [    ]    [ XX ]
        // Row 3 // [    ] vs [ XX ] - IsEqual after one tick
        // Row 4 // [XXXX]    [ XX ]
        // Row 5 //           [ XX ]
        [DataRow(                                                                               new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
                                                                                          new[] { CellState.Dead, CellState.Alive, CellState.Alive, CellState.Dead },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickOn4By4BoardExpandingUpwardsAndDownwards 1")]

        // Row 0 //               [XXXXXX]
        // Row 1 // [XXXXXXXX]    [XXXXXX]
        // Row 2 // [        ]    [XXXXXX]
        // Row 3 // [        ] vs [XXXXXX] - IsEqual after one tick
        // Row 4 // [XXXXXXXX]    [XXXXXX]
        // Row 5 //               [XXXXXX]

        [DataRow(                                                                                                                                                     new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[]  { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
                                                                                                                                                              new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickOnForcingUsToChangeOurPaddingOfADeadRowToMoreThanThreeCells 1")]

        // Row 0 //               [XXXXXX]
        // Row 1 // [XXXXXXXX]    [XXXXXX]
        // Row 2 // [    ]        [XXXXXX]
        // Row 3 // [    ]     vs [XXXXXX] - IsEqual after one tick
        // Row 4 // [XXXXXXXX]    [XXXXXX]
        // Row 5 //               [XXXXXX]

        [DataRow(new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive, CellState.Alive },
            true, DisplayName = "ApplyExpansionRuleComparingAfterOneTickOnForcingUsToChangeOurPaddingOfADeadRowToMoreThanThreeCells 2")]


        [TestMethod]
        public void ApplyExpansionRuleComparingAfterOneTickExpandingUpwardsAndDownwards(
                                      CellState[] boardToCompareRow0,
            CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3,
            CellState[] row4SeedData, CellState[] boardToCompareRow4,
                                      CellState[] boardToCompareRow5,
                                      bool expectedEqualityState)
        {
            var seed = new Board(new List<Row>
            {
                new(row1SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row2SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row3SeedData.Select(cellState => new Cell(cellState)).ToList()),
                new(row4SeedData.Select(cellState => new Cell(cellState)).ToList())
            });

            var boardToCompare = new Board(new List<Row>
            {
                new(boardToCompareRow0.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow1.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow2.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow3.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow4.Select(cellState => new Cell(cellState)).ToList()),
                new(boardToCompareRow5.Select(cellState => new Cell(cellState)).ToList()),
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

        // Row 1 // [ X ] vs [X  ] - IsEqual after one tick
        // Row 2 // [  X]    [ XX]
        // Row 3 // [XXX]    [XX ]
        [DataRow(new[] { CellState.Dead, CellState.Alive, CellState.Dead, }, new[] { CellState.Alive, CellState.Dead, CellState.Dead },
            new[] { CellState.Dead, CellState.Dead, CellState.Alive }, new[] { CellState.Dead, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Alive, CellState.Alive }, new[] { CellState.Alive, CellState.Alive, CellState.Dead }, 
            true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterThreeTick 1")]
        
        // Row 1 // [XXX] vs [ XX] - IsEqual after one tick
        // Row 2 // [X  ]    [XX ]
        // Row 3 // [ X ]    [  X]
        [DataRow(new[] { CellState.Alive, CellState.Alive, CellState.Alive, }, new[] { CellState.Dead, CellState.Alive, CellState.Alive },
            new[] { CellState.Alive, CellState.Dead, CellState.Dead }, new[] { CellState.Alive, CellState.Alive, CellState.Dead },
            new[] { CellState.Dead, CellState.Alive, CellState.Dead }, new[] { CellState.Dead, CellState.Dead, CellState.Alive },
            true, DisplayName = "ApplySurvivalRuleTo3By3SeedComparingAfterThreeTick 2")]

        [TestMethod]
        public void ApplySurvivalRuleTo3By3SeedComparingAfterThreeTick(CellState[] row1SeedData, CellState[] boardToCompareRow1,
            CellState[] row2SeedData, CellState[] boardToCompareRow2,
            CellState[] row3SeedData, CellState[] boardToCompareRow3, bool expectedEqualityState)
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
            gameOfLifeEngine.Tick();
            gameOfLifeEngine.Tick();

            Assert.AreEqual(expectedEqualityState, gameOfLifeEngine.BoardIsEqualTo(boardToCompare));
        }

    }
}
