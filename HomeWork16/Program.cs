using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Task1;

internal class Program
{
    private static void Main(string[] args)
    {
        const int n = 5;
        Tovar[] tovar = new Tovar[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите код товара");

            int code = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();

            Console.WriteLine("Введите цену товара");
            int price = Convert.ToInt32(Console.ReadLine());

            tovar[i] = new Tovar() { Code = code, Name = name, Price = price };
        }
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(tovar, options);
        using (StreamWriter sw = new StreamWriter("../../../Products.json"))
        {
            sw.WriteLine(jsonString);
        }

    }

}