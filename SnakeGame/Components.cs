using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Vector
    {
        //vector class to create coordinate objects
        public int x, y;
        public Vector(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }
    //----------------------------------------//----------------------------------------//
    static class Grid
    {
        //character of background and border of grid
        private static string border_char { get => Settings.Default.border_char; }
        private static string backgound_char { get => Settings.Default.backgound_char; }

        //width and height of the play grid
        public static int width { get => Settings.width; }
        public static int height { get => Settings.height; }

        public static string[,] grid;

        public static int grid_count;

        /*coordinates to print and place game cells as well as set coordinates to set the cursor position
         *these calculations are given a small layer of complexity since the default cell size is 1x2,
         *while the cursor position x and y is 1x1
         */

        //the vector coordinate of (0,0) for the game grid
        public static Vector origin_vector;

        //used mainly as starting point for the snake
        public static Vector center_vector;

        //vector center position of grid to be referenced for the cursor position certain messages, the window size / 2
        public static readonly Vector print_center = new Vector(105 / 2, 30 / 2);



        public static Queue<Vector> border_cells = new Queue<Vector>();

        public static void newGrid() //create the border vectors and coordinates of the game 
        {
            grid = new string[width, height];

            grid_count = width * height;

            origin_vector = new Vector((105 / 2 - 1) - (width / 2) * border_char.Length, (30 / 2) - (height / 2) + 2);
            center_vector = new Vector(width / 2, height / 2);

            border_cells.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((y == 0) || (x == 0) || (y == (height - 1)) || (x == (width - 1)))
                    {
                        border_cells.Enqueue(new Vector(x, y));
                    }
                }
            }

            clearGrid();

        }
        public static void printBorder() //prints the border of the game 
        {
            Console.SetCursorPosition(origin_vector.x, origin_vector.y);
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(origin_vector.x, origin_vector.y + y);
                for (int x = 0; x < width; x++)
                {
                    if ((y == 0) || (x == 0) || (y == (height - 1)) || (x == (width - 1)))
                    {
                        border_cells.Enqueue(new Vector(x, y));
                        Console.Write(border_char);
                    }
                    else
                    {
                        Console.Write(backgound_char);
                    }
                }
                Console.WriteLine();
            }
        }
        public static void printGrid() //prints the grid state
        {
            Console.SetCursorPosition(origin_vector.x + 1, origin_vector.y + 1);
            for (int y = 1; y < height - 1; y++)
            {
                Console.SetCursorPosition(origin_vector.x + border_char.Length, origin_vector.y + y);
                for (int x = 1; x < width - 1; x++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.WriteLine();
            }
        }
        public static void clearGrid() //clears all data from the grid
        {
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    grid[x, y] = backgound_char;
                }
            }
        }
    }
    //----------------------------------------//----------------------------------------//
    class Snake
    {
        //snake characters
        public static string body_char { get => Settings.Default.body_char; }
        public static string head_char { get => Settings.Default.head_char; }

        //snake length
        public static int start_length { get => Settings.start_length; }
        public static int length;

        public static Vector head_coordinate; //head coordinates

        //direction values
        private static int Direction; //1 - right, 2 - up, -1 - left, -2 - down 
        public static int direction_check //prevents direction from changing to opposite direction
        {
            get { return Direction; }
            set
            {

                if (!((value == 0) || (value * -1) == Direction) || (value == Direction))
                {
                    Direction = value;
                }
            }
        }

        public static Queue<Vector> cells = new Queue<Vector>(); //queue to hold snake coordinates

        public static void updateHead() //updates the head coordinated 
        {
            switch (Direction)
            {
                case (1):
                    head_coordinate.x++;
                    break;
                case (2):
                    head_coordinate.y++;
                    break;
                case (-1):
                    head_coordinate.x--;
                    break;
                case (-2):
                    head_coordinate.y--;
                    break;
            }
        }

        // when boderless mode is on, will teleport the head coordinate to the other side of the grid if touching border
        public static bool borderless_check(bool on)
        {
            if (!on) { return false; }

            if (head_coordinate.x == 0) { head_coordinate.x = Grid.width - 2; }
   
            if (head_coordinate.x == Grid.width - 1) { head_coordinate.x = 0; }

            if (head_coordinate.y == 0) { head_coordinate.y = Grid.height - 2; }

            if (head_coordinate.y == Grid.height - 1) { head_coordinate.y = 0; }

            return true;
        }
        public static void add() //adds the head coordinate to the queue
        {
            cells.Enqueue(new Vector(head_coordinate.x, head_coordinate.y));
            length++;
        }
        public static void remove() //removes the last coordinate in the queue
        {
            cells.Dequeue();
            length--;
        }
        public static void reset() //resets snake variables for a new game
        {
            head_coordinate = new Vector(0, 0);
            head_coordinate.x = Grid.center_vector.x - start_length;
            head_coordinate.y = Grid.center_vector.y;
            cells.Clear();
            length = 0;
            Direction = 1;
        }
    }
    //----------------------------------------//----------------------------------------//
    class Food
    {
        private static Vector test_coordinate; //random coordinate to be checked if available 

        public static string food_char { get => Settings.Default.food_char; } //food 

        public static int start_food { get => Settings.start_food; } //amount of starting food
        public static int food_count;
        public static int food_collected;


        public static List<Vector> cells = new List<Vector>(); //list of vectors to hold food coordinates

        public static int x, y;
        public static bool try_again;
        public static int amount_to_generate;
        public static Random random = new Random(); //use 1 random object otherwise it wont be random anymore

        public static void clear_food()
        {
            cells.Clear();
            food_count = 0;
        }

        public static void generate(bool first_run, bool duplicate_mode) //generates a valid food coordinate
        {
            if (first_run) { amount_to_generate = start_food; }
            else if (duplicate_mode) { amount_to_generate = 2; }
            else { amount_to_generate = 1; }

            for (int i = 0; i < amount_to_generate; i++) 
            {
                do
                {
                    try_again = false;

                    //dont create a new random object every iteration  
                    x = random.Next(Grid.width - 2) + 1;
                    y = random.Next(Grid.height - 2) + 1;
                    test_coordinate = new Vector(x, y);

                    //tests if coordinate is already in use
                    foreach (Vector cell in Snake.cells) //checks snake cells
                    {
                        if (cell.x == test_coordinate.x && cell.y == test_coordinate.y)
                        {
                            try_again = true;
                            break;
                        }
                    }
                    foreach (Vector cell in cells) //checks other food cells
                    {
                        if (cell.x == test_coordinate.x && cell.y == test_coordinate.y)
                        {
                            try_again = true;
                            break;
                        }
                    }
                } while (try_again);

                cells.Add(test_coordinate); //adds the coordinate to the list of food
                food_count++;
            }
        }
    }
}
