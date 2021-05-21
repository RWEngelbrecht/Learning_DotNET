using System;
using System.Collections.Generic;

namespace GradeBook {
  class Book {

    List<double> grades;
    
    public Book() {
      grades = new List<double>();
    }

    public void AddGrade(double grade) {
      
      if (grade <= 100 && grade >= 0) {
        grades.Add(grade);
      }
    }

    public List<double> GetGrades() {
      return new List<double>();
    }

    public void ShowStatistics() {
      var avg = 0.0;
      var highest = double.MinValue;
      var lowest = double.MaxValue;
      var median = 50.0;
      foreach(var grade in grades) {
        highest = Math.Max(grade, highest);
        lowest = Math.Min(grade, lowest);
        avg += grade;
      }
      median = grades[grades.Count / 2];
      avg /= grades.Count;
      Console.WriteLine($"Average: {avg:N1}\nHighest: {highest}\nLowest: {lowest}\nMedian: {median}");
    }

  }
}