using System;
using System.Collections;
using System.IO;

namespace SnakeGame
{
    static class Settings //the settings of the game compiled in one spot for convenience and edit ability
    {
        //playzone size
        public static int width;
        public static int height;
        public static bool full_grid
        {
            get
            {
                if (width == 30 && height == 30)
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value == true)
                {
                    width = 49;
                    height = 30;
                }
                else
                {
                    width = 25;
                    height = 20;
                }
            }
        }

        //start 
        public static int start_length;
        public static bool long_snake 
        {
            get
            {
                if (start_length == 7)
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value == true)
                {
                    start_length = 7;
                }
                else
                {
                    start_length = 3;
                }
            }
        }

        public static int start_food;
        public static bool extra_food 
        {
            get
            {
                if (start_food == 5)
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value == true)
                {
                    start_food = 5;
                }
                else
                {
                    start_food = 1;
                }
            }
        }

        //sound
        public static bool sfx;
        public static bool msc;

        //gamemode
        public static bool duplicate_mode;
        public static bool boundless_mode;
        private static bool endless;
        public static bool endless_mode
        {
            get
            {
                if (boundless_mode && endless)
                {
                    return endless;
                }

                endless = false;
                return endless;
            }
            set
            {
                endless = value;
            }
        }

        //speed variables and calculations (delay between frames)
        private static int start_delay = 200;
        private static int max_delay = 50;
        private static int delay_increment;
        public static int frame_delay
        {
            get
            {
                if ((start_delay - (delay_increment * Food.food_collected)) < max_delay)
                {
                    return max_delay;
                }
                return start_delay - (delay_increment * Food.food_collected);
            }
        }
        public static bool high_speed
        {
            get
            {
                if (delay_increment == 8)
                {
                    return true;
                } 
                return false;
            }
            set
            {
                if (value == true)
                {
                    delay_increment = 8;
                }
                else
                {
                    delay_increment = 4;
                }
            }
        }

        public static string save_path = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName) + "\\Save_Data.txt";
        public static void restore_settings()
        {
            string from_save = File.ReadAllText(save_path);

            BitArray restored_settings = new BitArray(9);

            for (int i = 0; i < from_save.Length; i++)
            {
                if (from_save[i] == '1') { restored_settings[i] = true; }
                else { restored_settings[i] = false; }
            }

            boundless_mode = restored_settings[0];
            endless_mode = restored_settings[1];
            duplicate_mode = restored_settings[2];

            long_snake = restored_settings[3];
            extra_food = restored_settings[4];

            sfx = restored_settings[5];
            msc = restored_settings[6];

            high_speed = restored_settings[7];
            full_grid = restored_settings[8];
        }
        public static void save_settings(string settings)
        {
            File.WriteAllText(save_path, settings);
        }
        public static void set_settings(BitArray new_settings)
        {
            boundless_mode = new_settings[0];
            endless_mode = new_settings[1];
            duplicate_mode = new_settings[2];

            long_snake = new_settings[3];
            extra_food = new_settings[4];

            sfx = new_settings[5];
            msc = new_settings[6];

            high_speed = new_settings[7];
            full_grid = new_settings[8];

            string to_save = "";

            foreach (bool i in new_settings)
            {
                if (i) { to_save += "1"; }
                else { to_save += "0"; }
            }
            
            save_settings(to_save);
        }
        public static void restore_defaults()
        {
            boundless_mode = Default.boundless_mode;
            endless_mode = Default.endless_mode;
            duplicate_mode = Default.duplicate_mode;

            long_snake = Default.long_snake;
            extra_food = Default.extra_food;

            sfx = Default.sfx;
            msc = Default.msc;

            high_speed = Default.high_speed;
            full_grid = Default.full_grid;

            string to_save = "000001100";

            save_settings(to_save);
        }
        public static class Default //default settings
        {
            //grid settings and variables
            public static readonly string border_char = "::";
            public static readonly string backgound_char = "  ";

            public static readonly int width = 50; 
            public static readonly int height = 25;
            public static readonly bool full_grid = false;

            //snake characters and start length
            public static readonly string body_char = "()";
            public static readonly string head_char = "::";
            public static readonly int start_length = 3;
            public static readonly bool long_snake = false;

            //food character and start amount
            public static readonly string food_char = "$" + (char)178;
            public static readonly int start_food = 5;
            public static readonly bool extra_food = false;

            //start and lose messages
            public static readonly string start_msg = " press any key to start! ";
            public static readonly string lost_msg = " you lost :( ";
            public static readonly string win_msg = " you win :) ";

            //sounds on or off
            public static readonly bool sfx = true;
            public static readonly bool msc = true;

            //gamemode
            public static readonly bool boundless_mode = false;
            public static readonly bool duplicate_mode = false;
            public static readonly bool endless_mode = false;

            //speed
            public static readonly int start_delay = 100;
            public static readonly int max_delay = 50;
            public static readonly int delay_increment = 4;
            public static bool high_speed = false;

        }
    }
} 