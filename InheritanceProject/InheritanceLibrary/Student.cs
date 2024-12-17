public class Student : Man
{
    public int Course { get; set; }

    public Student(string name, int age, double weight, string gender, int course)
        : base(name, age, weight, gender)
    {
        Course = course;
    }

    public void ChangeCourse(int newCourse)
    {
        Course = newCourse;
    }
}
