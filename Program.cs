/*
 * Author: Gursimran Kaur
 * Course: COMP003A
 * Purpose: COMP003A.Final Project
 * 
 */

namespace COMP003A.FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User input section
            string firstName, lastName, gender;
            int birthYear;

            // Accept user inputs
            firstName = GetValidInput("Enter your First Name: ", ValidateName);
            lastName = GetValidInput("Enter your Last Name: ", ValidateName);
            birthYear = GetValidIntInput("Enter your Birth Year (YYYY): ", 1900, DateTime.Now.Year);
            gender = GetValidInput("Enter your Gender (M/F/O): ", ValidateGender);


            // Questionnaire
            List<string> questionnaireResponses = new List<string>();
            Console.WriteLine("\nPlease answer the following questions:");
            string[] questions = {
            "What are your hobbies?",
            "Describe your ideal date.",
            "What do you look for in a partner?",
            "What's your favorite movie?",
            "Do you like outdoor activities?",
            "What's your favorite cuisine?",
            "What's your favorite book?",
            "What do you do for a living?",
            "Where do you see yourself in 5 years?",
            "What's your favorite holiday destination?"
        };
            for (int i = 0; i < questions.Length; i++)
            {
                Console.Write($"Question {i + 1}: {questions[i]} ");
                string response = Console.ReadLine();
                questionnaireResponses.Add(response);
            }

            // Profile Summary
            Console.WriteLine("\nProfile Summary:");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetFullGenderDescription(gender)}");

            Console.WriteLine("\nQuestionnaire Responses:");
            for (int i = 0; i < questionnaireResponses.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.WriteLine($"Response {i + 1}: {questionnaireResponses[i]}");
            }
        }
        // Method to get valid string input
        static string GetValidInput(string prompt, Func<string, bool> validation)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!validation(input));
            return input;
        }

        // Method to get valid integer input within a range
        static int GetValidIntInput(string prompt, int min, int max)
        {
            int input;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max);
            return input;
        }

        // Validate name input
        static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && !ContainsDigitsOrSpecialChars(name);
        }

        // Validate gender input
        static bool ValidateGender(string gender)
        {
            return gender.Equals("M", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("F", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("O", StringComparison.OrdinalIgnoreCase);
        }

        // Check if string contains digits or special characters
        static bool ContainsDigitsOrSpecialChars(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                {
                    return true;
                }
            }
            return false;
        }

        // Get full gender description
        static string GetFullGenderDescription(string gender)
        {
            switch (gender.ToUpper())
            {
                case "M":
                    return "Male";
                case "F":
                    return "Female";
                case "O":
                    return "Other";
                default:
                    return "Unknown";
            }
        }
    }
}
