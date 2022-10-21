namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class CellPosition
    {
        public CellPosition(int row, int column)
        {
            Row = new (row);
            Column = column;
        }

        internal int Column { get; }
        internal RowPosition Row { get; }
    }
}
