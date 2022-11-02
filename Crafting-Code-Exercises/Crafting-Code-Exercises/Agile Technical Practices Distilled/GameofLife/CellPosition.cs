namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class CellPosition
    {
        public CellPosition(int row, int column)
        {
            Row = new (row);
            Column = new(column);
        }

        internal ColumnPosition Column { get; }
        internal RowPosition Row { get; }
    }
}
