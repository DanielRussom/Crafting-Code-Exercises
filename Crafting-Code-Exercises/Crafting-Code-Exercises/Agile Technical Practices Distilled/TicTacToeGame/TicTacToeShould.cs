using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame
{
    [TestClass]
    public class TicTacToeShould
    {
        TicTacToe UnderTest;

        public TicTacToeShould()
        {
            UnderTest = new TicTacToe();
        }

        [TestMethod]
        public void Allow_X_to_play_first()
        {
            var result = UnderTest.PlaceCounter("X", 1, 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Prevent_O_from_playing_first()
        {
            var result = UnderTest.PlaceCounter("O", 1, 1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Allow_O_to_play_second()
        {
            UnderTest.PlaceCounter("X", 1, 1);

            var result = UnderTest.PlaceCounter("O", 2, 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Prevent_O_from_playing_twice_in_a_row()
        {
            UnderTest.PlaceCounter("X", 1, 1);
            UnderTest.PlaceCounter("O", 2, 1);

            var result = UnderTest.PlaceCounter("O", 2, 2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Prevent_X_from_playing_twice_in_a_row()
        {
            UnderTest.PlaceCounter("X", 1, 1);
            
            var result = UnderTest.PlaceCounter("X", 2, 2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Allow_X_then_O_to_play()
        {
            UnderTest.PlaceCounter("X", 1, 1);

            var result = UnderTest.PlaceCounter("O", 2, 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Allow_O_then_X_to_play()
        {
            UnderTest.PlaceCounter("X", 1, 1);
            UnderTest.PlaceCounter("O", 1, 2);

            var result = UnderTest.PlaceCounter("X", 2, 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Prevent_X_from_playing_on_a_played_position()
        {
            UnderTest.PlaceCounter("X", 1, 1);
            UnderTest.PlaceCounter("O", 1, 2);

            var result = UnderTest.PlaceCounter("X", 1, 1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Prevent_O_from_playing_on_a_played_position()
        {
            UnderTest.PlaceCounter("X", 1, 1);

            var result = UnderTest.PlaceCounter("O", 1, 1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 0)]
        public void Report_win_for_X_when_three_Xs_are_in_a_horizontal_row(int xYCoordinate, int oYCoordinate)
        {
            UnderTest.PlaceCounter("X", 0, xYCoordinate);
            UnderTest.PlaceCounter("O", 1, oYCoordinate);
            UnderTest.PlaceCounter("X", 1, xYCoordinate);
            UnderTest.PlaceCounter("O", 0, oYCoordinate);
            UnderTest.PlaceCounter("X", 2, xYCoordinate);

            var result = UnderTest.Winner;
            Assert.AreEqual("X", result);
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 0)]
        public void Report_win_for_X_when_three_Xs_are_in_a_vertical_row(int xXCoordinate, int oXCoordinate)
        {
            UnderTest.PlaceCounter("X", xXCoordinate, 0);
            UnderTest.PlaceCounter("O", oXCoordinate, 0);
            UnderTest.PlaceCounter("X", xXCoordinate, 1);
            UnderTest.PlaceCounter("O", oXCoordinate, 1);
            UnderTest.PlaceCounter("X", xXCoordinate, 2);

            var result = UnderTest.Winner;
            Assert.AreEqual("X", result);
        }
    }
}
