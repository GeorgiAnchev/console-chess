using System;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Player player) : base(player)
        {
            DisplayCharacter = 'R';
        }

        public override bool CanAttackPosition(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            return CanMoveTo(currentRow, currentCol, newRow, newCol, board);
        }

        public override bool CanMoveTo(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            int rowDiff = Math.Abs(newRow - currentRow);
            int colDiff = Math.Abs(newCol - currentCol);

            if (!IsOnSameRow(rowDiff, colDiff)
                && !IsOnSameCol(rowDiff, colDiff))
            {
                return false;
            }

            return HasLineOfSight(currentRow, currentCol, newRow, newCol, board);
        }
    }
}
