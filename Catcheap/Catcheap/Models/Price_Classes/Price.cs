using System;

namespace Catcheap.Models.Price_Classes;
public class Price
{
	public Price()
	{
	}

	PriceReader reader = new PriceReader();

	List<DayPrice> dayPrices = new List<DayPrice>();

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
				return dayPrice.getHourePrice(currentDateTime.Hour);
			}
		}

		return 0;
    }


}
