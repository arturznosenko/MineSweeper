using MineSweaperProject.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class WinnerPage
    {
        public WinnerPage (int WinnerTime, int NrOfMines)
        {
         DataBaseLogic DbConnection = new DataBaseLogic();
         Console.BackgroundColor = ConsoleColor.Black;
         Console.ForegroundColor = ConsoleColor.White;
            List<string> Results = new List<string>();

         GUI newfirstpage = new GUI(0, 0, 40, 25);
         newfirstpage.Render('*');
         Console.ForegroundColor = ConsoleColor.Yellow;
         Text newfirstpagetext = new Text(0, 0, 40, 4, "Game Finished You are WINNER");
         Console.ForegroundColor = ConsoleColor.White;
         Text newfirstpagetext2 = new Text(0, 0, 40, 6, $"Your time is {WinnerTime} seconds");


         Text newfirstpagetext4 = new Text(0, 0, 40, 10, $"Results from previous Games");

            Results = DbConnection.ReadFromDb(GameLevel(NrOfMines));

           
            int place = 12;

            foreach (string item in Results)
            {
                //Console.WriteLine(item);
                Text ResultsFromDb = new Text(0, 0, 40, place, item);
            
                place += 1;
            }

         Text Beginner = new Text(0, 0, 40, 21, "Press R for Reply");
         Text Medium = new Text(0, 0, 40, 22, "Press M for Main Menu");
         Text Difficult = new Text(0, 0, 40, 23, "Press Esc to Quit");

         Text newfirstpagetext3 = new Text(0, 0, 30, 8, "Please enter your name: ");
         Console.SetCursorPosition(27, 8);
         string Name = Console.ReadLine();

         DbConnection.WritetoDb(Name, WinnerTime, GameLevel(NrOfMines));
         Results = DbConnection.ReadFromDb(GameLevel(NrOfMines));

        place = 12;

        foreach (string item in Results)
        {
            //Console.WriteLine(item);
            Text ResultsFromDb = new Text(0, 0, 40, place, item);

            place += 1;
        }



            Console.CursorVisible = false;
        }

        public string GameLevel (int NrOfMines)
        {
            string Level = "";
            if (NrOfMines == 10)
            {
                Level = "Beginner";
            }
            else if (NrOfMines == 40)
            {
                Level = "Medium";
            }
            else
            {
                Level = "Difficult";
            }
            return Level;
        }
    }
}
