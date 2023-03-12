/* 
 * Author: Steven Gonzalez
 * Course: COMP-003A
 * Purpose:  new user profile intake form for a social media platform
 */

using System;
class UserProfileIntakeForm
{
    static void Main(string[] args)
    {
        static void SectionSeparator(string sectionName)
        {
            Console.WriteLine(new string('*', 50));
            Console.WriteLine(sectionName);
            Console.WriteLine(new string('*', 50));
        }

        SectionSeparator("First & Last name section");

        // Accept user input for first name
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        // Validate first name input
        if (string.IsNullOrEmpty(firstName) || firstName.Any(char.IsDigit) || firstName.Any(char.IsPunctuation))
        {
            throw new ArgumentException("Invalid input for first name.");
        }

        // Accept user input for last name
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        // Validate last name input
        if (string.IsNullOrEmpty(lastName) || lastName.Any(char.IsDigit) || lastName.Any(char.IsPunctuation))
        {
            throw new ArgumentException("Invalid input for last name.");
        }

        Console.WriteLine("\n");
        SectionSeparator("Birth year & Gender section");

        // Accept user input for birth year
        Console.Write("Birth Year (YYYY): ");
        int birthYear;
        while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
        {
            Console.WriteLine("Invalid input for birth year. Please enter a valid year.");
        }

        // Accept user input for gender
        Console.Write("Gender (M/F/O): ");
        char gender = Convert.ToChar(Console.ReadLine().ToUpper());

        // Validate gender input
        if (gender != 'M' && gender != 'F' && gender != 'O')
        {
            throw new ArgumentException("Invalid input for gender.");
        }

        Console.WriteLine("\n");
        SectionSeparator("10 question section");

        // Create questionnaire
        string[] questions = {"How tall are you?: ", "What is your favorit movie?: ", "Are you single?: ", "Are you in a relationship?: ", "Are you married?: ",
                            "What are your hobbies?: ", "What do you do for a living?: ", "Are you social?: ", "Do you like reading?: ", "Do you like exercising?: "};
        string[] responses = new string[questions.Length];

        // Accept user responses to questionnaire
        for (int i = 0; i < questions.Length; i++)
        {
            Console.Write(questions[i]);
            responses[i] = Console.ReadLine();
        }

        Console.WriteLine("\n");
        SectionSeparator("Profile summary section");

        // Display user profile summary
        Console.WriteLine("Name: " + lastName + ", " + firstName);
        Console.WriteLine("Age: " + (DateTime.Now.Year - birthYear));
        switch (gender)
        {
            case 'M':
                Console.WriteLine("Gender: Male");
                break;
            case 'F':
                Console.WriteLine("Gender: Female");
                break;
            case 'O':
                Console.WriteLine("Gender: Other");
                break;
        }
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);
            Console.WriteLine("Answer: " + responses[i]);
        }
    }
}