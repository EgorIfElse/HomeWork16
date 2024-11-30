
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string jsonString = String.Empty;
        using (StreamReader sr = new StreamReader("../../../../Products.json"))
        {
            jsonString = sr.ReadToEnd();
        }
        Console.WriteLine(jsonString);
        Tovar[] tovar = JsonSerializer.Deserialize<Tovar[]>(jsonString);
        Tovar[] tovarMax = tovar[0];
        foreach (Tovar t in tovar)
        {
            if (t.Price > tovarMax.Price)
            {
                tovarMax = t;
            }
        }
        Console.WriteLine($"{tovarMax.Name}");
    }
}
public class Tovar
{
    public int Code { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}