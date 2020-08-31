using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public const int boardSize = 8;
        private Piece[,] board;

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

        public Piece this[int row, int col]
        {
            get { return board[row, col]; }
            set { board[row, col] = value; }
        } 

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if ((i + j) % 2 == 0) Console.BackgroundColor = ConsoleColor.Yellow;
                    else Console.BackgroundColor = ConsoleColor.DarkYellow;

                    if(board[i, j] != null)
                    {
                        if (board[i, j].Player == Player.White) Console.ForegroundColor = ConsoleColor.Green;
                        else Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write(board[i, j]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
