using Catcheap.Models.Validation_Classes;
using Catcheap.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Models.Notification_Classes;

public class NotificationWindow
{
    public NotificationWindow()
    {

    }

    public async void InvalidInputEventHandler<T>(ValidateInput<T> validateInput, ValidateInput<T>.InvalidInputEventArgs args)
    {
        await Shell.Current?.CurrentPage.DisplayAlert("Alert", "Invalid input!", "OK");

    }
}
