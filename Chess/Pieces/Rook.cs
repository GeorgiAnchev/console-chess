using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Player player) : base(player)
        {
            DisplayCharacter = 'R';
        }

        public override bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            return CanMoveTo(oldRow, oldCol, newRow, newCol, board);
        }

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int deltaRow = Math.Abs(newRow - oldRow);
            int deltaCol = Math.Abs(newCol - oldCol);

            if (deltaCol != 0 && deltaRow != 0)//not moving on the same row or col
            {
                return false;
            }

            int directionRow = Math.Sign(newRow - oldRow);
            int directionCol = Math.Sign(newCol - oldCol);
            int moves = Math.Max(deltaRow, deltaCol); //moves to be made

            for (int i = 1; i < moves; i++)
            {
                if (board[oldRow + i * directionRow, oldCol + i * directionCol] != null) //no line of sight
                {
                    return false;
                }
            }
            return true;
        }
    }
}
