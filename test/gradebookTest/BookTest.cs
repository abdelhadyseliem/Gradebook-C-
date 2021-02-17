using gradebook;
using System;
using Xunit;

namespace gradebookTest
{
    public class UnitTest1
    {
        [Fact]
        public void BookStatisticsTesting()
        {
            // arrange
            // calling the book reference type [ new Book(); ]
            var book = new InMemoryBook("Abdelhady's School gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert 
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.letter);
        }
    }
}
