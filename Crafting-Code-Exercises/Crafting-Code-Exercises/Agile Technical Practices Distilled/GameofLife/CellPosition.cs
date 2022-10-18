using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    public class CellPosition
    {
        public CellPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        internal int Column { get; }
        internal int Row { get; }
    }
}
