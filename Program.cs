using System;

namespace MiniGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Dice dice = new Dice(random);
            SquidGame squidGame = new SquidGame(dice);
            GameResult result = squidGame.Start();
            squidGame.PrintOutcome(result);
        }

        public class Dice
        {
            private Random random;

            public Dice(Random random)
            {
                this.random = random;
            }

            public int Roll
            {
                get
                {
                    int randomNumber = random.Next(1, 13); // Τυχαίος αριθμός από 1 έως 12
                    return randomNumber;
                }
            }
        }

        public class SquidGame
        {
            private Dice dice;

            public SquidGame(Dice dice)
            {
                this.dice = dice;
            }

            public GameResult Start()
            {
                int magicNumber = dice.Roll;
                int attempts = 4;
                int userGuess = 0;

                Console.WriteLine("ΤΟ ΠΑΙΧΝΙΔΙ ΞΕΚΙΝΗΣΕ ΤΑ ΝΟΥΜΕΡΑ ΑΡΧΙΖΟΥΝ  ΑΠΟ ΤΟ 1 ΕΩΣ ΤΟ 12 ΚΑΛΗ ΤΥΧΗ");

                for (int attempt = 1; attempt <= attempts; attempt++)
                {
                    Console.Write($"ΠΡΟΣΠΑΘΕΙΑ {attempt}: ΓΡΑΨΕ ΤΟΝ ΤΥΧΕΡΟ ΑΡΙΘΜΟ ΠΟΥ ΠΙΣΤΕΥΕΙΣ Ο ΟΠΟΙΟΣ ΕΙΝΑΙ (1 - 12): ");
                    if (int.TryParse(Console.ReadLine(), out userGuess))
                    {
                        if (userGuess == magicNumber)
                        {
                            return new GameResult(true);
                        }
                        else
                        {
                            Console.WriteLine("ΛΑΘΟΣ ΑΡΙΘΜΟΣ ΞΑΝΑΠΡΣΟΠΑΘΗΣΕ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ΔΕΝ ΗΤΑΝ ΣΩΣΤΟΣ Ο ΤΥΠΟΣ ΑΡΙΘΜΟΥ ΞΑΝΑΠΡΟΣΠΑΘΗΣΕ");
                    }
                }

                return new GameResult(false, magicNumber);
            }

            public void PrintOutcome(GameResult result)
            {
                if (result.Win)
                {
                    Console.WriteLine("ΜΠΡΑΒΩ ΣΟΥ ΝΙΚΗΣΕΣ");
                }
                else
                {
                    Console.WriteLine($"ΕΧΑΣΕΣ Ο ΤΥΧΕΡΟΣ ΑΡΙΘΜΟΣ ΗΤΑΝ Ο  {result.MagicNumber}.");
                }
            }
        }

        public class GameResult
        {
            public bool Win { get; }
            public int MagicNumber { get; }

            public GameResult(bool win, int magicNumber = 0)
            {
                Win = win;
                MagicNumber = magicNumber;
            }
        }
    }
}
