namespace LocalityApp;

public class City: ILocality, IPopulation
{
    public string Name { get; set; }
    public int Population { get; set; }
    public double Area { get; set; }
    public bool HasMetro { get; set; }

    public City(string name, int population, double area, bool hasMetro)
    {
        Name = name;
        Population = population;
        Area = area;
        HasMetro = hasMetro;
    }

    public string GetName() => Name;
    public string GetType() => "Місто";
    public int GetPopulation() => Population;
    public double GetDensity() => Population / Area;

    public string GetCityInfo() => 
        $"Місто {Name}: {Population} осіб, густота {GetDensity():F2} осіб/км², метро: {(HasMetro ? "є" : "немає")}";
}