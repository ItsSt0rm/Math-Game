List<int> gamesHistory = new List<int>();

Console.WriteLine("Welcome to the Math Game, please write the number of the option that you want to choose");
Console.WriteLine($"1. Addition" +
                  $"\n2. Substraction" +
                  $"\n3. Multiplication" +
                  $"\n4. Division" +
                  $"\n0. Exit\n");

string line;
while(!String.IsNullOrEmpty(line = Console.ReadLine()))
{
    int selectedOption = int.Parse(line);

    if(selectedOption < 0 || selectedOption > 4)
    {
        Console.WriteLine(" ----------- You must choose a valid option -----------");
    }

    if(selectedOption == 0)
    {
        break;
    }

}

Console.WriteLine("----------- Thanks for playing -----------");