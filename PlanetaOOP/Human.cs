namespace PlanetaOOP;

public class Human
{
    public string name { get; private set; }
    public int age { get; internal set; }
    public bool gender { get; private set; }
    public double height { get; private set; }

    public Human(string name, int age, bool gender, double height)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.height = height;
    }
}