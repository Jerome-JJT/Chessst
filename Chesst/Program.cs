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

            Console.SetBufferSize(400, 400);
            Console.SetWindowSize(40, 12);

            
            while(true)
            {
                bool flagError = false;

                do
                {
                    drawGrid(terre);

                    if(flagError)
                    {
                        Console.Write("Invalid input\n");
                    }

                    Console.Write("Choose which piece to pick (e.g. a1) ");
                    string input = Console.ReadLine();

                    userinput(terre, input);




                } while (askPiece);

            }



            Console.Write("END");
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
            Console.Write($" \n");

            for (int i = 0; i < gridToDraw.Grid.Count(); i++)
            {
                Console.Write($"{leftMargin}");
                Console.ForegroundColor = frontSide;
                Console.BackgroundColor = backSide;
                Console.Write($" {8 - i} ");
                Console.ResetColor();

                for (int j = 0; j < gridToDraw.Grid[i].Count(); j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    if (gridToDraw.Grid[i][j].Team == ChessElement.Teams.White)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {(char)gridToDraw.Grid[i][j].Type} ");
                }

                Console.ForegroundColor = frontSide;
                Console.BackgroundColor = backSide;
                Console.Write($" {8 - i} ");
                Console.ResetColor();
                Console.Write($" \n");
            }

            Console.Write($"{leftMargin}");
            Console.ForegroundColor = frontSide;
            Console.BackgroundColor = backSide;
            Console.Write($"    a  b  c  d  e  f  g  h    ");
            Console.ResetColor();
            Console.Write($" \n");
        }

        static int userinput(Terrain terre, string input)
        {
            try
            {
                int line = 0;
                int col = 0;

                if ((input[1] >= '1' && input[1] <= '8'))
                {
                    line = input[1] - 48;
                }
                else
                {
                    return 0;
                }

                if ((input[0] >= 'A' && input[0] <= 'H'))
                {
                    col = input[0] - 64;
                }
                else if ((input[0] >= 'a' && input[0] <= 'h'))
                {
                    col = input[0] - 96;
                }
                else
                {
                    return 0;
                }

                if (terre.Grid[line][col].Team != ChessElement.Teams.Void)
                {
                    return (10*line) + (col);
                }
                else
                {
                    return 0;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
    }
}
