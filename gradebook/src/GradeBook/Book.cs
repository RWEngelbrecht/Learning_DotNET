using System;
using System.Collections.Generic;

namespace GradeBook 
{
  // event delegate
  public delegate void GradeAddedDelegate(object sender, EventArgs args); 

  public class NamedObject 
  {
    public NamedObject(string name)
    {
      Name = name;
    }

    public string Name { // auto property 
      get; // can be made private by using private keyword
      set;
    }
  }

  public interface IBook
  {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name {get;}
    event GradeAddedDelegate GradeAddedDelegate;
  }

  public abstract class Book : NamedObject
  {
    protected Book(string name) : base(name)
    {
    }

    public abstract void AddGrade(double grade);
  }


  public class InMemoryBook : Book 
  {

    List<double> grades;
    public event GradeAddedDelegate GradeAdded;

  // Original way of creating property property:
    // public string Name {
    //   get {                  //explicitly set what getter and setter does
    //     return name;
    //   }
    //   set {
    //     if(!String.IsNullOrEmpty(value))
    //       name = value;
    //     else
    //       throw new ArgumentException("");
    //   }
    // }
    // private string name;       // declare variable property is tied to

    public InMemoryBook(string name) : base(name) {
      grades = new List<double>();
      // Name = name;
    }

    // readonly string category = ""; // can only be set in constructor
    // const string CATEGORY = "";    // cannot be reset once initialized. treated as static.

    public override void AddGrade(double grade) { // c# looks at method name and
                                         // parameter type as method's signature
      if(grade <= 100 && grade >= 0) {
        grades.Add(grade);
        if(GradeAdded != null) {
          GradeAdded(this, new EventArgs());
        }
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