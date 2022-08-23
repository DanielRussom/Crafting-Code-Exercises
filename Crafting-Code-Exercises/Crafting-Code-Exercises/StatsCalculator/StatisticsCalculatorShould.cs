using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Crafting_Code_Exercises.StatsCalculator
{
    [TestClass]
    public class StatisticsCalculatorShould
    {
        [TestMethod]
        [DataRow(new int[] { 6, 9, 15, -2, 92, 11 }, -2, DisplayName = "Get minimum value of -2 from sequence of numbers")]
        [DataRow(new int[] { -6, 9, 15, -2, 92, 11 }, -6, DisplayName = "Get minimum value of -6 from sequence of numbers")]
        [DataRow(new int[] { 6, 9, 15, 2, 92, 11 }, 2, DisplayName = "Get minimum value of 2 from sequence of numbers")]
        [DataRow(new int[] { }, -1, DisplayName = "Get minimum value of -1 from empty sequence of numbers")]
        public void Get_minimum_value_from_sequence_of_numbers(int[] sequenceAsArray, int expected)
        {
            var statisticsCalculator = new StatisticsCalculator();
            var sequence = sequenceAsArray.ToList();

            var sequenceStatistics = statisticsCalculator.GetStatistics(sequence);

            Assert.AreEqual(expected, sequenceStatistics.MinimumValue);
        }

        [TestMethod]
        [DataRow(new int[] { 6, 9, 15, -2, 92, 11 }, 92, DisplayName = "Get maximum value of 92 from sequence of numbers")]
        [DataRow(new int[] { 6, 9, 15, -2, 92, 110 }, 110, DisplayName = "Get maximum value of 110 from sequence of numbers")]
        [DataRow(new int[] { 600, 9, 15, 2, 92, 11 }, 600, DisplayName = "Get maximum value of 600 from sequence of numbers")]
        [DataRow(new int[] { }, -1, DisplayName = "Get maximum value of -1 from empty sequence of numbers")]
        public void Get_maximum_value_from_sequence_of_numbers(int[] sequenceAsArray, int expected)
        {
            var statisticsCalculator = new StatisticsCalculator();
            var sequence = sequenceAsArray.ToList();

            var sequenceStatistics = statisticsCalculator.GetStatistics(sequence);

            Assert.AreEqual(expected, sequenceStatistics.MaximumValue);
        }

        [TestMethod]
        [DataRow(new int[] { 6, 9, 15, -2, 92, 11 }, 6, DisplayName = "Get number of elements as 6 from sequence of numbers")]
        [DataRow(new int[] { 6, 9, 15, -2, 92 }, 5, DisplayName = "Get number of elements as 5 from sequence of numbers")]
        [DataRow(new int[] { 6, 9, 15, -2, 92, 1, 1 }, 7, DisplayName = "Get number of elements as 7 from sequence of numbers")]
        [DataRow(new int[] { }, 0, DisplayName = "Get number of elements as 0 from empty sequence of numbers")]

        public void Get_number_of_elements_in_sequence_of_numbers(int[] sequenceAsArray, int expected)
        {
            var statisticsCalculator = new StatisticsCalculator();
            var sequence = sequenceAsArray.ToList();

            var sequenceStatistics = statisticsCalculator.GetStatistics(sequence);

            Assert.AreEqual(expected, sequenceStatistics.NumberOfElements);
        }

        [TestMethod]
        [DataRow(new int[] { 6, 9, 15, -2, 92, 11 }, 21.833333, DisplayName = "Get average of elements as 21.833333 from sequence of numbers")]
        [DataRow(new int[] { 1, 2, 3 }, 2, DisplayName = "Get average of elements as 2 from sequence of numbers")]
        [DataRow(new int[] { }, -1, DisplayName = "Get average of elements as -1 from empty sequence of numbers")]
        public void Get_average_value_of_elements_from_sequence_of_numbers (int[] sequenceAsArray, double expected)
        {
            var statisticsCalculator = new StatisticsCalculator();
            var sequence = sequenceAsArray.ToList();

            var sequenceStatistics = statisticsCalculator.GetStatistics(sequence);

            Assert.AreEqual(expected, sequenceStatistics.AverageValue);
        }

        [TestMethod]
        public void Get_all_statistics_from_sequence_of_numbers()
        {
            var statisticsCalculator = new StatisticsCalculator();
            var sequence = new List<int> { 6, 9, 15, -2, 92, 11 };

            var sequenceStatistics = statisticsCalculator.GetStatistics(sequence);

            Assert.AreEqual(-2, sequenceStatistics.MinimumValue);
            Assert.AreEqual(92, sequenceStatistics.MaximumValue);
            Assert.AreEqual(6, sequenceStatistics.NumberOfElements);
            Assert.AreEqual(21.833333, sequenceStatistics.AverageValue);
        }
    }
}
