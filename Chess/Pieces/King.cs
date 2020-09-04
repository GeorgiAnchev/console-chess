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

        public override bool CanAttackPosition(int oldRow, int oldCol, int newRow, int newCol, Board board)
        {
            return CanMoveTo(oldRow, oldCol, newRow, newCol, board);
        }

        public override bool CanMoveTo(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            int deltaRow = Math.Abs(newRow - currentRow);
            int deltaCol = Math.Abs(newCol - currentCol);

            if (!isDistanceSmallEnough(deltaRow, deltaCol))
            {
                return false;
            }

            for (int row = 0; row < Board.boardSize; row++)
            {
                for (int col = 0; col < Board.boardSize; col++)
                {
                    Piece potentialThreat = board[row, col];

                    if (potentialThreat != null && potentialThreat.Owner != Owner)
                    {
                        if (potentialThreat is King)
                        {
                            int rowDiffBetweenKings = Math.Abs(row - newRow);
                            int colDiffBetweenKings = Math.Abs(col - newCol);

                            if (isDistanceSmallEnough(rowDiffBetweenKings, colDiffBetweenKings))
                            {
                                return false;
                            }
                        }
                        else if (potentialThreat.CanAttackPosition(row, col, newRow, newCol, board))//enemy piece threatening the king's new position
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool isDistanceSmallEnough(int deltaRow, int deltaCol)
        {
            return deltaRow <= 1 && deltaCol <= 1;
        }
    }
}
