using System;
using System.Collections.Generic;

namespace GradeBook {
  public class Book {

    List<double> grades;
    public string Name;
    
    public Book(string name) {
      grades = new List<double>();
      Name = name;
    }

    public void AddGrade(double grade) {
      
      if (grade <= 100 && grade >= 0) {
        grades.Add(grade);
      }
    }

    public List<double> GetGrades() {
      return new List<double>();
    }

    public Statistics GetStatistics() {
      
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
      
      return new Statistics(avg, highest,lowest);
    }

  }
}