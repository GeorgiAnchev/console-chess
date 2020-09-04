using System;

namespace Chess.Pieces
{
    class Queen: Piece
    {
        public Queen(Player player) : base(player)
        {
            DisplayCharacter = 'Q';
        }

        public override bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            return CanMoveTo(oldRow, oldCol, newRow, newCol, board);
        }

        public override bool CanMoveTo(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            int rowDiff = Math.Abs(newRow - currentRow);
            int colDiff = Math.Abs(newCol - currentCol);

            if (!IsOnSameDiagonal(rowDiff, colDiff)
                && !IsOnSameRow(rowDiff, colDiff)
                && !IsOnSameCol(rowDiff, colDiff))
            {
                return false;
            }

            return HasLineOfSight(currentRow, currentCol, newRow, newCol, board);
        }
    }
}
