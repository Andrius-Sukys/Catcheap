using Catcheap.Models.Validation_Classes;

namespace Catcheap.Models.Notification_Classes;

public class NotificationWindow
{
    public NotificationWindow()
    {

    }

    public static async void InvalidInputEventHandler<T>(ValidateInput<T> validateInput, ValidateInput<T>.InvalidInputEventArgs args)
    {
        await Shell.Current?.CurrentPage.DisplayAlert("Alert", "Invalid input!", "OK");

    }
}
