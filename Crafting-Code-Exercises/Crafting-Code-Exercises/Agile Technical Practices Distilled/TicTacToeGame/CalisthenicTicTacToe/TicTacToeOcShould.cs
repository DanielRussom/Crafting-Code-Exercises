using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

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

            underTest.PlaceCounter(coordinate, player);
        }

        [TestMethod]
        public void Allow_X_to_play_first()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var player = new Player("X");

            underTest.PlaceCounter(coordinate, player);
        }

        [TestMethod]
        public void Allow_O_to_play_second()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            underTest.PlaceCounter(coordinate, new Player("X"));

            underTest.PlaceCounter(coordinate, new Player("O"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_X_from_playing_second()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            underTest.PlaceCounter(coordinate, playerX);

            underTest.PlaceCounter(coordinate, playerX);
        }

        [TestMethod]
        public void Allow_X_to_play_third()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            underTest.PlaceCounter(coordinate, playerX);
            underTest.PlaceCounter(coordinate, new Player("O"));

            underTest.PlaceCounter(coordinate, playerX);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_O_from_playing_third()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerO = new Player("O");
            underTest.PlaceCounter(coordinate, new Player("X"));
            underTest.PlaceCounter(coordinate, playerO);

            underTest.PlaceCounter(coordinate, playerO);
        }

        [TestMethod]
        public void Allow_O_to_play_fourth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(coordinate, playerX);
            underTest.PlaceCounter(coordinate, playerO);
            underTest.PlaceCounter(coordinate, playerX);

            underTest.PlaceCounter(coordinate, playerO);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_X_from_playing_fourth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(coordinate, playerX);
            underTest.PlaceCounter(coordinate, playerO);
            underTest.PlaceCounter(coordinate, playerX);

            underTest.PlaceCounter(coordinate, playerX);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Prevent_O_from_playing_fifth()
        {
            var underTest = new TicTacToeObjectCalisthenics();
            var coordinate = new Coordinate(0, 0);
            var playerX = new Player("X");
            var playerO = new Player("O");
            underTest.PlaceCounter(coordinate, playerX);
            underTest.PlaceCounter(coordinate, playerO);
            underTest.PlaceCounter(coordinate, playerX);
            underTest.PlaceCounter(coordinate, playerO);

            underTest.PlaceCounter(coordinate, playerO);
        }
    }
}
