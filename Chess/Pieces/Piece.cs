using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class Piece
    {
        public Piece (Player player)
        {
            Player = player;
        }

        public Char DisplayCharacter
        {
            get;
            protected set;
        }

        public Player Player {
            get; 
            protected set; 
        }
        
        public abstract bool CanMoveTo(int oldRow, int oldCol, int newRow, int newCol, Board board);

        public override string ToString()
        {
            return DisplayCharacter.ToString();
        }
    }
}
