using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Numerics;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    [TestClass]
    public class TicTacToeObjectCalisthenicsShould
    {
        [TestMethod]
        [ExpectedException (typeof(InvalidMoveException))] 
        public void Prevent_O_from_playing_first()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var player = new Player("O");

            underTest.PlaceCounter(new Move(player, coordinate));
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
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_X_from_playing_second()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            underTest.PlaceCounter(new Move(playerX, coordinate));

            underTest.PlaceCounter(new Move(playerX, coordinate));
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
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_O_from_playing_third()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(new Player("X"), new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));

            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 2)));
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
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_X_from_playing_fourth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));

            underTest.PlaceCounter(new Move(playerX, new Coordinate(1, 0)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_O_from_playing_fifth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 0)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(0, 1)));
            underTest.PlaceCounter(new Move(playerX, new Coordinate(0, 2)));
            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 0)));

            underTest.PlaceCounter(new Move(playerO, new Coordinate(2, 1)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_the_same_coordinates_being_twice_in_a_row()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(new Move(playerX, coordinate));

            underTest.PlaceCounter(new Move(playerO, coordinate));
        }
    }
}
