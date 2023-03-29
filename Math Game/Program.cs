int game = 1;
string welcomeLine = "\nWelcome to the Math Game, please write the number of the option that you want to choose";
string menuOptions = "1. Addition" +
                  "\n2. Substraction" +
                  "\n3. Multiplication" +
                  "\n4. Division" +
                  "\n5. Previous games" +
                  "\n6. Change difficult (Normal by default)" +
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
    int numberQuestions = 4;

    if (selectedOption < 0 || selectedOption > 5)
    {
        Console.WriteLine("----------- You must choose a valid option -----------");
    }

    if (selectedOption == 0)
    {
        break;
    }

    if (selectedOption == 5)
    {
        Console.WriteLine("----------- Previous Games -----------\n");

        foreach (var item in gamesHistory)
        {
            Console.WriteLine(item);
        }
    }

    if (selectedOption > 0 && selectedOption < 5)
    {
        Console.WriteLine($"----------- Game {game} -----------");
        correctAnswers = 0;

        for (int i = 0; i < numberQuestions && i == correctAnswers; i++)
        {
            int firstNumber = new Random().Next(1, 10);
            int secondNumber = new Random().Next(1, 10);

            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                    int.TryParse(Console.ReadLine(), out int responseAddition);

                    if (responseAddition == firstNumber + secondNumber) 
                    {
                        correctAnswers++;
                        Console.WriteLine("----------- Correct! -----------");
                    }

                    break;

                case 2:
                    Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
                    int.TryParse(Console.ReadLine(), out int responseSubstraction);

                    if (responseSubstraction == firstNumber - secondNumber)
                    {
                        correctAnswers++;
                        Console.WriteLine("----------- Correct! -----------");
                    }

                    break;

                case 3:
                    Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
                    int.TryParse(Console.ReadLine(), out int responseMultiplication);

                    if (responseMultiplication == firstNumber * secondNumber)
                    {
                        correctAnswers++;
                        Console.WriteLine("----------- Correct! -----------");
                    }

                    break;

                case 4:
                    while (firstNumber % secondNumber != 0 || secondNumber == 0)
                    {
                        firstNumber = new Random().Next(20);
                        secondNumber = new Random().Next(1, 101);
                    }

                    Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
                    int.TryParse(Console.ReadLine(), out int responseDivision);

                    if (responseDivision == firstNumber / secondNumber)
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

        gamesHistory.Add($"Game {game}: {correctAnswers} / {numberQuestions}");
        game++;

    }

    Console.WriteLine(welcomeLine);
    Console.WriteLine(menuOptions);
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

Console.WriteLine("----------- Thanks for playing -----------");