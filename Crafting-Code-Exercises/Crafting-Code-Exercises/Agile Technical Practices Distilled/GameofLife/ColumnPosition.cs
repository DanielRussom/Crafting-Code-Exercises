using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class ColumnPosition
    {
        public int Value { get; }

        internal ColumnPosition(int value)
        {
            Value = value;
        }
    }
}
