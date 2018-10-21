using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    public abstract class Analyzer
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
        public Analyzer(int w = 10, int h = 10)
        {
            InitializeMatrix(w, h);
            InitializeGuess();
            SetRandomSample(2);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~Analyzer()
        {
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Initializes matrix for the constructor.
        // @param: none
        // @return: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public void InitializeMatrix(int w, int h)
        {
            Width = w;
            Height = h;
            matrix = new char[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    matrix[i, j] = '~';
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Initializes coordinate and counts for guess.
        // @param: none
        // @return: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public void InitializeGuess()
        {
            guess.x = 0;
            guess.y = 0;
            guesses = 0;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Set n number of random samples.
        // @param: int
        // @return: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public void SetRandomSample(int n)
        {
            sample = new Coordinate[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                sample[i].x = rand.Next(width);
                sample[i].y = rand.Next(height);
            }
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
                        grid += (i == 2) ? "+" : "-";
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
            guess = ValidGuess(x, y);
            Coordinate subject = FindClosestSample(guess);
            guessed = (Distance(subject) == 0) ? true : false;
            if (matrix[guess.x, guess.y] == '~')
                guesses++;
            matrix[guess.x, guess.y] = Direction(subject);
            return guessed;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Finds the closest sample among the samples from the guess.
        // @param: Coordinate
        // @return: Coordinate
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/

        public Coordinate FindClosestSample(Coordinate guess)
        {
            Coordinate subject = sample[0]; // Initialize to an existing sample
            double distance; // Initialize to maximum distance
            distance = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));

            foreach(Coordinate var in sample)
            {
                if (Distance(var) <= distance)
                {
                    distance = Distance(var);
                    subject = var;
                }
            }
            return subject;
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
        private double Distance(Coordinate subject)
        {
            double distance = 0;
            int x = subject.x - guess.x;
            int y = subject.y - guess.y;
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
        private Coordinate[] sample;
        private Coordinate guess;
        private int guesses;

    }

    public class PrintAnalyzer : Analyzer
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: int, int, int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public PrintAnalyzer(int w = 10, int h = 10, int n = 2) : base(w, h)
        {
            SetRandomSample(n);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~PrintAnalyzer()
        {
        }


    }

    public class DNAAnalyzer : Analyzer
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: int, int, int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public DNAAnalyzer(int w = 10, int h = 10, int n = 2) : base(w, h)
        {
            SetRandomSample(n);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~DNAAnalyzer()
        {
        }


    }

    public class HairAnalyzer : Analyzer
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: int, int, int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public HairAnalyzer(int w = 10, int h = 10, int n = 2) : base(w, h)
        {
            SetRandomSample(n);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~HairAnalyzer()
        {
        }


    }

    public class FiberAnalyzer : Analyzer
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: int, int, int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public FiberAnalyzer(int w = 10, int h = 10, int n = 2) : base(w, h)
        {
            SetRandomSample(n);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~FiberAnalyzer()
        {
        }


    }

    public class BloodAnalyzer : Analyzer
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: int, int, int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public BloodAnalyzer(int w = 10, int h = 10, int n = 2) : base(w, h)
        {
            SetRandomSample(n);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Destructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        ~BloodAnalyzer()
        {
        }


    }

}
