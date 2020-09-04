using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Knight: Piece
    {
        public Knight(Player player) : base(player)
        {
            DisplayCharacter = 'H';
        }

        public override bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            return CanMoveTo(oldRow, oldCol, newRow, newCol, board);
        }

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int deltaRow = Math.Abs(oldRow - newRow);
            int deltaCol = Math.Abs(oldCol - newCol);

            return (deltaRow == 1 && deltaCol == 2) || (deltaRow == 2 && deltaCol == 1);
        }
    }
}
