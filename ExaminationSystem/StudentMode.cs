using ExaminationSystem;
using System;
using System.Collections.Generic;

public class StudentMode
{
    public static void Run(List<Question> questionBank)
    {
        if (questionBank.Count == 0)
        {
            Console.WriteLine("No questions available in the bank yet");
            return;
        }

        Console.WriteLine("Student mode");
        Console.WriteLine("Select Exam Difficulty (1. Easy | 2. Medium | 3. Hard): ");
        QuestionLevel selectedLevel = (QuestionLevel)int.Parse(Console.ReadLine());

        int earnedMarks = 0;
        int totalMarks = 0;
        int questionsFound = 0;

        for (int i = 0; i < questionBank.Count; i++)
        {
            if (questionBank[i].Level == selectedLevel)
            {
                questionsFound++;
                Console.WriteLine($"\nQuestion #{questionsFound}:");
                questionBank[i].DisplayQuestion();

                Console.Write("Your Answer: ");
                string studentAns = Console.ReadLine();

                totalMarks += questionBank[i].Marks;

                if (questionBank[i].CheckAnswer(studentAns))
                {
                    Console.WriteLine("Correct Answer");
                    earnedMarks += questionBank[i].Marks;
                }
                else
                {
                    Console.WriteLine("Wrong Answer");
                }
            }
        }

        if (questionsFound == 0)
        {
            Console.WriteLine($"No questions found for level: {selectedLevel}");
        }
        else
        {
            Console.WriteLine("Exam Finished");
            Console.WriteLine($"Your Score: {earnedMarks} / {totalMarks}");
        }
    }
}