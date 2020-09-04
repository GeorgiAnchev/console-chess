using System;

namespace Chess
{
    abstract class Piece
    {
        public Piece (Player player)
        {
            Owner = player;
        }

        public char DisplayCharacter
        {
            get;
            protected set;
        }

        public Player Owner {
            get; 
            protected set; 
        }
        
        public abstract bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board);

        public abstract bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board);

        protected static bool IsOnSameDiagonal(int rowDiff, int colDiff)
        {
            return colDiff == rowDiff;
        }

        protected static bool IsOnSameRow(int rowDiff, int colDiff)
        {
            return rowDiff == 0 && colDiff != 0;
        }

        protected static bool IsOnSameCol(int rowDiff, int colDiff)
        {
            return rowDiff != 0 && colDiff == 0;
        }

        protected static bool HasLineOfSight(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            int directionRow = Math.Sign(newRow - currentRow);
            int directionCol = Math.Sign(newCol - currentCol);
            int numberOfSteps = Math.Max(Math.Abs(newRow - currentRow), Math.Abs(newCol - currentCol));

            for (int i = 1; i < numberOfSteps; i++)
            {
                if (board[currentRow + i * directionRow, currentCol + i * directionCol] != null)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return DisplayCharacter.ToString();
        }
    }
}
