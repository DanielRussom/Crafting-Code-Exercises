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
    }
}
