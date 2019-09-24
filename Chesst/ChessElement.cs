using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesst
{
    public class CoordCluster
    {
        private int x;
        private int y;

        public CoordCluster()
        {
            x = -1;
            y = -1;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }

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
            Black = +1,
            White = -1,
            Void = 0
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


        public bool CanGo(ChessGame gamePlate, CoordCluster start, CoordCluster destination)
        {
            switch(this.Type)
            {
                case ChessElement.Types.Pawn:
                    //Standard forward move
                    if((destination.X == start.X + (int)this.Team) && //Move only 1 step
                        (destination.Y == start.Y) && //Move only forward
                        (gamePlate.Grid[destination.X][destination.Y].Type == ChessElement.Types.Void)) //Move only if there void forward
                    {
                        return true;
                    }
                    //Standard attack move
                    else if ((destination.X == start.X + (int)this.Team) && //Move only 1 step
                        (destination.Y == start.Y + 1 || destination.Y == start.Y - 1) && //Move only 1 diagonal
                        ((int)gamePlate.Grid[destination.X][destination.Y].Team == (int)this.Team * -1)) //Move only if there an enemy in diagonal
                    {
                        return true;
                    }
                    //Double first move
                    else if ((destination.X == start.X + ((int)this.Team*2)) && //Move 2 steps
                        (destination.Y == start.Y) && //Move only forward
                        (start.X == ( ((int)this.Team == -1) ? 6 : 1))) //Move only if on starting case
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("ImpossibleMove");
                    }
                    break;

                case ChessElement.Types.Rook:
                    break;

                case ChessElement.Types.Knight:
                    break;

                case ChessElement.Types.Bishop:
                    break;

                case ChessElement.Types.Queen:
                    break;

                case ChessElement.Types.King:
                    break;

            }

            return false;
        }
    }
}
