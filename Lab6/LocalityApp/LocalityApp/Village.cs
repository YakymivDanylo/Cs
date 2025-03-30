namespace LocalityApp;

public class Village: ILocality, IPopulation
{
    public string Name { get; set; }
    public int Population { get; set; }
    public double Area { get; set; }
    
    public Village(string name, int population, double area)
    {
        Name = name;
        Population = population;
        Area = area;
    }

    public string GetName() => Name;
    public string GetType() => "Село";
    public int GetPopulation() => Population;
    public double GetDensity() => Population / Area;

    public string GetVillageInfo() => 
        $"Село {Name}: {Population} осіб, густота {GetDensity():F2} осіб/км²";
    
}