using System;
using System.Linq;
using System.Media;
using System.Threading;

namespace SnakeGame
{
    static class Game
    {
        private static SoundPlayer soundPlayer = new SoundPlayer("TheProcess.wav"); //soundplayer and file to play music

        private static bool first_run = true;

        //game play variables
        private static bool lost;
        private static bool got_food;
        private static bool paused;
        private static int pause_time; //counter to prevent from blocking game by holding pause button

        private static int delay { get => Settings.frame_delay; }
        private static int converted_score;
        public static int score 
        {
            get 
            {
                return converted_score;
            }
            set
            {
                if (value == 0) { converted_score = 0; return; }


                if (endless_on)
                {
                    converted_score += 250;
                }
                else if (boundless_on)
                {
                    converted_score += 250;
                }
                else if (duplicate_on)
                {
                    converted_score += 150;
                }
                else
                {
                    converted_score += 250 + Convert.ToInt32(50 * time / 20);
                }
            }
        }


        private static int time_score;
        public static int time
        {
            get
            {
                return time_score;
            }
            set
            {
                if (value == 0) { time_score = 0; return; }
                else if (time_score >= 3599) { return; }
                
                time_score++; 
            }
        }
        public static int min { get => time / 60; }
        public static int sec { get => time % 60; }

        //input related variables
        private static bool input_cap;
        private static bool valid_input;
        private static int input_value;
        private static int old_value;
        private static ConsoleKeyInfo input;

        //sound
        public static bool sfx_on { get => Settings.sfx; }
        public static bool msc_on { get => Settings.msc; }

        //gamemode
        public static bool boundless_on { get => Settings.boundless_mode; }
        public static bool endless_on { get => Settings.endless_mode; }
        public static bool duplicate_on { get => Settings.duplicate_mode; }
        //----------------------------------------//----------------------------------------//
        public static Thread mscThread = new Thread(o => //thread to play sound effects and music when turned on
        {
            while (true) {
                if (msc_on) { soundPlayer.PlayLooping(); } //plays background music .wav file

                while (!lost)
                {
                    while (sfx_on && msc_on) 
                    {
                        if (got_food && sfx_on) { Console.Beep(1000, 50); } //plays a beep when food is collected
                    }

                    soundPlayer.Stop();

                    while (sfx_on && !msc_on)
                    {
                        if (got_food && sfx_on) { Console.Beep(1000, 50); } //plays a beep when food is collected
                    }

                    soundPlayer.PlayLooping();

                }
            }
        });
        public static Thread inputThread = new Thread(o => //specialized thread to take inputs (extra thread for extra cool program)
        {
            while (true)
            {
                while (!lost)
                {
                    while (input_cap || paused) { } //seperate statement since "Console.KeyAvailable" has too much delay
                
                    if (Console.KeyAvailable)
                    {
                        input = Console.ReadKey(true);
                        doInput(input);
                    }
                }
            }
        });
        public static Thread timeThread = new Thread(o => //thread to count the rough time of a game for the time score
        {
            while (true)
            {
                while (!lost)
                {
                    if (paused) { continue; }
                    Thread.Sleep(1000);
                    if (paused) { continue; }
                    time++;
                }
            }
        });
        //----------------------------------------//----------------------------------------//
        private static void startSequence(ref bool first_time)
        {
            paused = true;

            if (first_time)
            {
                inputThread.Start();
                mscThread.Start();
                timeThread.Start();

                Screen.startScreen();
                Screen.tutorialScreen(); 

                first_time = false;
            }

            Console.Clear();

            lost = false;
            got_food = false;
            
            score = 0;
            time = 0;

            pause_time = -1;
            input_cap = false;
            valid_input = false;
            input_value = 1;       

            Grid.newGrid();
            Grid.printBorder();

            Snake.reset();
            Food.clear_food();

            printScore();

            for (int i = 0; i < Snake.start_length; i++)
            {
                Snake.updateHead();
                Snake.add();
            }

            Food.generate(true, duplicate_on);
            
            newFrame();

            while (!Console.KeyAvailable) //start message and animation
            {

                Console.SetCursorPosition(Grid.print_center.x - (Settings.Default.start_msg.Length / 2),
                                          Grid.print_center.y - 2);

                Console.Write(Settings.Default.start_msg);
                Thread.Sleep(600);

                if (Console.KeyAvailable) { break; }

                Console.SetCursorPosition(Grid.print_center.x - (Settings.Default.start_msg.Length / 2),
                                          Grid.print_center.y - 2);

                for (int i = 0; i < Settings.Default.start_msg.Length; i++)
                {
                    Console.Write(" ");
                }    
                Thread.Sleep(500);
            }
            paused = false;
            doInput(Console.ReadKey(true));
        }
        private static void doInput(ConsoleKeyInfo input)
        {
            valid_input = false;

            
            switch (input.Key)
            {
                case (ConsoleKey.W): //up
                    input_value = -2;
                    valid_input = true;
                    break;
                case (ConsoleKey.A): //left
                    input_value = -1;
                    valid_input = true;
                    break;
                case (ConsoleKey.S): //down
                    input_value = 2;
                    valid_input = true;
                    break;
                case (ConsoleKey.D): //right
                    input_value = 1;
                    valid_input = true;
                    break;
                case (ConsoleKey.Enter): //pause
                    //mechanism to stop pause menu spam which can clog the input stream  
                    if (pause_time == time) { break; }
                    paused = true;
                    pause_time = time;
                    break;
                case (ConsoleKey.Escape): //exit
                    Environment.Exit(0);
                    break;
            }
            if (valid_input && (input_value != old_value))
            {
                input_cap = true;
                old_value = input_value;
                Snake.direction_check = input_value;
            }
        }
        private static void checkCollision(bool borderless, bool zen)
        {
            Snake.updateHead();

            foreach (Vector cell in Grid.border_cells)
            {
                if (Snake.borderless_check(borderless)) { break; }

                if (!(cell.x == Snake.head_coordinate.x && cell.y == Snake.head_coordinate.y)) { continue; }

                lost = true;
                break;


            }
            foreach (Vector cell in Snake.cells)
            {
                if (zen) { break; }

                if (!(cell.x == Snake.head_coordinate.x && cell.y == Snake.head_coordinate.y)) { continue; }

                lost = true;
                break;

            }
            foreach (Vector cell in Food.cells)
            {
                if (!(cell.x == Snake.head_coordinate.x && cell.y == Snake.head_coordinate.y)) { continue; }

                Food.cells.Remove(cell);

                got_food = true;
                break;

            }
        }
        private static void newFrame()
        {
            //clears the grid of game related vectors
            Grid.clearGrid();

            //fills the grid with snake vectors, snake head character, and food vectors 
            foreach (Vector v in Snake.cells)
            {
                if (v == Snake.cells.ElementAt(Snake.cells.Count - 1))
                {
                    Grid.grid[v.x, v.y] = Snake.head_char;
                }
                else
                {
                    Grid.grid[v.x, v.y] = Snake.body_char;
                }
            }
            foreach (Vector v in Food.cells)
            {
                Grid.grid[v.x, v.y] = Food.food_char;
            }

            Grid.printGrid(); //prints the game state

            printScore(); //prints the current score

        }
        public static void printScore()
        {
            Console.SetCursorPosition(Grid.origin_vector.x, Grid.origin_vector.y - 1);
            Console.WriteLine($" Score: {score}");

            Console.SetCursorPosition(Grid.origin_vector.x + Grid.width * 2 - 13, Grid.origin_vector.y - 1);
            Console.Write(" Time: ");

            if (sec < 10 && min < 10) { Console.WriteLine($"0{min}:0{sec}"); return; }
            else if (sec < 10) { Console.WriteLine($"{min}:0{sec}"); return; }
            else if (min < 10) { Console.WriteLine($"0{min}:{sec}"); return; }

            Console.WriteLine($"{min}:{sec}");
        }
        //----------------------------------------//----------------------------------------//
        public static void play() //main gameplay loop
        {

            startSequence(ref first_run);


            while (!lost)
            {

                if (paused) { Screen.pauseScreen(ref paused); }

                checkCollision(boundless_on, endless_on);

                if (lost) { break; }

                Snake.add();
                if (got_food)
                {
                    score++;
                    Food.food_collected++;

                    if (Snake.length + Food.food_count == Grid.grid_count) //win condition
                    {
                        Console.SetCursorPosition(Grid.print_center.x - (Settings.Default.win_msg.Length / 2),
                                      Grid.print_center.y - 2);

                        Console.WriteLine(Settings.Default.win_msg);

                        Console.ReadKey(true);

                        break;

                    }

                    Food.generate(false, duplicate_on);
                    got_food = false;

                    if (endless_on && Snake.length >= 25) { Snake.remove(); }
                }
                else
                {
                    Snake.remove();
                }

                newFrame();
                Thread.Sleep(delay);
                input_cap = false;

            }

            Console.SetCursorPosition(Grid.print_center.x - (Settings.Default.lost_msg.Length / 2),
                                      Grid.print_center.y - 2);

            Console.WriteLine(Settings.Default.lost_msg);

            Console.SetCursorPosition(Grid.print_center.x - 13,
                                      Grid.print_center.y - 1);

            Console.WriteLine(" Press ENTER to Continue ");

            while (true)
            {
                if (Console.KeyAvailable) { if (Console.ReadKey(true).Key == ConsoleKey.Escape) { Environment.Exit(0); } }
                else if (Console.ReadKey(true).Key == ConsoleKey.Enter) { break; }
            }
            Screen.resultScreen();

            Screen.exitScreen();

            Thread.Sleep(1000);

            Environment.Exit(0);
        }
    }
}
