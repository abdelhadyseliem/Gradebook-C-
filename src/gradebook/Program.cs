using System;

namespace gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Abdelhady's School gradebook");
            book.gradeAdded += onGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The Lowest grade is {stats.Low}");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The Average grade is {stats.Average:N1}");
            Console.WriteLine($"The Letter grade is {stats.letter}");
        }

        private static void EnterGrades(IBook book)
        {

            while (true)
            {
                Console.WriteLine("Enter a Grade\nEnter 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    // ..
                    Console.WriteLine("**");
                }
            }
        }

        static void onGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added!");
        }
    }
}
