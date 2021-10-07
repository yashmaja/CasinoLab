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
                while (true)
                {
                    try
                    {
                        Console.Write("How many sides should each die have?: ");
                        numSides = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("\nInvalid input. Try again.\n");
                    }
                }

                Random rand = new Random();
                int die1 = rand.Next(1, numSides + 1);
                int die2 = rand.Next(1, numSides + 1);
                int sum = die1 + die2;

                numRolls++;
                Console.WriteLine($"Roll {numRolls}:");
                Console.WriteLine($"You rolled a {die1} and a {die2}. ({sum} total)");

                if (numSides == 6)
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
                    Console.WriteLine("Goodbye!\n");
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
    }
}
