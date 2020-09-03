using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Pawn: Piece
    {
        public Pawn(Player player) : base(player)
        {
            DisplayCharacter = 'P';
        }

        public override bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int deltaCol = Math.Abs(newCol - oldCol);

            if (Player == Player.Black)
            {
                if (newRow == oldRow + 1 && deltaCol == 1)//attack "downwards"
                {
                    return true;
                }
            }
            else
            {
                if (newRow == oldRow - 1 && deltaCol == 1)//attack "upwards"
                {
                    return true;
                }
            }
            return false;
        }

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            //todo: implement promotion, en passant
            if (Player == Player.Black)
            {
                if (newRow == oldRow + 1 && newCol == oldCol && board[newRow, newCol] == null) //move forward 1 space
                {
                    return true;
                }
                else if(newRow == 3 && oldRow == 1 && newCol == oldCol && board[newRow, newCol] == null && board[newRow - 1, newCol] == null)//move forward 2 spaces
                {
                    return true;
                }
            }
            else
            {
                if (newRow == oldRow - 1 && newCol == oldCol && board[newRow, newCol] == null) //move forward 1 space
                {
                    return true;
                }
                else if (newRow == 4 && oldRow == 6 && newCol == oldCol && board[newRow, newCol] == null && board[newRow + 1, newCol] == null)//move forward 2 spaces
                {
                    return true;
                }
            }
            return false;
        }
    }
}
