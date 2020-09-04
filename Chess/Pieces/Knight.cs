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

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            int deltaRow = Math.Abs(move.CurrentRow - move.NewRow);
            int deltaCol = Math.Abs(move.CurrentCol - move.NewCol);

            return (deltaRow == 1 && deltaCol == 2) || (deltaRow == 2 && deltaCol == 1);
        }
    }
}
