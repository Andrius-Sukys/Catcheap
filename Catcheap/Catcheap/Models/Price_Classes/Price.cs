namespace Catcheap.Models.Price_Classes;
public class Price
{
	public Price(List<DayPrice> dayPrices, PriceReader priceReader)
	{
		this.dayPrices = dayPrices;
		this.reader = priceReader;
	}

	readonly PriceReader reader;
	readonly List<DayPrice> dayPrices;

	public string GetPriceString()
	{

		PriceReader.ReadPrices(dayPrices);

		string rez = "";

		foreach(DayPrice dayPrice in dayPrices)
		{
			rez += dayPrice.ToString() + "\n";
		}

		return rez;
	}

	public double GetCurrentPrice()
	{

		DateTime currentDateTime = DateTime.Now;

		PriceReader.ReadPrices(dayPrices);

		foreach(DayPrice dayPrice in dayPrices)
		{
			if(dayPrice.Date == DateOnly.FromDateTime(currentDateTime)){
				return dayPrice.GetHourPrice(currentDateTime.Hour);
			}
		}

		return 0;
    }

    public string GetCheapestPriceAndHourString()
    {
        DateTime currentDateTime = DateTime.Now;

		PriceReader.ReadPrices(dayPrices);

		string cheapest = null;

        for (int i = 0; i < dayPrices.Count; i++)
        {
            if (dayPrices[i].Date == DateOnly.FromDateTime(currentDateTime))
            {
				cheapest = dayPrices[i].GetDaysCheapestPriceAndHourString(DateTime.Now.Hour);
            }
        }

        return cheapest;
    }
}
