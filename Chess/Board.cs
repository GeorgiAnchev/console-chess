﻿using Chess.Pieces;
using System;

namespace Chess
{
    class Board
    {
        public const int boardSize = 8;
        private Piece[,] board;
        public Player PlayerOnTurn
        {
            get;
            private set;
        }

        public Board()
        {
            board = new Piece[8, 8];

            board[0, 0] = new Rook(Player.Black);
            board[0, 1] = new Knight(Player.Black);
            board[0, 2] = new Bishop(Player.Black);
            board[0, 3] = new Queen(Player.Black);
            board[0, 4] = new King(Player.Black);
            board[0, 5] = new Bishop(Player.Black);
            board[0, 6] = new Knight(Player.Black);
            board[0, 7] = new Rook(Player.Black);
            for (int i = 0; i < boardSize; i++)
            {
                board[1, i] = new Pawn(Player.Black);
            }

            board[7, 0] = new Rook(Player.White);
            board[7, 1] = new Knight(Player.White);
            board[7, 2] = new Bishop(Player.White);
            board[7, 3] = new Queen(Player.White);
            board[7, 4] = new King(Player.White);
            board[7, 5] = new Bishop(Player.White);
            board[7, 6] = new Knight(Player.White);
            board[7, 7] = new Rook(Player.White);
            for (int i = 0; i < boardSize; i++)
            {
                board[6, i] = new Pawn(Player.White);
            }
        }

        public MoveOutcome TryMove(int oldRow, int oldCol, int newRow, int newCol)
        {
            Piece piece = board[oldRow, oldCol];
            
            //No such piece or other player's piece
            if (piece == null || piece.Player != PlayerOnTurn)
            {
                return MoveOutcome.Illegal;
            }

            Piece targetPiece = board[newRow, newCol];

            //Can't take your own piece
            if (targetPiece != null && targetPiece.Player == PlayerOnTurn)
            {
                return MoveOutcome.Illegal;
            }



            board[newRow, newCol] = piece;
            board[oldRow, oldCol] = null;

            return MoveOutcome.Success;
        }

        public void ChangeTurns()
        {
            if (PlayerOnTurn == Player.White)
            {
                PlayerOnTurn = Player.Black;
            }
            else
            {
                PlayerOnTurn = Player.White;
            }
        }

        public Piece this[int row, int col]
        {
            get { return board[row, col]; }
            set { board[row, col] = value; }
        } 

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("    0  1  2  3  4  5  6  7");

            for (int i = 0; i < boardSize; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" {i} ");

                for (int j = 0; j < boardSize; j++)
                {
                    if ((i + j) % 2 == 0) Console.BackgroundColor = ConsoleColor.Gray;
                    else Console.BackgroundColor = ConsoleColor.DarkYellow;

                    if(board[i, j] != null)
                    {
                        if (board[i, j].Player == Player.White) Console.ForegroundColor = ConsoleColor.White;
                        else Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write($" {board[i, j]} ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    public enum MoveOutcome
    {
        Success,
        WhiteWins,
        BlackWins,
        Illegal
    }
}
