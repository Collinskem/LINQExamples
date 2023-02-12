

using LinqExamples;
using System.Linq;
using System.Xml.Linq;

class Program
{
    //initialize classes as list 
    public static List<Student> Students = new List<Student>();
    public static List<Course> Courses = new List<Course>();

    //method that displays all Courses
    public static void AllCourses()
    {
        Console.WriteLine("The Following are List of Courses");
        foreach (var item in Courses)
        {
            Console.WriteLine(item.Course_Name);
        }
    }
    //method that displays all Students
    public static void AllStudent()
    {
        Console.WriteLine("The Following are List of Students");
        foreach (Student student in Students)
        {
            Console.WriteLine($" {student.Name} - CourseId {student.CourseId}");
        }
    }
    public static void Main(string[] args)
    {
        //call to methods that seed data to the classes
        InitializeStudents();
        InitializeCourses();
        //how to Display students that meets a certain condition i.e whose names start with a letter K

        //implementing linq queries using method syntax
        Console.WriteLine("Students whose name starts with letter K");
        var namesStartwithK = Students.Where(e => e.Name.StartsWith("K"));
        foreach (var item in namesStartwithK)
        {

            Console.WriteLine(item.Name);
        }


        //display only three items in a list=>Take()
        Console.WriteLine("Displaying only 3 items using Take(3) function");
        var firstThreeStudents = Students.Take(3).ToList();
        foreach (var item in firstThreeStudents)
        {
            Console.WriteLine(item.Name);
        }

        //Skip method skips the  items in a list=>Skip()
        Console.WriteLine( "Skip Method that skips the first 3 items in a list");
        var skipThreeStudents = Students.Skip(3).ToList();
        foreach (var item in skipThreeStudents)
        {
            Console.WriteLine(item.Name);
        }
        //sort items in descending Order basing on CoourseId
        Console.WriteLine("OrderBy method");
        var orderbyId = Students.OrderByDescending(x => x.CourseId);
        foreach (var item in orderbyId)
        {
            Console.WriteLine($"{item.Name} -{item.CourseId}");

        }
        //count students on each course=>GroupBy
        Console.WriteLine("GroupBy and Count methods");
        var countStudentsOnCourses = Students.GroupBy(x => x.CourseId);
        foreach (var item in countStudentsOnCourses)
        {
            Console.WriteLine($"{item.Key}-{item.Count()}");
        }

        //join students by their courses 
        Console.WriteLine("Join Method");
        var studentCourses = Students.Join(Courses,e=>e.Id,s=>s.Id,(e,s)=>new {e.Name, s.Course_Name});
        foreach (var item in studentCourses)
        {
            Console.WriteLine($"{ item.Name}-{ item.Course_Name}");
        }

    }
    //initialized method with data to work with
    private static void InitializeCourses()
    {
        Courses.Add(new Course()
        {
            Id= 1,
            Course_Name="INTRODUCTION TO ANIMATIONS"

        });
        Courses.Add(new Course()
        { 
            Id= 2,
            Course_Name="Advanced Machine Learning"

        });
        Courses.Add(new Course()
        {
            Id= 3,
            Course_Name="Musical and Lyrical objects"

        });
        Courses.Add(new Course()
        {
            Id= 4,
            Course_Name= "Advanced Database"

        });
        Courses.Add(new Course()
        {
            Id  = 5,
            Course_Name="Distributed Systems"

        });
    }
    //initialized method with data to work with
    private static void InitializeStudents()
    {
        Students.Add(new Student()
        {
            Id= 1,
            Name="Yegon",
            CourseId= 5

        });
        Students.Add(new Student()
        {
            Id = 2,
            Name = "Kaluma",
            CourseId = 4
        });
        Students.Add(new Student()
        {
            Id = 3,
            Name = "Kimoi",
            CourseId = 5

        });

        Students.Add(new Student()
        {
            Id = 4,
            Name = "Peter",
            CourseId = 2
        });
        Students.Add(new Student()
        {
            Id = 5,
            Name = "chelsea",
            CourseId = 5
        });
        Students.Add(new Student()
        {
            Id = 6,
                Name = "Fatuma",
                CourseId = 2
            });
        Students.Add(new Student()
        {
            Id = 7,
            Name = "Juma",
            CourseId = 1
        });
    }
    }
  