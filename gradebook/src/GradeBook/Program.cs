using System;
using System.Collections.Generic;
using System.Globalization;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book = new Book();
      book.AddGrade(89.1);
      book.AddGrade(90.5);

      List<double> grades = new List<double>();

      grades.Add(56.1);

      var avg = 0.0;
      foreach(var grade in grades) {
        avg += grade;
      }
      avg /= grades.Count;
      Console.WriteLine($"Average is: {avg:N1}");
    }
  }
}
