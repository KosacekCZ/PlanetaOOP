namespace PlanetaOOP;

public class LifeCycle
{
    public static void Main(string[] args)
    {
        Random r = new Random();
        Planet mogus = new Planet(new List<Human>(),
                                    new List<Human>(),
                                    "mogus",
                                    0,
                                    0);
        
        for (int i = 0; i < r.Next(10, 100); i++)
        {
            mogus.AddPerson(new Human($"Mogus {i}", 0, r.Next(0, 10) % 2 == 0, 200 * r.NextDouble()));
        }

        var years = 0;
        while (years < 500)
        {
            mogus.Elapse();
            years++;
        }
        
    }
}