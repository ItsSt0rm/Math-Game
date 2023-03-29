int game = 1;
string welcomeLine = "\nWelcome to the Math Game, please write the number of the option that you want to choose";
string menuOptions = "1. Addition" +
                  "\n2. Substraction" +
                  "\n3. Multiplication" +
                  "\n4. Division" +
                  "\n5. Games history" +
                  "\n0. Exit\n";
string line;
List<string> gamesHistory = new List<string>();

Console.WriteLine(welcomeLine);
Console.WriteLine(menuOptions);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
while (!String.IsNullOrEmpty(line = Console.ReadLine()))
{
    int selectedOption = int.Parse(line);
    int correctAnswers;
    int numberQuestions = 2;

    if (selectedOption < 0 || selectedOption > 4)
    {
        Console.WriteLine("----------- You must choose a valid option -----------");
    }

    if (selectedOption == 0)
    {
        break;
    }

    if (selectedOption > 0 && selectedOption < 5)
    {
        Console.WriteLine($"----------- Game {game} -----------");
        correctAnswers = 0;

        for (int i = 0; i < numberQuestions && correctAnswers == i; i++)
        {
            int firstNumber = new Random().Next(101);
            int secondNumber = new Random().Next(101);

            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                    int.TryParse(Console.ReadLine(), out int response);

                    if (response == firstNumber + secondNumber) 
                    {
                        correctAnswers++;
                        Console.WriteLine("----------- Correct! -----------");
                    }

                    break;
            }
        }

        if (correctAnswers == numberQuestions)
        {
            Console.WriteLine("\n----------- Congratulations, you won! -----------");
        } else
        {
            Console.WriteLine("\n----------- Sorry, you lost -----------");
        }
    }

    game++;

    Console.WriteLine(welcomeLine);
    Console.WriteLine(menuOptions);
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

Console.WriteLine("----------- Thanks for playing -----------");