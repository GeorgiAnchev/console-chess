using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Bishop: Piece
    {
        public Bishop(Player player) : base(player)
        {
            DisplayCharacter = 'B';
        }

        public override bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            return CanMoveTo(oldRow, oldCol, newRow, newCol, board);
        }

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int rowDifference = Math.Abs(newRow - oldRow);
            int colDifference = Math.Abs(newCol - oldCol);

            if (!IsOnSameDiagonal(rowDifference, colDifference))
            {
                return false;
            }

            return HasLineOfSight(oldRow, oldCol, newRow, newCol, board);
        }

    }
}
