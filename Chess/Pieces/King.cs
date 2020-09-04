﻿using System;
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

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            int deltaRow = Math.Abs(move.NewRow - move.CurrentRow);
            int deltaCol = Math.Abs(move.NewCol - move.CurrentCol);

            if (!isDistanceSmallEnough(deltaRow, deltaCol))
            {
                return false;
            }

            return IsPositionThreatened(move.NewRow, move.NewCol, board);
        }

        private bool IsPositionThreatened(int newRow, int newCol, Board board)
        {
            for (int row = 0; row < Board.boardSize; row++)
            {
                for (int col = 0; col < Board.boardSize; col++)
                {
                    Piece potentialThreat = board[row, col];
                    Move move = new Move(row, col, newRow, newCol);

                    if (IsThreatenedBy(potentialThreat, move, board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsThreatenedBy(Piece potentialThreat, Move move, Board board)
        {
            if (potentialThreat != null && potentialThreat.Owner != Owner)
            {
                if (potentialThreat is King)
                {
                    int rowDiffBetweenKings = Math.Abs(move.CurrentRow - move.NewRow);//todo: exctract this logic in Move
                    int colDiffBetweenKings = Math.Abs(move.CurrentCol - move.NewCol);

                    if (isDistanceSmallEnough(rowDiffBetweenKings, colDiffBetweenKings))
                    {
                        return true;
                    }
                }
                else if (potentialThreat.CanAttackPosition(move, board))
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
