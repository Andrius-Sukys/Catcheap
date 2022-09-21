using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap;

internal class Calculator
{
    public double distance;
    public double consumption;
    public double electricityPrice;
    public double calculatePrice()
    {
        if (distance == -1 || consumption == -1 || electricityPrice == -1)
        {
            return -1;
        }
        else
        {
            return Math.Round((consumption / 100) * distance * electricityPrice, 2);
        }
    }
}

