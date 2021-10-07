using System;

namespace casinoDiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSides = 0;
            int numRolls = 0;
            bool repeat = true;

            while (repeat)
            {

                numSides = GetSides();

                int die1 = RandomRoll(numSides);
                int die2 = RandomRoll(numSides);
                int sum = die1 + die2;

                numRolls++;
                Console.WriteLine($"\nRoll {numRolls}:");
                Console.WriteLine($"You rolled a {die1} and a {die2}. ({sum} total)");

                if (numSides == 6)
                {
                    SixSideCombos(die1, die2, sum);
                }

                repeat = Repeat();
            }
        }

        public static bool Repeat()
        {
            while (true)
            {
                Console.Write("\nRoll again? (y/n): ");
                string answer = Console.ReadLine();

                if (answer == "n")
                {
                    Console.WriteLine("\nGoodbye!");
                    return false;
                }
                else if (answer == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                }
            }
        }

        public static int GetSides()
        {
            int numSides = 0;

            while (true)
            {
                try
                {
                    Console.Write("\nHow many sides should each die have?: ");
                    numSides = int.Parse(Console.ReadLine());

                    if (numSides <= 0)
                    {
                        Console.WriteLine("Please enter a number above 0. "); ;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                }
            }

            return numSides;
        }

        public static int RandomRoll(int numSides)
        {
            Random rand = new Random();
            return rand.Next(1, numSides + 1);
        }

        public static void SixSideCombos(int die1, int die2, int sum)
        {
            if (die1 == 1 || die2 == 1)
            {
                if (die1 == die2)
                {
                    Console.WriteLine("Snake Eyes!\n");
                }
                else if (die1 == 2 || die2 == 2)
                {
                    Console.WriteLine("Ace Deuce!\n");
                }
            }
            if (die1 == 6 && die2 == 6)
            {
                Console.WriteLine("Box Cars!");
            }
            if (sum == 7 || sum == 11)
            {
                Console.WriteLine("Win!");
            }
            if (sum == 2 || sum == 3 || sum == 12)
            {
                Console.WriteLine("Craps!");
            }
        }
    }
}
