﻿using System.Diagnostics;

int game = 1;
int difficult = 20;
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

while (!String.IsNullOrEmpty(line = Console.ReadLine()))
{
    int selectedOption = int.Parse(line);
    int correctAnswers;

    if (selectedOption < 0 || selectedOption > 6)
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

    if (selectedOption == 6)
    {
        difficult = 0;
        Console.WriteLine("\nSelect difficult" +
                           "\n1. Easy" +
                           "\n2. Normal" +
                           "\n3. Hard"
        );

        while (difficult == 0)
        {
            int.TryParse(Console.ReadLine(), out int responseDifficult);

            switch (responseDifficult)
            {
                case 1:
                    difficult = 10;
                    break;

                case 2:
                    difficult = 20;
                    break;

                case 3:
                    difficult = 30;
                    break;

                default:
                    Console.WriteLine("----------- You must choose a valid option -----------");
                    break;
            }
        }
    }

    if (selectedOption > 0 && selectedOption < 5)
    {
        Console.WriteLine("\nWrite the number of questions that you want in the game");
        int.TryParse(Console.ReadLine(), out int numberQuestions);

        Console.WriteLine($"----------- Game {game} -----------");

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        correctAnswers = 0;

        for (int i = 0; i < numberQuestions && i == correctAnswers; i++)
        {
            int firstNumber = new Random().Next(1, difficult);
            int secondNumber = new Random().Next(1, difficult);

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
                        firstNumber = new Random().Next(0, 100);
                        secondNumber = new Random().Next(1, difficult);
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

        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;

        if (correctAnswers == numberQuestions)
        {
            Console.WriteLine("\n----------- Congratulations, you won! -----------");
        }
        else
        {
            Console.WriteLine("\n----------- Sorry, you lost -----------");
        }

        gamesHistory.Add($"Game {game}: {correctAnswers} / {numberQuestions} | Time elapsed: {elapsedTime.ToString(@"mm\:ss")}");
        game++;

        Console.WriteLine($"\n----------- Time elapsed: {elapsedTime.ToString(@"mm\:ss")} -----------");

    }

    Console.WriteLine(welcomeLine);
    Console.WriteLine(menuOptions);
}


Console.WriteLine("----------- Thanks for playing -----------");