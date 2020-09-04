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

            return IsPositionThreatened(newRow, newCol, board);
        }

        private bool IsPositionThreatened(int newRow, int newCol, Board board)
        {
            for (int row = 0; row < Board.boardSize; row++)
            {
                for (int col = 0; col < Board.boardSize; col++)
                {
                    Piece potentialThreat = board[row, col];

                    if (IsThreatenedBy(potentialThreat, row, col, newRow, newCol, board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsThreatenedBy(Piece potentialThreat, int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            if (potentialThreat != null && potentialThreat.Owner != Owner)
            {
                if (potentialThreat is King)
                {
                    int rowDiffBetweenKings = Math.Abs(currentRow - newRow);
                    int colDiffBetweenKings = Math.Abs(currentCol - newCol);

                    if (isDistanceSmallEnough(rowDiffBetweenKings, colDiffBetweenKings))
                    {
                        return true;
                    }
                }
                else if (potentialThreat.CanAttackPosition(currentRow, currentCol, newRow, newCol, board))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isDistanceSmallEnough(int deltaRow, int deltaCol)
        {
            return deltaRow <= 1 && deltaCol <= 1;
        }
    }
}
