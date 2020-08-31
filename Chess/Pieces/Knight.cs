using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Knight: Piece
    { 
        public Knight(Player player) : base(player)
        {
            DisplayCharacter = 'H';
        }
    }
}
