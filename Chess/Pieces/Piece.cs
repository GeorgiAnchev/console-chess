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
        
        public abstract bool CanMoveTo(Move move, Board board);

        public abstract bool CanAttackPosition(Move move, Board board);

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

        protected static bool HasLineOfSight(Move move, Board board)
        {
            int rowDelta = move.NewRow - move.CurrentRow;
            int colDelta = move.NewCol - move.CurrentCol;

            int directionRow = Math.Sign(rowDelta);
            int directionCol = Math.Sign(colDelta);
            int numberOfSteps = Math.Max(Math.Abs(rowDelta), Math.Abs(colDelta));

            for (int i = 1; i < numberOfSteps; i++)
            {
                int row = move.CurrentRow + i * directionRow;
                int col = move.CurrentCol + i * directionCol;

                if (board[row, col] != null)
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
