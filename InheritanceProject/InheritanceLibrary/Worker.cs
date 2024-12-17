public class Worker : Man
{
    public string Position { get; set; }

    public Worker(string name, int age, double weight, string gender, string position)
        : base(name, age, weight, gender)
    {
        Position = position;
    }

    public void ChangePosition(string newPosition)
    {
        Position = newPosition;
    }
}
