using System;

class Program
{
    static void Main(string[] args)
    {
        // This is prep 2
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);
        string letter = "";
        if (number >=90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your score is {letter}.");
        if (number >=70)
        {
            Console.WriteLine("Congratulations on passing the exam.");
        }
        else
        {
            Console.WriteLine("You didn't pass the exam, keep trying next time");
        }

    




    }
}