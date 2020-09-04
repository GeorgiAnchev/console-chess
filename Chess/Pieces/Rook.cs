using System;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Player player) : base(player)
        {
            DisplayCharacter = 'R';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            int rowDiff = Math.Abs(move.NewRow - move.CurrentRow);
            int colDiff = Math.Abs(move.NewCol - move.CurrentCol);

            if (!IsOnSameRow(rowDiff, colDiff)
                && !IsOnSameCol(rowDiff, colDiff))
            {
                return false;
            }

            return HasLineOfSight(move, board);
        }
    }
}
