public class Man
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Gender { get; set; }

    public Man(string name, int age, double weight, string gender)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Gender = gender;
    }

    public void ChangeAge(int newAge)
    {
        Age = newAge;
    }

    public void ChangeWeight(double newWeight)
    {
        Weight = newWeight;
    }
}
