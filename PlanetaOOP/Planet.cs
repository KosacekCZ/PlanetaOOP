namespace PlanetaOOP;

public class Planet
{
    private Random _r = new Random();
    public List<Human> MaleFinalSolution { get; private set; }
    public List<Human> FemaleFinalSolution { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; } = 0;
    public int Population { get; private set; }
    public int DeathThreshold { get; set; } = 98;
    
    private int _statsDied = 0;
    private int _statsBorn = 0;
        

    public void Elapse()
    {
        Age++;
        foreach (Human h in MaleFinalSolution)
        {
            h.age++;
        }
        foreach (Human h in FemaleFinalSolution)
        {
            h.age++;
        }

        Fuck();
        Execute();
        Population = MaleFinalSolution.Count + FemaleFinalSolution.Count;
        Stats();
        _statsDied = 0;
        _statsBorn = 0;
    }

    private void Stats()
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Planet {Name}, year {Age}:");
        Console.WriteLine($"-> Population: {Population}");
        Console.WriteLine($"-> Age median: {Median()}");
        Console.WriteLine($"-> Average age: {AvgAge()}");
        Console.WriteLine($"-> Born : {_statsBorn}");
        Console.WriteLine($"-> Died: {_statsDied}");
        Console.WriteLine($"-> Males: {MaleFinalSolution.Count}");
        Console.WriteLine($"-> Females: {FemaleFinalSolution.Count}");
        Console.WriteLine("----------------------------------------------------");
    }

    private double AvgAge()
    {
        int average = 0;
        foreach (Human h in MaleFinalSolution)
        {
            average += h.age;
        }

        foreach (Human h in FemaleFinalSolution)
        {
            average += h.age;
        }

        return (average / (MaleFinalSolution.Count + FemaleFinalSolution.Count));
    }

    private int Median()
    {
        List<int> ageList = new List<int>();
        for (int i = 0; i < MaleFinalSolution.Count; i++)
        {
            ageList.Add(MaleFinalSolution[i].age);
        }
        
        for (int i = 0; i < FemaleFinalSolution.Count; i++)
        {
            ageList.Add(FemaleFinalSolution[i].age);
        }


        ageList.Sort();
        return ageList[(ageList.Count / 2) - 1];
    }

        private void Execute()
    {
        // Males rip
        for (int i = 0; i < MaleFinalSolution.Count; i++)
        {
            if (_r.Next(MaleFinalSolution[i].age, 100) >= DeathThreshold)
            {
                //Console.WriteLine(MaleFinalSolution[i].name + " Died at " + MaleFinalSolution[i].age + " years.");
                MaleFinalSolution.RemoveAt(i);
                _statsDied++;
            }
        }
        // Females rip
        for (int i = 0; i < FemaleFinalSolution.Count; i++)
        {
            if (_r.Next(FemaleFinalSolution[i].age, 100) >= DeathThreshold)
            {
                //Console.WriteLine(FemaleFinalSolution[i].name + " Died at " + FemaleFinalSolution[i].age + " years.");
                FemaleFinalSolution.RemoveAt(i);
                _statsDied++;
            }
        }
    }

    private void Fuck()
    {
        List<Human> temp = new List<Human>();
        //TODO Gay sex
        if (MaleFinalSolution.Count > 0 && MaleFinalSolution.FindAll(human => human.age >= 12).Count > 0)
        {
            foreach (Human h in FemaleFinalSolution)
            {
                if (_r.Next(0, 4) == 3 && h.age >= 12)
                {
                    temp.Add(new Human($"Mogusek {_r.Next(0, 100) + 1}", 0, _r.Next(0, 11) % 2 == 0, 200 * _r.NextDouble()));
                    _statsBorn++;
                }
            }
        }

        for (int i = 0; i < temp.Count; i++)
        {
            AddPerson(temp[i]);
        }
    }

    public void AddPerson(Human h)
    {
        if (h.gender)
        {
            MaleFinalSolution.Add(h);
        }
        else
        {
            FemaleFinalSolution.Add(h);
        }
    }

    public Planet(List<Human> maleFinalSolution, List<Human> femaleFinalSolution, string name, int age, int population)
    {
        this.Name = name;
        this.Age = age;
        this.Population = population;

        this.MaleFinalSolution = maleFinalSolution;
        this.FemaleFinalSolution = femaleFinalSolution;
    }
}