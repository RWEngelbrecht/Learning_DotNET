using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(98.5);
            book.AddGrade(72.3);
            
            // act
            var result = book.GetStatistics();
            // assert

            Assert.Equal(86.6, result.Average, 1);
            Assert.Equal(98.5, result.High,1);
            Assert.Equal(72.3, result.Low,1);
        }
    }
}
