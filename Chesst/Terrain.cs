using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesst
{
    public class Terrain
    {
        //List<ChessElement> line = new List<ChessElement>();

        //public List<List<ChessElement>> grid = new List<List<ChessElement>>;

        static ChessElement blackPawn = new ChessElement(ChessElement.Types.Pawn, ChessElement.Teams.Black);
        static ChessElement whitePawn = new ChessElement(ChessElement.Types.Pawn, ChessElement.Teams.White);

        static ChessElement voidPlace = new ChessElement(ChessElement.Types.Void, ChessElement.Teams.Void);

        private List<List<ChessElement>> oneGrid = new List<List<ChessElement>>
        {
            new List<ChessElement>
            {
                new ChessElement(ChessElement.Types.Rook, ChessElement.Teams.Black), new ChessElement(ChessElement.Types.Knight, ChessElement.Teams.Black),
                new ChessElement(ChessElement.Types.Bishop, ChessElement.Teams.Black), new ChessElement(ChessElement.Types.Queen, ChessElement.Teams.Black),
                new ChessElement(ChessElement.Types.King, ChessElement.Teams.Black), new ChessElement(ChessElement.Types.Bishop, ChessElement.Teams.Black),
                new ChessElement(ChessElement.Types.Knight, ChessElement.Teams.Black), new ChessElement(ChessElement.Types.Rook, ChessElement.Teams.Black)
            },
            new List<ChessElement> { blackPawn, blackPawn, blackPawn, blackPawn, blackPawn, blackPawn, blackPawn, blackPawn },

            new List<ChessElement> { voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace },
            new List<ChessElement> { voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace },
            new List<ChessElement> { voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace },
            new List<ChessElement> { voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace, voidPlace },

            new List<ChessElement> { whitePawn, whitePawn, whitePawn, whitePawn, whitePawn, whitePawn, whitePawn, whitePawn },
            new List<ChessElement>
            {
                new ChessElement(ChessElement.Types.Rook, ChessElement.Teams.White), new ChessElement(ChessElement.Types.Knight, ChessElement.Teams.White),
                new ChessElement(ChessElement.Types.Bishop, ChessElement.Teams.White), new ChessElement(ChessElement.Types.King, ChessElement.Teams.White),
                new ChessElement(ChessElement.Types.Queen, ChessElement.Teams.White), new ChessElement(ChessElement.Types.Bishop, ChessElement.Teams.White),
                new ChessElement(ChessElement.Types.Knight, ChessElement.Teams.White), new ChessElement(ChessElement.Types.Rook, ChessElement.Teams.White)
            }
        };

        public Terrain()
        {
            /*for(int i = 0; i < 8; i++)
            {
                List<ChessElement> oneLine = new List<ChessElement>();

                for (int j = 0; j < 8; j++)
                {
                    ChessElement oneElement = new ChessElement(ChessElement.Types.Pawn, ChessElement.Teams.White);
                    oneLine.Add(oneElement);
                }

                oneGrid.Add(oneLine);
            }*/
        }

        public List<List<ChessElement>> OneGrid
        {
            get { return oneGrid; }
            set { oneGrid = value; }
        }
    }
}
