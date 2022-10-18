using System;
using System.Globalization;

namespace Catcheap.Models.Price_Classes;

public class DayPrice
{
	public DayPrice(DateOnly date, String[] price)
	{
		this.date = date;

		for(int i = 0; i < (price.Length - 1); i++)
		{
			hourePrice[i] = Math.Round(Double.Parse(price[i+1].Replace(',', '.'))/1000, 5);
		}

	}

	public DateOnly date { get; set; }

	Double[] hourePrice = new double[24];

	public double getHourePrice(int i)
	{
		return hourePrice[i];
	}

    public override string ToString()
	{
		string rez = "";

		rez += date.ToString();

        for (int i = 0; i < hourePrice.Length; i++)
        {
			rez += " " + hourePrice[i];
        }

        return rez;
	}


}
