using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Player player) : base(player)
        {
            DisplayCharacter = 'R';
        }

    }
}
