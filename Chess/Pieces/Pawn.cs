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

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            //todo: split method into canMoveTo and CanAttack for all pieces
            //todo: implement promotion, en passant and double move 
            if (Player == Player.Black)
            {
                if (newRow == oldRow + 1 && newCol == oldCol && board[newRow, newCol] == null) //move forward 1 space
                {
                    return true;
                }
                else if(newRow == oldRow + 1 && 
                    (newCol == oldCol + 1 || newCol == oldCol - 1) && 
                    board[newRow, newCol] != null &&
                    board[newRow, newCol].Player == Player.White)//take enemy piece
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
                else if (newRow == oldRow - 1 && 
                    (newCol == oldCol + 1 || newCol == oldCol - 1) &&
                    board[newRow, newCol] != null &&
                    board[newRow, newCol].Player == Player.Black)//take enemy piece
                {
                    return true;
                }
            }
            return false;
        }
    }
}
