using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap
{
    internal class ValidateInput
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
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
