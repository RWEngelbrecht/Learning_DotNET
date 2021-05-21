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

  }
}