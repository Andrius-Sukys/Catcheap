using Catcheap.Models.Notification_Classes;
using Java.Nio.Channels;
using System.Runtime.CompilerServices;
using Catcheap.Views;

namespace Catcheap.Models.Validation_Classes;

public delegate void InvalidInputEventHandler<T, U>(T sender, U eventArgs);

public class ValidateInput<T>
{
    public class InvalidInputEventArgs : System.EventArgs { }

    public event InvalidInputEventHandler<ValidateInput<T>, InvalidInputEventArgs> InvalidInput;

    protected virtual void OnInvalidInput(InvalidInputEventArgs args)
    {
        InvalidInput?.Invoke(this, args);
    }

    public double? ValidateInputNumber(T input)
    {
        if (double.TryParse(input.ToString(), out double parsedNumber))
        {
            return parsedNumber;
        }
        else
        {
            return null;
        }
    }

    public bool ValidateInputBool(T input)
    {
        if (bool.TryParse(input.ToString(), out bool _))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ValidateInputPositiveNumber(T input)
    {
        if (ValidateInputNumber(input) > 0)
            return true;
        else
            return false;
    }

    public bool ValidateInputNull (T input)
    {
        if (input is not null)
        {
            return true;
        }
        else
        {
            ValidateInput<string> vi = new ValidateInput<string>();
            NotificationWindow nw = new NotificationWindow();
            vi.InvalidInput += nw.InvalidInputEventHandler;
            OnInvalidInput(null);
            return false;
        }
    }
}

