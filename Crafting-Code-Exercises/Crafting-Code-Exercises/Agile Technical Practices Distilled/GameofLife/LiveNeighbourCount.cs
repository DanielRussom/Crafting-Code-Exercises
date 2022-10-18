namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class LiveNeighbourCount
    {
        public LiveNeighbourCount(int value)
        {
            _value = value;
        }

        private int _value;

        public void IncrementBy(LiveNeighbourCount liveNeighbourCount)
        {
            _value += liveNeighbourCount._value;
        }

        public PopulationState GetPopulationState()
        {
            if (_value < 2) return PopulationState.UnderPopulated;
            if (_value == 2) return PopulationState.PerfectlyPopulated;
            if (_value == 3) return PopulationState.NewlyPopulated;
            return PopulationState.Default;
        }
    }
}
