﻿using System;
using System.Globalization;

namespace Catcheap.Models.Price_Classes;

public class DayPrice
{
	public DayPrice(DateOnly date, String[] price)
	{
		this.date = date;

		for(int i = 0; i < (price.Length - 1); i++)
		{
			hourPrice[i] = Math.Round(Double.Parse(price[i+1].Replace(',', '.'))/1000, 5);
		}

	}

	public DateOnly date { get; set; }

	Double[] hourPrice = new double[24];

	public double getHourPrice(int i)
	{
		return hourPrice[i];
	}

	public string getDaysCheapestPriceAndHourString(int currentHour)
	{
		double cheapestPrice = hourPrice[currentHour];
		double cheapestHour = currentHour;
		for(int i = currentHour; i < 24; i++)
		{
            if (hourPrice[i] < cheapestPrice)
			{
                cheapestPrice = hourPrice[i];
				cheapestHour = i;
            }
				

		}

        return cheapestPrice.ToString() + " €/kWh\n" + cheapestHour.ToString() + ":00 - " + (cheapestHour+1)%24 + ":00";
    }

    public override string ToString()
	{
		string rez = "";

		rez += date.ToString() + '\n';

        for (int i = 0; i < hourPrice.Length; i++)
        {
			rez += i + ":00 | " + hourPrice[i] + " €/kWh\n";
        }

        return rez;
	}


}
