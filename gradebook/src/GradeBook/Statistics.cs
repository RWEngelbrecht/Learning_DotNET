using System;
using System.Collections.Generic;

namespace GradeBook
{

  public class Statistics
  {

    public double Average;
    public double High;
    public double Low;
    public double Median;
    public char Letter
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

    public Statistics(List<double> grades)
    {
      Average = 0.0;
      High = double.MinValue;
      Low = double.MaxValue;
      Median = 50.0;

      foreach (var grade in grades)
      {
        High = Math.Max(grade, High);
        Low = Math.Min(grade, Low);
        Average += grade;
      }

      Median = grades[grades.Count / 2];
      Average /= grades.Count;
    }
  }
}