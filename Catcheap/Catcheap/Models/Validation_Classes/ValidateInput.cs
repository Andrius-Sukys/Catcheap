using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Models.Validation_Classes;

public class ValidateInput
{
    public bool ValidateInputAsAPositiveNumber(string input)
    {
        if (!double.TryParse(input, out double number) || number < 0)
        {
            return false;
        }
        return true;
    }

    public bool ValidateInputAsNull(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

