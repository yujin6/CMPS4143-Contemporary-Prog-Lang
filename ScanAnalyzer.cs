/*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
* This program is a game to find the evidence sample.
* @version 1.0 2018-10-03
* @course: CMPS4143 Dr. Stringfellow
* @author Yujin Yoshimura
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
using System;

namespace CSI_Find_The_Evidence_Sample
{
    class ScanAnalyzer
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // struct to manage the coordinates of samples and guesses.
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public struct Coordinate
        {
            public int x, y;
            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: int, int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public ScanAnalyzer(int w = 10, int h = 10)
        {
            Width = w;
            Height = h;
            matrix = new char[width,height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = '~';
                }
            }
            Random rand = new Random();
            sample1.x = rand.Next(width);
            sample1.y = rand.Next(height);
            sample2.x = rand.Next(width);
            sample2.y = rand.Next(height);
            guess.x = 0;
            guess.y = 0;
            guesses = 0;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~ScanAnalyzer()
        {
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Generates string in grid shape for display purpose in the form.
        // @param: none
        // @return: string
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public string DisplayGrid()
        {
            string grid = "";
            for (int j = 0; j < height + 2; j++)
            {
                if (j == 0) // Column Label
                {
                    grid += "  |";
                    for (int i = 0; i < width; i++)
                    {
                        char c = Convert.ToChar(i + 65);
                        grid += c.ToString();
                    }
                }
                else if (j == 1) // Rule
                {
                    for (int i = 0; i < width + 3; i++)
                    {
                        grid += (i == 2) ? "+" : "-" ;
                    }
                }
                else
                {
                    grid += String.Format("{0,-2}|", j - 1); // Row Label
                    for (int i = 0; i < width; i++) // Content
                    {
                        grid += matrix[i, j - 2];
                    }
                }
                grid += "\n";
            }
            return grid;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Evaluates guess made by the user.
        // Returns true when the guess matches the sample.
        // Otherwise, shows direction to the nearest sample and returns false.
        // @param: int, int
        // @return: bool
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public bool EvaluateGuess(int x, int y)
        {
            bool guessed;
            Coordinate subject;
            guess = ValidGuess(x, y);
            subject = (Distance(sample1) <= Distance(sample2)) ?
                sample1 : sample2;
            guessed = (Distance(subject) == 0) ? true : false;
            if (matrix[guess.x, guess.y] == '~')
                guesses++;
            matrix[guess.x, guess.y] = Direction(subject);
            return guessed;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Returns the guessed coordinate in string.
        // @param: none
        // @return: string
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public string GetCoordinate()
        {
            char ch = Convert.ToChar(guess.x + 65);
            string str = ch.ToString() + Convert.ToString(guess.y + 1);
            return str;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Property for width.
        // Minimum width: 2
        // Maximum width: 26
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value < 2)
                    width = 2;
                else if (value > 26)
                    width = 26;
                else
                    width = value;
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Property for height.
        // Minimum height: 2
        // Maximum height: 16
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 2)
                    height = 2;
                else if (value > 16)
                    height = 16;
                else
                    height = value;
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Property for guesses.
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public int Guesses
        {
            get
            {
                return guesses;
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Calculates the distance from the guess to the sample.
        // @param: Coordinate
        // @return: double
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private double Distance(Coordinate sample)
        {
            double distance = 0;
            int x = sample.x - guess.x;
            int y = sample.y - guess.y;
            distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Calculates the direction from the guess to the sample.
        // @param: Coordinate
        // @return: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private char Direction(Coordinate sample)
        {
            char direction;
            int x = sample.x - guess.x;
            int y = sample.y - guess.y;
            if (Distance(sample) == 0)
                direction = 'X';
            else if (Math.Abs(x) <= Math.Abs(y))
                direction = (y < 0) ? '^' : 'v';
            else
                direction = (x < 0) ? '<' : '>';
            return direction;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Validates the coordinates of the guess within the given size.
        // @param: int, int
        // @return: Coordinate
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private Coordinate ValidGuess(int x, int y)
        {
            if (x < 0) x = 0;
            else if (x >= width) x = width - 1;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            Coordinate pt = new Coordinate(x, y);
            return pt;
        }

        private char[,] matrix;
        private int width, height;
        private Coordinate sample1, sample2, guess;
        private int guesses;

    }
}
