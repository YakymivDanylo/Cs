namespace WpfApp1;

public class Country
{
    private string name;
    private string capital;
    private int population;
    private double area;
    private string officialLanguage;
    private string currency;
    private string continent;

    public string Name { get => name; set => name = value; }
    public string Capital { get => capital; set => capital = value; }
    public int Population { get => population; set => population = value; }
    public double Area { get => area; set => area = value; }
    public string OfficialLanguage { get => officialLanguage; set => officialLanguage = value; }
    public string Currency { get => currency; set => currency = value; }
    public string Continent { get => continent; set => continent = value; }

    public Country() { }

    public string GetCountryInfo()
    {
        return $"Країна: {name}\nСтолиця: {capital}\nНаселення: {population}\nПлоща: {area} км²\nОфіційна мова: {officialLanguage}\nВалюта: {currency}\nКонтинент: {continent}";
    }

    public double CalculatePopulationDensity()
    {
        return population / area;
    }

    public override string ToString()
    {
        return GetCountryInfo();
    }
}