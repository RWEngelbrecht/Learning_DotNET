using System;
using System.Collections.Generic;
using System.Globalization;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book = new Book("Grades");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.7);

      Statistics stats = book.GetStatistics();

      Console.WriteLine($"Average: {stats.Average:N1}\nHighest: {stats.High}\nLowest: {stats.Low}");
    }
  }
}
