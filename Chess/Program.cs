﻿using System;

namespace Chess
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);

            Board Board = new Board();

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] input;

            while (true)
            {
                Board.Print();

                Console.WriteLine();
                Console.WriteLine($"On turn is {Board.PlayerOnTurn}");
                Console.WriteLine("Enter coordinates of the piece to be moved");
                input = Console.ReadLine().Split(delimiterChars);
                int oldRow = int.Parse(input[0]);
                int oldCol = int.Parse(input[1]);

                Console.WriteLine();
                Console.WriteLine("Enter coordinates of the new position of the piece");
                input = Console.ReadLine().Split(delimiterChars);
                int newRow = int.Parse(input[0]);
                int newCol = int.Parse(input[1]);

                MoveOutcome result = Board.TryMove(oldRow, oldCol, newRow, newCol);
                if(result == MoveOutcome.BlackWins)
                {
                    Console.WriteLine("Black wins");
                    break;
                }
                else if(result == MoveOutcome.WhiteWins)
                {
                    Console.WriteLine("Black wins");
                    break;
                }
                else if(result == MoveOutcome.Illegal)
                {
                    Console.Clear();
                    Console.WriteLine("Move is illegal");
                }
                else
                {
                    Board.ChangeTurns();
                    Console.Clear();
                }
            }

            Console.ReadLine();
        }
    }
}
