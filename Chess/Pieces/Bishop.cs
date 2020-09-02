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

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int deltaRow = Math.Abs(newRow - oldRow);
            int deltaCol = Math.Abs(newCol - oldCol);

            if (deltaCol != deltaRow)//not on the same diagonal
            {
                return false;
            }

            int directionRow = Math.Sign(newRow - oldRow);
            int directionCol = Math.Sign(newCol - oldCol);
            int moves = deltaRow; //moves to be made

            for (int i = 1; i < moves; i++)
            {
                if (board[oldRow + i*directionRow, oldCol + i*directionCol] != null) //no line of sight
                {
                    return false;
                }
            }
            return true;
        }
    }
}
