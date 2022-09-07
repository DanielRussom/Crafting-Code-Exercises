namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal struct Coordinate
    {
        private int _xValue;

        private int _yValue;

        public Coordinate(int xValue, int yValue)
        {
            _xValue = xValue;
            _yValue = yValue;
        }

        public override string ToString()
        {
            return $"{_xValue},{_yValue}";
        }
    }
}