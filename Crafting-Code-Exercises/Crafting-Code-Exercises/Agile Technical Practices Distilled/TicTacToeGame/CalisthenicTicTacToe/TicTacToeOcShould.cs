using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    [TestClass]
    public class TicTacToeObjectCalisthenicsShould
    {
        [TestMethod]
        public void Prevent_O_from_playing_first()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var player = new Player("O");

            var action = () => underTest.PlaceCounter(new Move(player, coordinate));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Player O is not allowed to play this turn", exception.Message);
        }

        [TestMethod]
        public void Allow_X_to_play_first()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var player = new Player("X");

            underTest.PlaceCounter(new Move(player, coordinate));
        }

        [TestMethod]
        public void Allow_O_to_play_second()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            underTest.PlaceCounter(new Move(new Player("X"), new Coordinate(0, 0)));

            underTest.PlaceCounter(new Move(new Player("O"), new Coordinate(0, 1)));
        }

        [TestMethod]
        public void Prevent_X_from_playing_second()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));

            var action = () => underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Player X is not allowed to play this turn", exception.Message);
        }

        [TestMethod]
        public void Allow_X_to_play_third()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(new Player("O"), new Coordinate(0, 1)));

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
        }

        [TestMethod]
        public void Prevent_O_from_playing_third()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(new Player("X"), new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));

            var action = () => underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Player O is not allowed to play this turn", exception.Message);
        }

        [TestMethod]
        public void Allow_O_to_play_fourth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));

            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 0)));
        }

        [TestMethod]
        public void Prevent_X_from_playing_fourth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));

            var action = () => underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Player X is not allowed to play this turn", exception.Message);
        }

        [TestMethod]
        public void Prevent_O_from_playing_fifth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 0)));

            var action = () => underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 1)));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Player O is not allowed to play this turn", exception.Message);
        }

        [TestMethod]
        public void Prevent_the_same_coordinates_being_played_twice_in_a_row()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, coordinate));

            var action = () => underTest.PlaceCounter(new Move(playerO, coordinate));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Coordinate {coordinate} already played", exception.Message);
        }

        [TestMethod]
        public void Prevent_the_same_coordinates_being_twice_a_turn_apart()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, coordinate));

            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            var action = () => underTest.PlaceCounter(new Move(playerX, coordinate));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Coordinate {coordinate} already played", exception.Message);
        }

        [TestMethod]
        public void Prevent_the_same_coordinates_being_twice_four_turns_apart()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var duplicateCoordinate = new Coordinate(2, 1);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, duplicateCoordinate));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));

            var action = () => underTest.PlaceCounter(new Move(playerX, duplicateCoordinate));

            var exception = Assert.ThrowsException<InvalidMoveException>(action);
            Assert.AreEqual($"Coordinate {duplicateCoordinate} already played", exception.Message);
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_horizontal_row_on_row_0()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 0)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_horizontal_row_on_row_1()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 1)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_horizontal_row_on_row_2()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_horizontal_row_on_row_0()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            var playerX = new Player("X");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 0)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_horizontal_row_on_row_1()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            var playerX = new Player("X");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 1)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_horizontal_row_on_row_2()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            var playerX = new Player("X");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_vertical_column_in_column_0()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_vertical_column_in_column_1()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_vertical_column_in_column_2()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_vertical_column_on_column_0()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            var playerX = new Player("X");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_vertical_column_on_column_1()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            var playerX = new Player("X");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_vertical_column_on_column_2()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            var playerX = new Player("X");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_diagonal_ascending_row()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_X_as_the_winner_when_they_have_3_in_a_diagonal_descending_row()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 0)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerX));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_diagonal_ascending_row()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 2)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }

        [TestMethod]
        public void Report_O_as_the_winner_when_they_have_3_in_a_diagonal_descending_row()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");

            underTest.PlaceCounter(new Move(playerX, new Coordinate(2, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(1, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 0)));

            Assert.IsTrue(underTest.IsPlayerWinner(playerO));
        }
    }
}
