using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesst
{
    public class ChessElement
    {
        /*public enum Types
        {
            Pawn = 76,
            Rook = 165,
            Knight = 254,
            Bishop = 164,
            Queen = 216,
            King = 212,
            Void = 32
        }*/

        public enum Types
        {
            Pawn = 80,
            Rook = 84,
            Knight = 67,
            Bishop = 66,
            Queen = 81,
            King = 75,
            Void = 32
        }

        public enum Teams
        {
            Black,
            White,
            Void
        }

        private Teams team;
        private Types type;

        public ChessElement(Types type, Teams team)
        {
            this.type = type;
            this.team = team;
        }

        public Teams Team
        {
            get { return team; }
            set { team = value; }
        }

        public Types Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
