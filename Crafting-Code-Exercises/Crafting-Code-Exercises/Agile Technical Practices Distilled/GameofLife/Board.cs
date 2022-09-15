using Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe;
using IFormatProvider = System.IFormatProvider;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class Board : IEquatable<Board>
    {
        private readonly List<List<bool>> _state;

        public Board(List<List<bool>> state)
        {
            _state = state;
        }

        public bool Equals(Board boardToCompare)
        {
            if (_state.Count != boardToCompare._state.Count) return false;

            if (_state.Count == 0
                || _state[0].Count == 0
                || boardToCompare._state.Count == 0
                || boardToCompare._state[0].Count == 0)
            {
                return true;
            }
           
            return _state[0][0] == boardToCompare._state[0][0];
        }
    }
}
