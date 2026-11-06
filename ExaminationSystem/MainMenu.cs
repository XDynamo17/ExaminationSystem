using System;
using System.Collections.Generic;

class Program
{
    static List<Question> questionBank = new List<Question>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Doctor Mode");
            Console.WriteLine("2. Student Mode (Take Exam)");
            Console.WriteLine("3. View All Questions");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DoctorMode.Run(questionBank);
                    break;

                case "2":
                    StudentMode.Run(questionBank);
                    break;

                case "3":
                    Console.WriteLine($"QUESTION BANK ({questionBank.Count} Questions)");
                    for (int i = 0; i < questionBank.Count; i++)
                    {
                        Console.WriteLine($"Question #{i + 1}:");
                        questionBank[i].DisplayQuestion();
                    }
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}