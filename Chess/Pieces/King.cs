using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class King: Piece
    {
        public King(Player player) : base(player)
        {
            DisplayCharacter = 'K';
        }

        public override bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            int deltaRow = Math.Abs(newRow - oldRow);
            int deltaCol = Math.Abs(newCol - oldCol);

            if (deltaRow > 1 || deltaCol > 1)//distance is too big
            {
                return false;
            }

            for (int i = 0; i < Board.boardSize; i++)
            {
                for (int j = 0; j < Board.boardSize; j++)
                {
                    Piece piece = board[i, j];

                    //enemy piece 
                    if (piece!= null && piece.Player != Player) 
                    {
                        if (piece is King)
                        {
                            int deltaRowBetweenKings = Math.Abs(i - newRow);
                            int deltaColBetweenKings = Math.Abs(j - newCol);

                            if (deltaRowBetweenKings <= 1 && deltaColBetweenKings  <= 1)//kings threatening eachother
                            {
                                return false;
                            }
                        }
                        else if (piece.CanMoveTo(i, j, newRow, newCol, board))//enemy piece threatening the king's new position
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
