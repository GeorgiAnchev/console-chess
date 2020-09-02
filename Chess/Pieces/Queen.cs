using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Queen: Piece
    {
        public Queen(Player player) : base(player)
        {
            DisplayCharacter = 'Q';
        }

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int deltaRow = Math.Abs(newRow - oldRow);
            int deltaCol = Math.Abs(newCol - oldCol);
            bool positionIsLegal = false;

            if (deltaCol == deltaRow)//move diagonally
            {
                positionIsLegal = true;
            }

            if (deltaRow == 0 && deltaCol != 0)//move up or down
            {
                positionIsLegal = true;
            }

            if (deltaRow != 0 && deltaCol == 0)//move left or right
            {
                positionIsLegal = true;
            }

            if (positionIsLegal == false)
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
