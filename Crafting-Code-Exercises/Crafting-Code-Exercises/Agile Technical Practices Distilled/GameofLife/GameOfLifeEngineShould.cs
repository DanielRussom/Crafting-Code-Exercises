﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    [TestClass]
    public class GameOfLifeEngineShould
    {
        [TestMethod]
        public void GenerateZeroByZeroDimensionBoardUsingEmptySeed()
        {
            var expectedBoard = new Board(new List<List<bool>>());
            var gameOfLifeEngine = new GameOfLifeEngine(new List<List<bool>>());

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(expectedBoard));
        }

        [TestMethod]
        public void FailEqualityCheckTwoSingleCellBoardsAreDifferent()
        {
            // 1
            var seed = new List<List<bool>>
            {
                new()
                {
                  true  
                }
            };

            // 0
            var boardToCompare = new Board(new List<List<bool>>
            {
                new()
                {
                    false
                }
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckTwoSingleCellBoardsAreTheSame()
        {
            // 1
            var seed = new List<List<bool>>
            {
                new()
                {
                    true
                }
            };

            // 0
            var boardToCompare = new Board(new List<List<bool>>
            {
                new()
                {
                    true
                }
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAOneDimensionalSeedAndAnEmptyBoard()
        {
            // 1
            var seed = new List<List<bool>>
            {
                new()
                {
                    true
                }
            };

            //
            var boardToCompare = new Board(new List<List<bool>>());

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForAnEmptySeedAndAOneDimensionalBoard()
        {
            // 
            var seed = new List<List<bool>>();
            
            // 1
            var boardToCompare = new Board(new List<List<bool>>
            {
                new() {true}
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void FailEqualityCheckForTrueTrueVsTrueFalse()
        {
            // 1
            var seed = new List<List<bool>>
            {
                new()
                {
                    true, true
                }
            };

            // 0
            var boardToCompare = new Board(new List<List<bool>>
            {
                new()
                {
                    true, false
                }
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }

        [TestMethod]
        public void PassEqualityCheckForTrueTrueVsTrueTrue()
        {
            // 1
            var seed = new List<List<bool>>
            {
                new()
                {
                    true, true
                }
            };

            // 0
            var boardToCompare = new Board(new List<List<bool>>
            {
                new()
                {
                    true, true
                }
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }


        [TestMethod]
        public void FailEqualityCheckForTrueTrueVsFalseTrue()
        {
            // 1
            var seed = new List<List<bool>>
            {
                new()
                {
                    true, true
                }
            };

            // 0
            var boardToCompare = new Board(new List<List<bool>>
            {
                new()
                {
                    false, true
                }
            });

            var gameOfLifeEngine = new GameOfLifeEngine(seed);

            Assert.AreEqual(BoardEqualityState.IsNotEqual, gameOfLifeEngine.IsBoardStateEqualTo(boardToCompare));
        }
    }
}
