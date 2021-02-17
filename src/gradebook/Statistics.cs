using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradebook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return sum / Count;
            }
        }
        public double High;
        public double Low;
        public char letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public double sum;
        public int Count;

        public void Add(double number)
        {
            sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistics()
        {
            Count = 0;
            sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}
