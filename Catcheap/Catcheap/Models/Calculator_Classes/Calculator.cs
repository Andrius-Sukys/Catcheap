using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Models.Calculator_Classes;

internal class Calculator
{
    public double distance { get; set; }
    public double consumption { get; set; }
    public double electricityPrice { get; set; }

    public double calculatePrice()
    {
        if (distance <= 0 || consumption <= 0 || electricityPrice <= 0)
        {
            return -1;
        }
        else
        {
            return Math.Round(consumption / 100 * distance * electricityPrice, 2);
        }
    }

    public double calculateFullChargePrice(double batteryCapacity, double batteryLevel, double price)
    {
        return Math.Round((batteryCapacity / 100 * (100 - batteryLevel) * price), 2);
    }
}

