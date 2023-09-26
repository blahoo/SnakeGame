using System;
using System.Threading;
using System.Collections;

namespace SnakeGame
{
    internal static class Screen
    {
        public static void startScreen()
        {
            Console.WriteLine("\n\n    ______                       __                           ______                                   \r" +
                            "\n   /      \\                     /  |                         /      \\                                  \r" +
                            "\n  /$$$$$$  | _______    ______  $$ |   __   ______          /$$$$$$  | ______   _____  ____    ______  \r" +
                            "\n  $$ \\__$$/ /       \\  /      \\ $$ |  /  | /      \\  ______ $$ | _$$/ /      \\ /     \\/    \\  /      \\ \r" +
                            "\n  $$      \\ $$$$$$$  | $$$$$$  |$$ |_/$$/ /$$$$$$  |/      |$$ |/    |$$$$$$  |$$$$$$ $$$$  |/$$$$$$  |\r" +
                            "\n   $$$$$$  |$$ |  $$ | /    $$ |$$   $$<  $$    $$ |$$$$$$/ $$ |$$$$ |/    $$ |$$ | $$ | $$ |$$    $$ |\r" +
                            "\n  /  \\__$$ |$$ |  $$ |/$$$$$$$ |$$$$$$  \\ $$$$$$$$/         $$ \\__$$ /$$$$$$$ |$$ | $$ | $$ |$$$$$$$$/ \r" +
                            "\n  $$    $$/ $$ |  $$ |$$    $$ |$$ | $$  |$$       |        $$    $$/$$    $$ |$$ | $$ | $$ |$$       |\r" +
                            "\n   $$$$$$/  $$/   $$/  $$$$$$$/ $$/   $$/  $$$$$$$/          $$$$$$/  $$$$$$$/ $$/  $$/  $$/  $$$$$$$/ ");

            while (true)
            {
                if (Console.KeyAvailable) { if (Console.ReadKey(true).Key == ConsoleKey.Escape) { Environment.Exit(0); } break; }

                Console.SetCursorPosition(41, 12);
                Console.WriteLine("Press any key to Start!");
                Thread.Sleep(600);

                if (Console.KeyAvailable) { if (Console.ReadKey(true).Key == ConsoleKey.Escape) { Environment.Exit(0); } break; }

                Console.SetCursorPosition(41, 12);
                Console.WriteLine("                       ");
                Thread.Sleep(500);
            }
        }
        public static void exitScreen()
        {
            Console.Clear();

            Console.WriteLine("\n\n    ______                       __                           ______                                   \r" +
                            "\n   /      \\                     /  |                         /      \\                                  \r" +
                            "\n  /$$$$$$  | _______    ______  $$ |   __   ______          /$$$$$$  | ______   _____  ____    ______  \r" +
                            "\n  $$ \\__$$/ /       \\  /      \\ $$ |  /  | /      \\  ______ $$ | _$$/ /      \\ /     \\/    \\  /      \\ \r" +
                            "\n  $$      \\ $$$$$$$  | $$$$$$  |$$ |_/$$/ /$$$$$$  |/      |$$ |/    |$$$$$$  |$$$$$$ $$$$  |/$$$$$$  |\r" +
                            "\n   $$$$$$  |$$ |  $$ | /    $$ |$$   $$<  $$    $$ |$$$$$$/ $$ |$$$$ |/    $$ |$$ | $$ | $$ |$$    $$ |\r" +
                            "\n  /  \\__$$ |$$ |  $$ |/$$$$$$$ |$$$$$$  \\ $$$$$$$$/         $$ \\__$$ /$$$$$$$ |$$ | $$ | $$ |$$$$$$$$/ \r" +
                            "\n  $$    $$/ $$ |  $$ |$$    $$ |$$ | $$  |$$       |        $$    $$/$$    $$ |$$ | $$ | $$ |$$       |\r" +
                            "\n   $$$$$$/  $$/   $$/  $$$$$$$/ $$/   $$/  $$$$$$$/          $$$$$$/  $$$$$$$/ $$/  $$/  $$/  $$$$$$$/ ");

            Console.SetCursorPosition(46, 12);
            Console.WriteLine(" Exiting... \n");
        }
        //----------------------------------------//----------------------------------------//


        /*  
         *  +--------------------------------------------------------+ 
         *  |           ____            _             _              |
         *  |          / ___|___  _ __ | |_ _ __ ___ | |___          |
         *  |         | |   / _ \| '_ \| __| '__/ _ \| / __|         |          
         *  |         | |__| (_) | | | | |_| | | (_) | \__ \         |
         *  |          \____\___/|_| |_|\__|_|  \___/|_|___/         |
         *  |                                                        | 
         *  |                (Any key to Continue)::                 |
         *  |                                                        |
         *  |                                                        | 
         *  |                                                        |
         *  |       .---.                               ,-----,      | 
         *  |       |esc| <[Exit]              [Pause]> |  <-'|      | 
         *  |       '---'            ,---,               |    |      | 
         *  |                 [UP]>  | W |               |    |      | 
         *  |                     ,--',--',---,          '----'      | 
         *  |             [LEFT]> | A | S | D | <[RIGHT]             | 
         *  |                     '---'---'---'                      | 
         *  |                           ^                            |
         *  |                        [DOWN]                          |
         *  |                                                        |
         *  |                                                        | 
         *  |                                                        |
         *  +--------------------------------------------------------+ 
         */

        public static string[] control_screen = {"+--------------------------------------------------------+",
                                                 "|           ____            _             _              |",
                                                 "|          / ___|___  _ __ | |_ _ __ ___ | |___          |",
                                                 "|         | |   / _ \\| '_ \\| __| '__/ _ \\| / __|         |",
                                                 "|         | |__| (_) | | | | |_| | | (_) | \\__ \\         |",
                                                 "|          \\____\\___/|_| |_|\\__|_|  \\___/|_|___/         |",
                                                 "|                                                        |",
                                                 "|               (Press any key to Continue)::            |",
                                                 "|                                                        |",
                                                 "|                                                        |",
                                                 "|                                                        |",
                                                 "|       .---.                               ,-----,      |",
                                                 "|       |esc| <[Exit]              [Pause]> |  <-'|      |",
                                                 "|       '---'                                |    |      |",
                                                 "|                        ,---,               |    |      |",
                                                 "|                 [UP]>  | W |               '----'      |",
                                                 "|                     ,--',--',---,                      |",
                                                 "|             [LEFT]> | A | S | D | <[RIGHT]             |",
                                                 "|                     '---'---'---'                      |",
                                                 "|                           ^                            |",
                                                 "|                        [DOWN]                          |",
                                                 "|                                                        |",
                                                 "|                                                        |",
                                                 "+--------------------------------------------------------+"};
        public static void tutorialScreen()
        {
            Console.Clear();

            for (int i = 0; i < control_screen.Length; i++)
            {
                Console.SetCursorPosition(Grid.print_center.x - (58 / 2), Grid.print_center.y - (24 / 2) + i);
                Console.WriteLine(control_screen[i]);
            }

            if (Console.ReadKey(true).Key == ConsoleKey.Escape) { Environment.Exit(0); }
        }
        //----------------------------------------//----------------------------------------//


        /*     
         *  +--------------------------------------------------------+ 
         *  |          ____       _   _   _                          |
         *  |         / ___|  ___| |_| |_(_)_ __   __ _ ___          |
         *  |         \___ \ / _ \ __| __| | '_ \ / _` / __|         |          
         *  |          ___) |  __/ |_| |_| | | | | (_| \__ \         |
         *  |         |____/ \___|\__|\__|_|_| |_|\__, |___/         |
         *  |                                     |___/              | 
         *  |                                                        |
         *  |           (ENTER) exit     (E) save and exit           |
         *  |      --------------------------------------------      |
         *  |              (key) [True/False]> Setting               |
         *  |                                                        |
         *  |           Gamemode:             Sounds:                |
         *  |          (1) [ ]> boundless    (6) [ ]> sfx            |
         *  |          (2) [ ]> endless      (7) [ ]> music          |
         *  |          (3) [ ]> duplicate                            |
         *  |                                                        |
         *  |           Start:                Playzone:              |
         *  |          (4) [ ]> long snake   (8) [ ]> high speed     |
         *  |          (5) [ ]> extra food   (9) [ ]> full play      |
         *  |                                                        |
         *  |                 (0) Restore Defaults                   |
         *  |                                                        |
         *  +--------------------------------------------------------+ 
         */

        public static string[] settings_screen = {"+--------------------------------------------------------+",
                                                  "|          ____       _   _   _                          |",
                                                  "|         / ___|  ___| |_| |_(_)_ __   __ _ ___          |",
                                                  "|         \\___ \\ / _ \\ __| __| | '_ \\ / _` / __|         |",
                                                  "|          ___) |  __/ |_| |_| | | | | (_| \\__ \\         |",
                                                  "|         |____/ \\___|\\__|\\__|_|_| |_|\\__, |___/         |",
                                                  "|                                     |___/              |",
                                                  "|                                                        |",
                                                  "|           (ENTER) exit     (E) save & newgame          |",
                                                  "|      --------------------------------------------      |",
                                                  "|              (key) [True/False]> Setting               |",
                                                  "|                                                        |",
                                                  "|           Gamemode:             Sounds:                |",
                                                  "|          (1) [ ]> boundless    (6) [ ]> effects        |",
                                                  "|          (2) [ ]> endless      (7) [ ]> music          |",
                                                  "|          (3) [ ]> duplicate                            |",
                                                  "|                                                        |",
                                                  "|           Start:                Playzone:              |",
                                                  "|          (4) [ ]> long snake   (8) [ ]> high speed     |",
                                                  "|          (5) [ ]> extra food   (9) [ ]> full grid      |",
                                                  "|      --------------------------------------------      |",
                                                  "|              (0) Restore Defaults & exit               |",
                                                  "|                                                        |",
                                                  "+--------------------------------------------------------+"};

        public static void settingsScreen()
        {
            BitArray temp_settings = new BitArray(9);

            bool on_screen = true;
            ConsoleKeyInfo key;




            Console.Clear();

            for (int i = 0; i < settings_screen.Length; i++)
            {
                Console.SetCursorPosition(Grid.print_center.x - (58 / 2), Grid.print_center.y - (24 / 2) + i);
                Console.WriteLine(settings_screen[i]);
            }

            Console.SetCursorPosition(39, 16); if (Settings.boundless_mode) { Console.Write("T"); } else { Console.Write("F"); }; //boundless
            temp_settings[0] = Settings.boundless_mode;
            Console.SetCursorPosition(39, 17); if (Settings.endless_mode) { Console.Write("T"); } else { Console.Write("F"); }; //endless
            temp_settings[1] = Settings.endless_mode;
            Console.SetCursorPosition(39, 18); if (Settings.duplicate_mode) { Console.Write("T"); } else { Console.Write("F"); }; //duplicate
            temp_settings[2] = Settings.duplicate_mode;

            Console.SetCursorPosition(39, 21); if (Settings.long_snake) { Console.Write("T"); } else { Console.Write("F"); }; //long snake 
            temp_settings[3] = Settings.long_snake;
            Console.SetCursorPosition(39, 22); if (Settings.extra_food) { Console.Write("T"); } else { Console.Write("F"); }; //extra food
            temp_settings[4] = Settings.extra_food;

            Console.SetCursorPosition(61, 16); if (Settings.sfx) { Console.Write("T"); } else { Console.Write("F"); }; //sfx
            temp_settings[5] = Settings.sfx;
            Console.SetCursorPosition(61, 17); if (Settings.msc) { Console.Write("T"); } else { Console.Write("F"); }; //music
            temp_settings[6] = Settings.msc;

            Console.SetCursorPosition(61, 21); if (Settings.high_speed) { Console.Write("T"); } else { Console.Write("F"); }; //high speed
            temp_settings[7] = Settings.high_speed;
            Console.SetCursorPosition(61, 22); if (Settings.full_grid) { Console.Write("T"); } else { Console.Write("F"); }; //full play
            temp_settings[8] = Settings.full_grid;


            while (on_screen)
            {

                if (Console.KeyAvailable)
                {

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case (ConsoleKey.D1): //boundless
                            Console.SetCursorPosition(39, 16); if (temp_settings[0]) { temp_settings[0] = false; temp_settings[1] = false; Console.Write("F"); } else { temp_settings[0] = true; Console.Write("T"); };
                            Console.SetCursorPosition(39, 17); if (!temp_settings[1]) { Console.Write("F"); } //if boundless is off, endless will be off
                            break;
                        case (ConsoleKey.D2): //endless
                            Console.SetCursorPosition(39, 17); if (temp_settings[1]) { temp_settings[1] = false; Console.Write("F"); } else { temp_settings[1] = true; temp_settings[0] = true; temp_settings[2] = false; Console.Write("T"); };
                            Console.SetCursorPosition(39, 16); if (temp_settings[0]) { Console.Write("T"); } //if endless is on, boundless will be on
                            Console.SetCursorPosition(39, 18); if (!temp_settings[2]) { Console.Write("F"); } //if endless is on, duplicate will be off
                            break;
                        case (ConsoleKey.D3): //duplicate
                            Console.SetCursorPosition(39, 18); if (temp_settings[2]) { temp_settings[2] = false; Console.Write("F"); } else { temp_settings[2] = true; temp_settings[1] = false; Console.Write("T"); };
                            Console.SetCursorPosition(39, 17); if (!temp_settings[1]) { Console.Write("F"); } //if duplicate is on, endless will be off
                            break;
                        case (ConsoleKey.D4): //long snake
                            Console.SetCursorPosition(39, 21); if (temp_settings[3]) { temp_settings[3] = false; Console.Write("F"); } else { temp_settings[3] = true; Console.Write("T"); };
                            break;
                        case (ConsoleKey.D5): //extra food
                            Console.SetCursorPosition(39, 22); if (temp_settings[4]) { temp_settings[4] = false; Console.Write("F"); } else { temp_settings[4] = true; Console.Write("T"); };
                            break;
                        case (ConsoleKey.D6): //sfx
                            Console.SetCursorPosition(61, 16); if (temp_settings[5]) { temp_settings[5] = false; Console.Write("F"); } else { temp_settings[5] = true; Console.Write("T"); };
                            break;
                        case (ConsoleKey.D7): //music
                            Console.SetCursorPosition(61, 17); if (temp_settings[6]) { temp_settings[6] = false; Console.Write("F"); } else { temp_settings[6] = true; Console.Write("T"); };
                            break;
                        case (ConsoleKey.D8): //high speed
                            Console.SetCursorPosition(61, 21); if (temp_settings[7]) { temp_settings[7] = false; Console.Write("F"); } else { temp_settings[7] = true; Console.Write("T"); };
                            break;
                        case (ConsoleKey.D9): //full grid
                            Console.SetCursorPosition(61, 22); if (temp_settings[8]) { temp_settings[8] = false; Console.Write("F"); } else { temp_settings[8] = true; Console.Write("T"); };
                            break;
                        case (ConsoleKey.D0): //restore defaults
                            Settings.restore_defaults();
                            on_screen = false;
                            Game.play();
                            break;
                        case (ConsoleKey.E): //save and newgame
                            Settings.set_settings(temp_settings);
                            on_screen = false;
                            Game.play();
                            break;
                        case (ConsoleKey.Enter): //exit
                            on_screen = false;
                            break;
                        case (ConsoleKey.Escape): //exit application
                            Environment.Exit(0);
                            break;

                    }                        
                    if (key.Key == ConsoleKey.Escape) { Environment.Exit(0); }
                }
            }
        }
        //----------------------------------------//----------------------------------------//

        /*  
        *  +--------------------------------------------------------+ 
        *  |    ____                                                |
        *  |   / ___| _   _ _ __ ___  _ __ ___   __ _ _ __ _   _    |
        *  |   \___ \| | | | '_ ` _ \| '_ ` _ \ / _` | '__| | | |   |
        *  |    ___) | |_| | | | | | | | | | | | (_| | |  | |_| |   |
        *  |   |____/ \__,_|_| |_| |_|_| |_| |_|\__,_|_|   \__, |   |
        *  |                                               |___/    |      
        *  |                (Press E for new game)::                |
        *  |         --------------------------------------         | 
        *  |                                                        |
        *  |              SCORE:                                    | 
        *  |                                                        | 
        *  |               TIME:                                    | 
        *  |                                                        | 
        *  |               FOOD:                                    |
        *  |                                                        | 
        *  |           GAMEMODE:                                    | 
        *  |                                                        | 
        *  |              EXTRA:                                    |
        *  |                                                        |
        *  |         --------------------------------------         | 
        *  |               esc or any key to exit                   |
        *  |                                                        |
        *  +--------------------------------------------------------+ 
        */

        public static string[] summary_screen = {"+--------------------------------------------------------+",
                                                 "|    ____                                                |",
                                                 "|   / ___| _   _ _ __ ___  _ __ ___   __ _ _ __ _   _    |",
                                                 "|   \\___ \\| | | | '_ ` _ \\| '_ ` _ \\ / _` | '__| | | |   |",
                                                 "|    ___) | |_| | | | | | | | | | | | (_| | |  | |_| |   |",
                                                 "|   |____/ \\__,_|_| |_| |_|_| |_| |_|\\__,_|_|   \\__, |   |",
                                                 "|                                               |___/    |",
                                                 "|                (Press E for new game)::                |",
                                                 "|         --------------------------------------         |",
                                                 "|                                                        |",
                                                 "|              SCORE:                                    |",
                                                 "|                                                        |",
                                                 "|               TIME:                                    |",
                                                 "|                                                        |",
                                                 "|               FOOD:                                    |",
                                                 "|                                                        |",
                                                 "|           GAMEMODE:                                    |",
                                                 "|                                                        |",
                                                 "|              EXTRA:                                    |",
                                                 "|                                                        |",
                                                 "|         --------------------------------------         |",
                                                 "|               ESC or any key to exit                   |",
                                                 "|                                                        |",
                                                 "+--------------------------------------------------------+"};
        

        public static void resultScreen()
        {
            Console.Clear();

            for (int i = 0; i < summary_screen.Length; i++)
            {
                Console.SetCursorPosition(Grid.print_center.x - (58 / 2), Grid.print_center.y - (24 / 2) + i);
                Console.Write(summary_screen[i]);
            }

            Console.SetCursorPosition(45, 13); Console.Write(Game.score);
            Console.SetCursorPosition(45, 15);
            if (Game.sec < 10 && Game.min < 10) { Console.Write($"0{Game.min}:0{Game.sec}"); }
            else if (Game.sec < 10) { Console.Write($"{Game.min}:0{Game.sec}"); }
            else if (Game.min < 10) { Console.Write($"0{Game.min}:{Game.sec}"); }
            else { Console.Write($"{Game.min}:{Game.sec}"); }

            Console.SetCursorPosition(45, 17); Console.Write(Food.food_collected);
            Console.SetCursorPosition(45, 19);
            if (Settings.high_speed || Settings.full_grid) { Console.Write("Altered "); }
            
            if (Settings.endless_mode) { Console.Write("Endless"); }
            else if (Settings.boundless_mode && Settings.duplicate_mode) { Console.Write("Chaos"); }
            else if (Settings.boundless_mode) { Console.Write("Boundless"); }
            else if (Settings.duplicate_mode) { Console.Write("Duplicate"); }
            else { Console.Write("Classic"); }

            Console.SetCursorPosition(45, 21);
            if (Settings.extra_food && Settings.long_snake) { Console.Write("Food & Length"); }
            else if (Settings.extra_food) { Console.Write("Food"); }
            else if (Settings.long_snake) { Console.Write("Length"); }
            else { Console.Write("-"); }

            if (Console.ReadKey(false).Key == ConsoleKey.E) { Game.play(); }
        }
        //----------------------------------------//----------------------------------------//

        /*  
         *  +---------------------------------+ 
         *  |    _____                        | 
         *  |   |  __ \                       | 
         *  |   | |__) |_ _ _   _ ___  ___    | 
         *  |   |  ___/ _` | | | / __|/ _ \   | 
         *  |   | |  | (_| | |_| \__ \  __/   | 
         *  |   |_|   \__,_|\__,_|___/\___|   | 
         *  |                                 | 
         *  |   [W] [S] [ENTER] > Navagate    | 
         *  |                                 | 
         *  |          Resume Game            | 
         *  |          New Game               | 
         *  |          Toggle Sound           | 
         *  |     '->  Controls               | 
         *  |          Settings               | 
         *  |                                 | 
         *  +---------------------------------+ 
         */


        public static string[] pause_menu = {"+---------------------------------+",
                                             "|    _____                        |",
                                             "|   |  __ \\                       |",
                                             "|   | |__) |_ _ _   _ ___  ___    |",
                                             "|   |  ___/ _` | | | / __|/ _ \\   |",
                                             "|   | |  | (_| | |_| \\__ \\  __/   |",
                                             "|   |_|   \\__,_|\\__,_|___/\\___|   |",
                                             "|                                 |",
                                             "|   [W] [S] [ENTER] > Navigate    |",
                                             "|                                 |",
                                             "|          Resume Game            |",
                                             "|          New Game               |",
                                             "|          Toggle Sound           |",
                                             "|          Controls               |",
                                             "|          Settings               |",
                                             "|                                 |",
                                             "+---------------------------------+" };

        private static string selection_icon = "\'->";
        //0: Resume, 1: New Game, 2: Toggle Sound, 3: Controls, 4: Settings 
        private static int selection;
        private static void reprintPauseScreen()
        {
            //reprints the background game state and the previous pause screen

            Console.Clear();

            Game.printScore();
            Grid.printBorder();
            Grid.printGrid();

            for (int i = 0; i < pause_menu.Length; i++)
            {
                Console.SetCursorPosition(Grid.print_center.x - (35 / 2), Grid.print_center.y - (17 / 2) + i + 2);
                Console.WriteLine(pause_menu[i]);
            }

            Console.SetCursorPosition(Grid.print_center.x - 11, Grid.print_center.y + 4 + selection);
            Console.WriteLine(selection_icon);
        }
    
        public static void pauseScreen(ref bool paused)
        {
            paused = true;

            selection = 0;

            ConsoleKeyInfo key;
            int key_held = 0;
            int old_selection = -1;
            bool temp_paused = true;


            for (int i = 0; i < pause_menu.Length; i++)
            {
                Console.SetCursorPosition(Grid.print_center.x - (35 / 2), Grid.print_center.y - (17 / 2) + i + 2);
                Console.WriteLine(pause_menu[i]);
            }

            Console.SetCursorPosition(Grid.print_center.x - 11, Grid.print_center.y + 4 + selection);
            Console.WriteLine(selection_icon);


            while (temp_paused)
            {

                if (Console.KeyAvailable)
                {

                    key = Console.ReadKey(true);


                    if (key.Key == ConsoleKey.W && !(selection == 0))
                    {
                        Console.SetCursorPosition(Grid.print_center.x - 11, Grid.print_center.y + 4 + selection);
                        Console.WriteLine("   ");
                        selection--;
                        Console.SetCursorPosition(Grid.print_center.x - 11, Grid.print_center.y + 4 + selection);
                        Console.WriteLine(selection_icon);
                    }
                    if (key.Key == ConsoleKey.S && !(selection == 4))
                    {
                        Console.SetCursorPosition(Grid.print_center.x - 11, Grid.print_center.y + 4 + selection);
                        Console.WriteLine("   ");
                        selection++;
                        Console.SetCursorPosition(Grid.print_center.x - 11, Grid.print_center.y + 4 + selection);
                        Console.WriteLine(selection_icon);
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {


                        if (selection == old_selection) { key_held++; }
                        else { key_held = 0; }

                        switch (selection)
                        {
                            case (0): //Resume
                                temp_paused = false;
                                break;
                            case (1): //New Game
                                Game.play();
                                break;
                            case (2): //Toggle Sound
                                if (Settings.sfx || Settings.msc) { Settings.sfx = false; Settings.msc = false; break; }
                                if (!(Settings.sfx || Settings.msc)) { Settings.sfx = true; Settings.msc = true; break; }
                                break;
                            case (3): //Controls
                                if (key_held >= 3) { break; }
                                old_selection = selection;

                                tutorialScreen();
                                reprintPauseScreen();
                                break;
                            case (4): //Settings
                                if (key_held >= 3) { break; }
                                old_selection = selection;

                                settingsScreen();
                                reprintPauseScreen();
                                break;
                        }
                    }
                    if (key.Key == ConsoleKey.Escape) { Environment.Exit(0); }
                }
            }

            Console.Clear();

            //prints the score, border, and last game state
            Game.printScore();
            Grid.printBorder();
            Grid.printGrid();

            string[] nums = { "  ___  ",
                              " (__ ) ",
                              "  (_ \\ ",
                              " (___/ ",
                              "  ___  ",
                              " (__ \\ ",
                              "  / _/ ",
                              " (___) ",
                              "  ___  ",
                              " /   | ",
                              "  | |  ",
                              " (___) " };

            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    Console.SetCursorPosition(Grid.print_center.x - 3, Grid.print_center.y - 2 + j);

                    Console.Write(nums[i * 4 + j]);

                }

                Thread.Sleep(1000);

            }
            paused = false;
        }
    }
}
