using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);
            
            Board Board = new Board();

            Board.Print();




            Console.ReadLine();
        }
    }
}
