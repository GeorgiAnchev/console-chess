using System;

namespace Chess.Pieces
{
    class Queen: Piece
    {
        public Queen(Player player) : base(player)
        {
            DisplayCharacter = 'Q';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            int rowDiff = Math.Abs(move.NewRow - move.CurrentRow);
            int colDiff = Math.Abs(move.NewCol - move.CurrentCol);

            if (!IsOnSameDiagonal(rowDiff, colDiff)
                && !IsOnSameRow(rowDiff, colDiff)
                && !IsOnSameCol(rowDiff, colDiff))
            {
                return false;
            }

            return HasLineOfSight(move, board);
        }
    }
}
