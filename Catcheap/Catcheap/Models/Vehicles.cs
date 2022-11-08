namespace Catcheap.Models.Vehicles_Classes;

public class Vehicles
{
    public List<Vehicle> vehicles;

    public Vehicles(List<Vehicle> vehicleList)
    {
        vehicles = vehicleList;
    }

    public IEnumerable<Vehicle> GetCharges()
    {
        return vehicles;
    }

    public void AddVehicle(Vehicle charge)
    {
        vehicles.Add(charge);
    }
}
