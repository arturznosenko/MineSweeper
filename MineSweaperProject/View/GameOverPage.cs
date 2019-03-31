using MineSweaperProject.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class GameOverPage
    {

        public GameOverPage (GameBoard GameBoard , int Lenght, int Height)

        {
            Console.ForegroundColor = ConsoleColor.White;

            GUI newfirstpage = new GUI(0, 0, 40, 25);
            newfirstpage.Render('*');

            Console.ForegroundColor = ConsoleColor.Red;
            Text newfirstpagetext = new Text(0, 0, 40, 2, "Game Over");
            Console.ForegroundColor = ConsoleColor.White;
           
            Text Reply = new Text(0, 0, 40, 21, "Press R for Reply");
            Text MainMenu = new Text(0, 0, 40, 22, "Press M for Main Menu");
            Text Esc = new Text(0, 0, 40, 23, "Press Esc to Quit");

            GameOverView newGameOverView = new GameOverView(GameBoard, Lenght, Height);
        }
    }
}
