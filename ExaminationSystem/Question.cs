using ExaminationSystem;
using System;
using System.Collections.Generic;

public abstract class Question
{
    public string Header { get; set; }
    public int Marks { get; set; }
    public QuestionLevel Level { get; set; }
    public QuestionType Type { get; set; }

    public Question(string header, int marks, QuestionLevel level, QuestionType type)
    {
        Header = header;
        Marks = marks;
        Level = level;
        Type = type;
    }


    public abstract void DisplayQuestion();
    public abstract bool CheckAnswer(string studentAnswer);
}


public class TrueFalseQuestion : Question
{
    public string CorrectAnswer { get; set; } 

    public TrueFalseQuestion(string header, int marks, QuestionLevel level, string correctAnswer)
        : base(header, marks, level, QuestionType.TrueFalse)
    {
        CorrectAnswer = correctAnswer;
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"[{Level} | {Marks} Marks] {Header}");
        Console.WriteLine("Enter True or False:");
    }

    public override bool CheckAnswer(string studentAnswer)
    {
        return studentAnswer == CorrectAnswer;
    }
}


public class ChooseOneQuestion : Question
{
    public string[] Choices { get; set; }
    public int CorrectChoiceIndex { get; set; } 

    public ChooseOneQuestion(string header, int marks, QuestionLevel level, string[] choices, int correctChoiceIndex)
        : base(header, marks, level, QuestionType.ChooseOne)
    {
        Choices = choices;
        CorrectChoiceIndex = correctChoiceIndex;
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"[{Level} | {Marks} Marks] {Header}");
        for (int i = 0; i < Choices.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Choices[i]}");
        }
    }

    public override bool CheckAnswer(string studentAnswer)
    {
        int choice = int.Parse(studentAnswer);
        return choice == CorrectChoiceIndex;
    }
}

public class MultipleChoiceQuestion : Question
{
    public string[] Choices { get; set; }
    public string CorrectAnswers { get; set; } 

    public MultipleChoiceQuestion(string header, int marks, QuestionLevel level, string[] choices, string correctAnswers)
        : base(header, marks, level, QuestionType.MultipleChoice)
    {
        Choices = choices;
        CorrectAnswers = correctAnswers;
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"[{Level} | {Marks} Marks] {Header} (Format: e.g., 1,3)");
        for (int i = 0; i < Choices.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Choices[i]}");
        }
    }

    public override bool CheckAnswer(string studentAnswer)
    {
        return studentAnswer == CorrectAnswers;
    }
}