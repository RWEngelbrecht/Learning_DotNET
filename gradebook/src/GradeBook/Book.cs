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

    public void AddGrade(double grade) { // c# looks at method name and
                                         // parameter type as method's signature
      if (grade <= 100 && grade >= 0) {
        grades.Add(grade);
      } else {
        throw new ArgumentException();
      }
    }

    public void AddGrade(char letter) {
      switch(letter) 
      {
        case var le when le == 'A' || le == 'a':
          AddGrade(90.0);
          break;
        case var le when le == 'B' || le == 'b':
          AddGrade(80.0);
          break;
        case var le when le == 'C' || le == 'c':
          AddGrade(70.0);
          break;
        case var le when le == 'D' || le == 'd':
          AddGrade(60.0);
          break;
        default:
          AddGrade(0.0);
          break;
      }
    }

    public List<double> GetGrades() {
      return grades;
    }

    public Statistics GetStatistics() {
      
      var avg = 0.0;
      var highest = double.MinValue;
      var lowest = double.MaxValue;
      var median = 50.0;
      var letter = 'F';
      
      foreach(var grade in grades) {
        highest = Math.Max(grade, highest);
        lowest = Math.Min(grade, lowest);
        avg += grade;
      }

      median = grades[grades.Count / 2];
      avg /= grades.Count;

      switch(avg) 
      {
        case var d when d >= 90.0:
          letter = 'A';
          break;
        case var d when d >= 80.0:
          letter = 'B';
          break;
        case var d when d >= 70.0:
          letter = 'C';
          break;
        case var d when d >= 60.0:
          letter = 'D';
          break;
      }

      return new Statistics(avg, highest, lowest, letter);
    }
  }
}