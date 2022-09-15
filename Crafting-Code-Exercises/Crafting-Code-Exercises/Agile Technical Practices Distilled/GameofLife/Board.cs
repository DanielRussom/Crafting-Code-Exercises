namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class Board
    {
        private readonly List<List<bool>> _state;

        public Board(List<List<bool>> state)
        {
            _state = state;
        }

        public BoardEqualityState Equals(Board boardToCompare)
        {
            if (_state.Count != boardToCompare._state.Count) return BoardEqualityState.IsNotEqual;

            if (_state.Count == 0
                || _state[0].Count == 0
                || boardToCompare._state.Count == 0
                || boardToCompare._state[0].Count == 0)
            {
                return BoardEqualityState.IsEqual;
            }

            if (_state[0].Count > 1 && boardToCompare._state[0].Count > 1 && _state[0][1] != boardToCompare._state[0][1]) return BoardEqualityState.IsNotEqual;
            if (_state[0][0] == boardToCompare._state[0][0]) return BoardEqualityState.IsEqual;

            return BoardEqualityState.IsNotEqual;
        }
    }
}
