namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class ColumnPosition
    {
        public int Position { get; }
        public int PositionToTheLeft => Position - 1;
        public int PositionToTheRight => Position + 1;

        internal ColumnPosition(int position)
        {
            Position = position;
        }
    }
}
