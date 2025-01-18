using System;
using System.Collections.Generic;

class Program
{   static void Main(string[] args)
    {

        int userNumber = -1;
        List<int> numbers = new List<int>();
        while(userNumber !=0)
        {
             Console.Write("Enter a list of numbers, type 0 when finished.");
             Console.Write("Enter number: ");
             userNumber= int.Parse(Console.ReadLine());
             if (userNumber != 0){
               numbers.Add(userNumber);
             }

        }
       int sum =0;
       foreach (int number in numbers)
       {
        sum+=number;
       }
        Console.WriteLine($"The sum is: {sum}");
        float average = ((float)sum)/numbers.Count;
        Console.WriteLine($"The average is: {average}");
        int largest=numbers[0];
        foreach (int number in numbers){
            if (number>largest)
            {
                largest=number;
        }
        }
         Console.WriteLine($"The max is: {largest}");
    }
}