using ExaminationSystem;
using System;
using System.Collections.Generic;

public class DoctorMode
{
    public static void Run(List<Question> questionBank)
    {
        Console.WriteLine("DOCTOR MODE");
        bool keepAdding = true;

        while (keepAdding)
        {
            Console.WriteLine("Select Type (1. TrueFalse | 2. ChooseOne | 3. MultipleChoice): ");
            QuestionType type = (QuestionType)int.Parse(Console.ReadLine());

            Console.WriteLine("Select Level (1. Easy | 2. Medium | 3. Hard): ");
            QuestionLevel level = (QuestionLevel)int.Parse(Console.ReadLine());

            Console.Write("Enter question header: ");
            string header = Console.ReadLine();

            Console.Write("Enter marks: ");
            int marks = int.Parse(Console.ReadLine());

            if (type == QuestionType.TrueFalse)
            {
                Console.Write("Enter correct answer (True / False): ");
                string ans = Console.ReadLine();
                questionBank.Add(new TrueFalseQuestion(header, marks, level, ans));
            }
            else
            {
                string[] choices = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Choice {i + 1}: ");
                    choices[i] = Console.ReadLine();
                }

                if (type == QuestionType.ChooseOne)
                {
                    Console.Write("Enter correct choice number (1-4): ");
                    int correctIndex = int.Parse(Console.ReadLine());
                    questionBank.Add(new ChooseOneQuestion(header, marks, level, choices, correctIndex));
                }
                else if (type == QuestionType.MultipleChoice)
                {
                    Console.Write("Enter correct choices separated by comma (e.g., 1,3): ");
                    string ans = Console.ReadLine();
                    questionBank.Add(new MultipleChoiceQuestion(header, marks, level, choices, ans));
                }
            }

            Console.WriteLine("-> Question added!");

            Console.Write("Add another question? (y/n): ");
            string response = Console.ReadLine();

            if (response == "y" || response == "Y")
            {
                keepAdding = true;
            }
            else
            {
                keepAdding = false;
            }
        }
    }
}