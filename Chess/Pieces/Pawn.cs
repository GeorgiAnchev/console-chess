using System;

namespace Chess.Pieces
{
    class Pawn: Piece
    {
        public Pawn(Player player) : base(player)
        {
            DisplayCharacter = 'P';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            int colDiff = Math.Abs(move.NewCol - move.CurrentCol);

            if (Owner == Player.Black && CanAttackDownwards(move.CurrentRow, move.NewRow, colDiff))
            {
                return true;
            }

            if (Owner == Player.White && CanAttackUpwards(move.CurrentRow, move.NewRow, colDiff))
            {
                return true;
            }
            
            return false;
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            int colDiff = Math.Abs(move.NewCol - move.CurrentCol);

            //todo: implement promotion, en passant
            if (Owner == Player.Black
                && (CanMoveDownwards(move.CurrentRow, move.NewRow, colDiff)
                    || CanDoubleMoveDownwards(move, board)))
            {
                return true;
            }

            if (Owner == Player.White
                && (CanMoveUpwards(move.CurrentRow, move.NewRow, colDiff)
                   || CanDoubleMoveUpwards(move, board)))
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

        private static bool CanDoubleMoveUpwards(Move move, Board board)
        {
            return move.CurrentRow == 6
                && move.NewRow == move.CurrentRow - 2
                && move.ColDiff() == 0
                && board[move.CurrentRow - 1, move.CurrentCol] == null;
        }

        private static bool CanDoubleMoveDownwards(Move move, Board board)
        {
            return move.CurrentRow == 1
                && move.NewRow == move.CurrentRow + 2
                && move.ColDiff() == 0
                && board[move.CurrentRow + 1, move.CurrentCol] == null;
        }
    }
}
