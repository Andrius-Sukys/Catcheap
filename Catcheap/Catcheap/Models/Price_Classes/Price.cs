using System;

namespace Catcheap.Models.Price_Classes;
public class Price
{
	public Price(List<DayPrice> dayPrices, PriceReader priceReader)
	{
		this.dayPrices = dayPrices;
		this.reader = priceReader;
	}

	PriceReader reader;

	List<DayPrice> dayPrices;

	public string getPriceString()
	{

		reader.readPrices(dayPrices);

		string rez = "";

		foreach(DayPrice dayPrice in dayPrices)
		{
			rez += dayPrice.ToString() + "\n";
		}

		return rez;
	}

	public double getCurrentPrice()
	{

		DateTime currentDateTime = DateTime.Now;

        reader.readPrices(dayPrices);

		foreach(DayPrice dayPrice in dayPrices)
		{
			if(dayPrice.date == DateOnly.FromDateTime(currentDateTime)){
				return dayPrice.getHourPrice(currentDateTime.Hour);
			}
		}

		return 0;
    }

    public string GetCheapestPriceAndHourString()
    {
        DateTime currentDateTime = DateTime.Now;

        reader.readPrices(dayPrices);

		string cheapest = null;

        for (int i = 0; i < dayPrices.Count; i++)
        {
            if (dayPrices[i].date == DateOnly.FromDateTime(currentDateTime))
            {
				cheapest = dayPrices[i].getDaysCheapestPriceAndHourString(DateTime.Now.Hour);
            }
        }

        return cheapest;
    }
}
