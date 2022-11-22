using Plugin.LocalNotification;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.EventArgs_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Models.Notification_Classes;

public class PushNotification
{
    public PushNotification(Vehicle v)
    {
        Vehicle vehicle = v;

        v.LowOnBattery += LowOnBatteryHandler;

    }

    private static void LowOnBatteryHandler(object sender, LowOnBatteryEventArgs args)
    {
        if (sender is Car)
        {
            GetNotification("car", args.BatteryLevel);
        }
        if (sender is VehicleScooter)
        {
            GetNotification("scooter", args.BatteryLevel);
        }
        
    }

    private static void GetNotification(string vehicle, double batteryLevel)
    {
        var request = new NotificationRequest
        {
            Title = "Running low on battery!",
            Subtitle = batteryLevel.ToString() + "%",
            Description = "Your " + vehicle + " is almost out of charge!",
        };
        LocalNotificationCenter.Current.Show(request);
    }
    

    
}
