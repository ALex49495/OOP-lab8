using System;
using InheritanceLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Student student = new Student("Іван", 20, 70.5, "чоловік", 3);
        Worker worker = new Worker("Ольга", 30, 65.0, "жінка", "інженер");

        Console.WriteLine($"{student.Name}, {student.Age}, {student.Weight}, {student.Gender}, {student.Course}");
        Console.WriteLine($"{worker.Name}, {worker.Age}, {worker.Weight}, {worker.Gender}, {worker.Position}");

        student.ChangeCourse(4);
        worker.ChangePosition("старший інженер");

        Console.WriteLine($"{student.Name}, {student.Age}, {student.Weight}, {student.Gender}, {student.Course}");
        Console.WriteLine($"{worker.Name}, {worker.Age}, {worker.Weight}, {worker.Gender}, {worker.Position}");
    }
}
