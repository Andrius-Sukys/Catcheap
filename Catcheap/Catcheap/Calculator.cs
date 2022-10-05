using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap;

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
            return Math.Round((consumption / 100) * distance * electricityPrice, 2);
        }
    }
}

