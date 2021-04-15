using System;

namespace RockPaperScissorSwitchExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            RockPaperScissorsTuple();
        }
        public static void RockPaperScissorsTuple()
        {
            while (true)
            {
                string menu = "Select: \n1 -> rock\n2 -> paper\n3 -> scissors\n4 -> finish";
                Console.WriteLine(menu);

                string[] options = { "rock", "paper", "scissors" };

                int value;

                try
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine("Invalid choice");
                        continue;
                    }
                    value = int.Parse(line);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                if (value == 4)
                {
                    break;
                }

                if (value < 1 || value > 4)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                string human = options[value - 1];

                Random round = new Random();
                int number = round.Next(0, 3);

                string computer = options[number];

                Console.WriteLine($"I have {computer}, you have {human}");

                string result = RockPaperScissors(human, computer);

                Console.WriteLine(result);
            }

            Console.WriteLine("game finished");

            string RockPaperScissors(string human, string computer) => (human, computer) switch
            {
                ("rock", "paper") => "Rock is covered by paper. You lost",
                ("rock", "scissors") => "Rock breaks scissors. You win.",
                ("paper", "rock") => "Paper covers rock. You win.",
                ("paper", "scissors") => "Paper is cut by scissors. You lost.",
                ("scissors", "rock") => "Scissors are broken by rock. You lost.",
                ("scissors", "paper") => "Scissors cut paper. You win.",
                (_, _) => "tie"
            };
        }
    }
}
