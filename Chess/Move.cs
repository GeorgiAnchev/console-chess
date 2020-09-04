
using System;

namespace Chess
{
    public struct Move
    {
        public Move(int currentRow, int currentCol, int newRow, int newCol)
        {
            CurrentRow = currentRow;
            CurrentCol = currentCol;
            NewRow = newRow;
            NewCol = newCol;
        }

        public int CurrentRow { get; }

        public int CurrentCol { get; }

        public int NewRow { get; }

        public int NewCol { get; }
        public int ColDiff()
        {
            return Math.Abs(NewCol - CurrentCol);
        }
    }
}
