using System;

class Program 
{
    public static void Main(string[] args)
    {
        string name;
        int score = 0;
        string file;

        Console.WriteLine("Please enter your name:");
        name = Console.ReadLine();
        file = name + ".txt";

        if(File.Exists(file))
        {
            string savedScore = File.ReadAllText(file);

            if (int.TryParse(savedScore, out int previousScore))//the score was successfully turned into int and retreived
            {
                score = previousScore;
                Console.WriteLine($"Welcome back, {name}! Your previous score was {score}.");
            }
            else
            {
                Console.WriteLine("Sorry, could not read your previous score. Starting from 0.");
            }
        }
        else //new playthrough
        {
            Console.WriteLine("Welcome, " + name + "! Start pressing keys to earn points. When you're done, press the enter key.");
        }
        
        Boolean loop = true;
        while(loop == true)
        {
            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
                File.WriteAllText(file, score.ToString()); //write everything to a file
                Console.WriteLine($"\nYour score of {score} has been saved in {file}. Thanks for playing!");
                loop = false; //end loop
            }
            else
            {
                score++;
                Console.WriteLine("Score: " + score);
            }
        }
    }
}