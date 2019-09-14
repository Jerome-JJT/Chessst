using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesst
{
    class Program
    {
        static void Main(string[] args)
        {
            Terrain terre = new Terrain();

            //List<List<ChessElement>> gri = terre.OneGrid;

            Console.SetBufferSize(400, 400);
            Console.SetWindowSize(40, 12);
            //Console.SetWindowPosition(300, 10);

            bool whiteColor = true;
            bool invertcolor = true;

            drawGrid(terre);


            /*foreach (List<ChessElement> oneLine in terre.OneGrid)
            {
                foreach (ChessElement oneCase in oneLine)
                {
                    if (whiteColor ^ invertcolor)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        whiteColor = !whiteColor;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        whiteColor = !whiteColor;
                    }

                    if (oneCase.Team == ChessElement.Teams.White)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (oneCase.Team == ChessElement.Teams.Black)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {(char) oneCase.Type} ");
                }

                invertcolor = !invertcolor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" \n\t");
            }*/




            Console.ReadLine();
        }

        static void drawGrid(Terrain gridToDraw)
        {
            string leftMargin = "       ";
            ConsoleColor frontSide = ConsoleColor.Black;
            ConsoleColor backSide = ConsoleColor.DarkGreen;

            Console.Write($"{leftMargin}");
            Console.ForegroundColor = frontSide;
            Console.BackgroundColor = backSide;
            Console.Write($"    a  b  c  d  e  f  g  h    ");
            Console.ResetColor();
            Console.Write($"\n");

            for (int i = 0; i < gridToDraw.OneGrid.Count(); i++)
            {
                Console.Write($"{leftMargin}");
                Console.ForegroundColor = frontSide;
                Console.BackgroundColor = backSide;
                Console.Write($" {8 - i} ");
                Console.ResetColor();

                for (int j = 0; j < gridToDraw.OneGrid[i].Count(); j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    if (gridToDraw.OneGrid[i][j].Team == ChessElement.Teams.White)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {(char)gridToDraw.OneGrid[i][j].Type} ");
                }

                Console.ForegroundColor = frontSide;
                Console.BackgroundColor = backSide;
                Console.Write($" {8 - i} ");
                Console.ResetColor();
                Console.Write($"\n");
            }

            Console.Write($"{leftMargin}");
            Console.ForegroundColor = frontSide;
            Console.BackgroundColor = backSide;
            Console.Write($"    a  b  c  d  e  f  g  h    ");
            Console.ResetColor();
            Console.Write($"\n");
        }
    }
}
