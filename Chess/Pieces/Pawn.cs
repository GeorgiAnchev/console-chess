using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Pawn: Piece
    {
        public Pawn(Player player) : base(player)
        {
            DisplayCharacter = 'P';
        }
    }
}
