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
            ChessGame gamePlate = new ChessGame();

            Console.SetBufferSize(400, 400);
            Console.SetWindowSize(55, 13);

            
            while(true)
            {
                CoordCluster startPos;
                CoordCluster destPos;

                bool validInput;
                string errorMessage;


                validInput = false;
                errorMessage = null;

                do
                {
                    Console.Clear();
                    DrawPlate(gamePlate);

                    if(errorMessage != null)
                    {
                        Console.Write($"{errorMessage}\n");
                        errorMessage = null;
                    }
                    else
                    {
                        Console.Write("\n");
                    }

                    Console.Write("Choose which of your piece you want pick (e.g. a1) ");
                    string rawInput = Console.ReadLine();
                    
                    validInput = IsPickable(gamePlate, rawInput, out startPos, out errorMessage);

                } while (!validInput);



                bool authMove = false;
                errorMessage = null;

                do
                {
                    Console.Clear();
                    DrawPlate(gamePlate, startPos);

                    if (errorMessage != null)
                    {
                        Console.Write($"{errorMessage}\n");
                        errorMessage = null;
                    }
                    else
                    {
                        Console.Write("\n");
                    }

                    Console.Write("Choose where you want to move your piece (e.g. a1) ");
                    string rawInput = Console.ReadLine();

                    authMove = CanMoveThere(gamePlate, rawInput, startPos, out destPos, out errorMessage);
                } while (!authMove);

                gamePlate.Grid[destPos.X][destPos.Y] = gamePlate.Grid[startPos.X][startPos.Y];
                gamePlate.Grid[startPos.X][startPos.Y].Type = ChessElement.Types.Void;
                gamePlate.Grid[startPos.X][startPos.Y].Team = ChessElement.Teams.Void;

                DrawPlate(gamePlate);
            }



            Console.Write("END");
            Console.ReadLine();
        }

        static void DrawPlate(ChessGame plateToDraw, CoordCluster selectedCoords = null)
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

            for (int indexX = 0; indexX < plateToDraw.Grid.Count(); indexX++)
            {
                Console.Write($"{leftMargin}");
                Console.ForegroundColor = frontSide;
                Console.BackgroundColor = backSide;
                Console.Write($" {8 - indexX} ");
                Console.ResetColor();

                for (int indexY = 0; indexY < plateToDraw.Grid[indexX].Count(); indexY++)
                {
                    Console.ResetColor();

                    if ((selectedCoords != null) && (selectedCoords.X == indexX && selectedCoords.Y == indexY))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        if ((indexX + indexY) % 2 == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                    }

                    if (plateToDraw.Grid[indexX][indexY].Team == ChessElement.Teams.White)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {(char)plateToDraw.Grid[indexX][indexY].Type} ");
                }

                Console.ForegroundColor = frontSide;
                Console.BackgroundColor = backSide;
                Console.Write($" {8 - indexX} ");
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


        static CoordCluster ProcessCoords (string userInput)
        {
            CoordCluster processedCoords = new CoordCluster();

            if ((userInput[0] >= 'A' && userInput[0] <= 'H'))
            {
                processedCoords.Y = userInput[0] - 'A';
            }
            else if ((userInput[0] >= 'a' && userInput[0] <= 'h'))
            {
                processedCoords.Y = userInput[0] - 'a';
            }
            else
            {
                throw new Exception("InvalidInput");
            }

            if ((userInput[1] >= '1' && userInput[1] <= '8'))
            {
                processedCoords.X = 7 - (userInput[1] - '1');
            }
            else
            {
                throw new Exception("InvalidInput");
            }

            return processedCoords;
        }


        static bool IsPickable(ChessGame plate, string input, out CoordCluster coords, out string raiseError)
        {
            raiseError = null;
            coords = null;
            
            try
            {
                coords = ProcessCoords(input);
            }
            catch (Exception e) when (e.Message == "InvalidInput")
            {
                raiseError = "Invalid input";
                return false;
            }


            try
            {
                if (plate.Grid[coords.X][coords.Y].Team == ChessElement.Teams.White)
                {
                    return true;
                }
                else if (plate.Grid[coords.X][coords.Y].Team == ChessElement.Teams.Black)
                {
                    raiseError = "Not your piece";
                    return false;
                }
                else
                {
                    raiseError = "Not a piece";
                    return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                raiseError = "Invalid input";
                return false;
            }
        }


        static bool CanMoveThere(ChessGame plate, string input, CoordCluster start, out CoordCluster dest, out string raiseError)
        {
            dest = null;
            raiseError = null;

            try
            {
                dest = ProcessCoords(input);
            }
            catch (Exception e) when (e.Message == "InvalidInput")
            {
                raiseError = "Invalid input";
                return false;
            }


            try
            {
                plate.Grid[start.X][start.Y].CanGo(plate, start, dest);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                raiseError = "Invalid input";
                return false;
            }
        }





    }
}
