namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal struct Player : IEquatable<Player>
    {
        private string _name;

        public Player(string name)
        {
            _name = name;
        }

        public bool Equals(Player toCompare)
        {
            return _name == toCompare._name;
        }
    }
}