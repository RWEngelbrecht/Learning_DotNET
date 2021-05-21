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
      book.AddGrade(77.7);
      book.ShowStatistics();
    }
  }
}
