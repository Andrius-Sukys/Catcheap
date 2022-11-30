namespace Catcheap.Client;

public class StoragePermissions
{
    public static async void Init()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

        if (status == PermissionStatus.Denied)
        {
            status = await Permissions.RequestAsync<Permissions.StorageWrite>();
            if (status == PermissionStatus.Denied)
            {
                Application.Current.Quit();
            }
        }
    }
    
}
