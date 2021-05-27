using System;
using System.IO;
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

    public string Name { // * auto property 
      get; // * can be made private by using private keyword
      set;
    }
  }

  public interface IBook
  {
    void AddGrade(double grade);
    void AddGrade(string letter);
    Statistics GetStatistics();
    List<double> GetGrades();

    string Name {get;}
    event GradeAddedDelegate GradeAdded;
  }

  public abstract class Book : NamedObject, IBook
  {
    protected Book(string name) : base(name) {}

    public abstract event GradeAddedDelegate GradeAdded;

    public abstract void AddGrade(double grade);

    public abstract void AddGrade(string letter);

    public abstract List<double> GetGrades();

    public abstract Statistics GetStatistics();
  }


  public class InMemoryBook : Book
  {

    List<double> grades;
    public override event GradeAddedDelegate GradeAdded;

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

    public override void AddGrade(string letter) {
      switch(letter) 
      {
        case var le when le == "A" || le == "a":
          AddGrade(90.0);
          break;
        case var le when le == "B" || le == "b":
          AddGrade(80.0);
          break;
        case var le when le == "C" || le == "c":
          AddGrade(70.0);
          break;
        case var le when le == "D" || le == "d":
          AddGrade(60.0);
          break;
        default:
          AddGrade(0.0);
          break;
      }
    }

    public override List<double> GetGrades() {
      return grades;
    }

    public override Statistics GetStatistics() {
      return new Statistics(grades);
    }
  }

  public class DiskBook : Book, IBook
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      if(grade <= 100 && grade >= 0) {
        using (StreamWriter sw = File.AppendText($"{this.Name}.txt"))
        {
          sw.WriteLine(grade);
          if(GradeAdded != null)
            GradeAdded(this, new EventArgs());
        }
      } else {
        throw new ArgumentException();
      }
    }

    public override void AddGrade(string letter)
    {
      switch(letter) 
      {
        case var le when le == "A" || le == "a":
          AddGrade(90.0);
          break;
        case var le when le == "B" || le == "b":
          AddGrade(80.0);
          break;
        case var le when le == "C" || le == "c":
          AddGrade(70.0);
          break;
        case var le when le == "D" || le == "d":
          AddGrade(60.0);
          break;
        default:
          AddGrade(0.0);
          break;
      }
    }

    public override List<double> GetGrades()
    {
      List<double> grades = new List<double>();

      foreach (string line in File.ReadAllLines($"{this.Name}.txt")) {
        grades.Add(double.Parse(line));
      }

      return grades;
    }

    public override Statistics GetStatistics()
    {
      var grades = GetGrades();

      return new Statistics(grades);
    }
  }
}