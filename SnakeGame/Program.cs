using static System.Console;

namespace SnakeGame
{
    internal class Program
    {
        static void Main()
        {
            //all credits to Gregory Gu 2022 B)

            //Console.SetBufferSize(150, 200);
            Title = "Snake Game";

            CursorVisible = false;

            //CursorSize = 100;

            SetWindowSize(115, 35);

            Settings.restore_settings();

            Game.play();


            //for troubleshooting positions on the console window
            /*
            SetCursorPosition(Grid.print_center.x, Grid.print_center.y); Write("o");
            
            SetCursorPosition(Grid.print_center.x - (105 / 2), Grid.print_center.y); Write("o");
            
            SetCursorPosition(Grid.print_center.x + (105 / 2), Grid.print_center.y); Write("o");
            
            SetCursorPosition(Grid.print_center.x, Grid.print_center.y - (30 / 2)); Write("o");
            
            SetCursorPosition(Grid.print_center.x, Grid.print_center.y + (30 / 2)); Write("o");
            
            SetCursorPosition(Grid.print_center.x - (105 / 2), Grid.print_center.y - (30 / 2)); Write("o");
            
            SetCursorPosition(Grid.print_center.x - (105 / 2), Grid.print_center.y + (30 / 2)); Write("o");
            
            SetCursorPosition(Grid.print_center.x + (105 / 2), Grid.print_center.y - (30 / 2)); Write("o");
            
            SetCursorPosition(Grid.print_center.x + (105 / 2), Grid.print_center.y + (30 / 2)); Write("o");

            ReadLine();
            */


            //shuffle list of all coordinates
            // 1,1  1,2  2,1  2,2 -> out
            //https://qawithexperts.com/article/c-sharp/async-await-keyword-in-c-explained-with-console-application/214


        }


    }
}
