using System;
using System.Collections.Generic;
using System.IO;

namespace gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedOject
    {
        public NamedOject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }


    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate gradeAdded;
    }

    public abstract class Book : NamedOject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate gradeAdded;
        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate gradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public string AddGrade(char letter, int x)
        {
            return "";
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate gradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            };

            return result;
        }

        private List<double> grades;

        public const string category = "Science";
    }
}