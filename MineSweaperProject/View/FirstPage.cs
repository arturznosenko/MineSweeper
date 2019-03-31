using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class FirstPage
    {
       

        public FirstPage()
        {
            
            GUI newfirstpage = new GUI(0, 0, 40, 25);

            newfirstpage.Render('*');
            Text newfirstpagetext = new Text(0, 0, 40, 4, "MineSweeperGame 2019");
            Text Text = new Text(0, 0, 40, 8, "Choose your level and press Enter");
            Text Beginner = new Text(0, 0, 40, 12, "Beginner 12x7 (10 mines)");
            Text Medium = new Text(0, 0, 40, 14, "Medium 20x13 (40 mines)");
            Text Difficult = new Text(0, 0, 40, 16, "Difficult 30x16 (99 mines)");
            
        }

        public void RenderBeginner ()
        {
            Text Beginner = new Text(0, 0, 40, 12, "Beginner 12x7 (10 mines)");
        }

        public void RenderMedium()
        {
            Text Medium = new Text(0, 0, 40, 14, "Medium 20x13 (40 mines)");
        }

        public void RenderDifficult()
        {
            Text Difficult = new Text(0, 0, 40, 16, "Difficult 30x16 (99 mines)");
        }
    }
}
