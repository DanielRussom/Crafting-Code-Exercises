namespace Crafting_Code_Exercises.StatsCalculator
{
    public class StatisticsCalculator
    {
        public SequenceStatistics GetStatistics(List<int> sequence)
        {
            if (!sequence.Any())
            {
                return new SequenceStatistics
                {
                    NumberOfElements = 0,
                    MaximumValue = -1,
                    MinimumValue = -1,
                    AverageValue = -1
                };
            }
            
            return new SequenceStatistics { 
                NumberOfElements = sequence.Count,
                MaximumValue = sequence.Max(), 
                MinimumValue = sequence.Min(),
                AverageValue = Math.Round(sequence.Average(), 6)
            };
        }
    }
}