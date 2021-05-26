﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book = new Book("Grades");

      Console.WriteLine("Hello there...\nPlease enter a grade value or enter 'q' to quit:");
      var done = false;
      double grade = 0;
      char letterGrade = 'E';

      while(!done) {
        var input = Console.ReadLine();

        if(input == "q" || input == "Q") {
          done = true;
          Console.WriteLine($"Buh-bye...");
          continue;
        } else if(!Regex.IsMatch(input, @",") && Regex.IsMatch(input, @"\.")) {
          input = Regex.Replace(input, @"\.", @",");
        }

        try {
          if (!Regex.IsMatch(input, @"[a-dA-DfF]")) {
            grade = double.Parse(input);
          } else {
            letterGrade = input[0];
          }
          book.AddGrade(letterGrade != 'E' ? letterGrade : grade);
        } catch(ArgumentException e) {
          Console.WriteLine($"That doesn't seem to be a valid number...\n{e.Message}");
        } catch(FormatException e) {
          Console.WriteLine(e.Message);
        }
      }

      if (book.GetGrades().Count > 0) {
        Statistics stats = book.GetStatistics();
        Console.WriteLine($"Average: {stats.Average:N1}\nHighest: {stats.High}\nLowest: {stats.Low}\nLetter grade: {stats.Letter}");
      }
    }
  }
}
