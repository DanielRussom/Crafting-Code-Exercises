namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class RowPosition
    {
        public int Position { get; }
        public RowPosition PositionAbove => new (Position - 1);
        public RowPosition PositionBelow => new (Position + 1);
        
        internal RowPosition(int position)
        {
            Position = position;
        }
    }
}
