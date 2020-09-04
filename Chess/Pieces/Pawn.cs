using System;

namespace Chess.Pieces
{
    class Pawn: Piece
    {
        public Pawn(Player player) : base(player)
        {
            DisplayCharacter = 'P';
        }

        public override bool CanAttackPosition(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            int colDiff = Math.Abs(newCol - currentCol);

            if (Owner == Player.Black && CanAttackDownwards(currentRow, newRow, colDiff))
            {
                return true;
            }

            if (Owner == Player.White && CanAttackUpwards(currentRow, newRow, colDiff))
            {
                return true;
            }
            
            return false;
        }

        public override bool CanMoveTo(int currentRow, int currentCol, int newRow, int newCol, Board board)
        {
            int colDiff = Math.Abs(newCol - currentCol);

            //todo: implement promotion, en passant
            if (Owner == Player.Black
                && (CanMoveDownwards(currentRow, newRow, colDiff)
                    || CanDoubleMoveDownwards(currentRow, newRow, currentCol, colDiff, board)))
            {
                return true;
            }

            if (Owner == Player.White
                && (CanMoveUpwards(currentRow, newRow, colDiff)
                   || CanDoubleMoveUpwards(currentRow, newRow, currentCol, colDiff, board)))
            {
                return true;
            }

            return false;
        }

        private static bool CanAttackUpwards(int currentRow, int newRow, int colDiff)
        {
            return newRow == currentRow - 1 && colDiff == 1;
        }

        private static bool CanAttackDownwards(int currentRow, int newRow, int colDiff)
        {
            return newRow == currentRow + 1 && colDiff == 1;
        }

        private static bool CanMoveUpwards(int currentRow, int newRow, int colDiff)
        {
            return newRow == currentRow - 1 && colDiff == 0;
        }

        private static bool CanMoveDownwards(int currentRow, int newRow, int colDiff)
        {
            return newRow == currentRow + 1 && colDiff == 0;
        }

        private static bool CanDoubleMoveUpwards(int currentRow, int newRow, int currentCol,  int colDiff, Board board)
        {
            return currentRow == 6
                && newRow == currentRow - 2
                && colDiff == 0
                && board[currentRow - 1, currentCol] == null;
        }

        private static bool CanDoubleMoveDownwards(int currentRow, int newRow,int currentCol, int colDiff, Board board)
        {
            return currentRow == 1
                && newRow == currentRow + 2
                && colDiff == 0
                && board[currentRow + 1, currentCol] == null;
        }
    }
}
