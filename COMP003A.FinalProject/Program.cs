/* 
 * Author: Steven Gonzalez
 * Course: COMP-003A
 * Purpose:  new user profile intake form for a social media platform
 */

class UserProfileIntakeForm
{

    static void SectionSeparator(string sectionName)
    {
        Console.WriteLine(new string('*', 50));
        Console.WriteLine(sectionName);
        Console.WriteLine(new string('*', 50));
    }

    static string GetValidNameInput(string prompt)
    {
        string input;
        bool isValidInput;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            isValidInput = !string.IsNullOrEmpty(input) && !input.Any(char.IsDigit) && !input.Any(char.IsPunctuation);

            if (!isValidInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
            }
        } while (!isValidInput);

        return input;
    }

    static bool IsValidBirthYear(int birthYear)
    {
        return birthYear >= 1900 && birthYear <= DateTime.Now.Year && birthYear <= 2023;
    }

    static char ValidateGenderInput(char gender)
    {
        while (gender != 'M' && gender != 'F' && gender != 'O')
        {
            Console.WriteLine("Invalid input for gender. Please enter 'M' for male, 'F' for female, or 'O' for other.");
            gender = Console.ReadLine().ToUpper()[0];
        }
        return gender;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the User Profile Intake Form!\r\n\r\nPlease fill out the following information to create your profile.");
        Console.WriteLine("___________________________________________________________________________________________________");

        SectionSeparator("First & Last name section");

        // Accept user input for first and last name and validates user first name and last name
        string firstName = GetValidNameInput("First Name: ");
        string lastName = GetValidNameInput("Last Name: ");


        Console.WriteLine("\n");
        SectionSeparator("Birth year & Gender section");

        // Accept and validate user input for birth year
        Console.Write("Birth Year (YYYY): ");
        int birthYear;

        while (!int.TryParse(Console.ReadLine(), out birthYear) || !IsValidBirthYear(birthYear))
        {
            Console.WriteLine("Invalid input for birth year. Please enter a valid year.");
        }
       

        // Accept user input for gender
        Console.Write("Gender (M/F/O): ");
        char gender = Convert.ToChar(Console.ReadLine().ToUpper());

        // Validate gender input
        gender = ValidateGenderInput(gender);
       

        Console.WriteLine("\n");
        SectionSeparator("10 question section");

        // Create questionnaire
        string[] questions = {"How tall are you?: ", "What is your favorit movie?: ", "Are you single?: ", "Are you in a relationship?: ", "Are you married?: ",
                    "What are your hobbies?: ", "What do you do for a living?: ", "Are you social?: ", "Do you like reading?: ", "Do you like exercising?: "};
        string[] responses = new string[questions.Length];

        // Accept and validate user responses to questionnaire
        for (int i = 0; i < questions.Length; i++)
        {
            Console.Write(questions[i]);

            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write(questions[i]);
                input = Console.ReadLine();
            }

            responses[i] = input;
        }

        Console.WriteLine("\n");
        SectionSeparator("Profile summary section");

        // Display user profile summary
        Console.WriteLine("Name: " + lastName + ", " + firstName);
        Console.WriteLine("Age: " + (DateTime.Now.Year - birthYear));

        void PrintGender(char gender)
        {
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
        }
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);
            Console.WriteLine("Answer: " + responses[i]);
        }
    }
}
