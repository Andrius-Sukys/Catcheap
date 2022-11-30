using Catcheap.Models.Exception_Classes;
using Catcheap.Models.FileIO_Classes;

namespace Catcheap.Models.Price_Classes;
public class PriceReader
{
	public PriceReader()
    {
    }
    public static async void ReadPrices(List<DayPrice> dayPrices)
    {

        using StreamReader reader = new StreamReader(await FileSystem.Current.OpenAppPackageFileAsync("Resources/Files/price.txt"));

        string line = string.Empty;
        try
        {
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(' ');
                dayPrices.Add(new DayPrice(DateOnly.Parse(parts[0]), parts));
            }
        }
        catch (Exception ex)
        {
            ExceptionLogger.LogException(ex);
        }

    }
}
