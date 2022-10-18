namespace Catcheap.Models.Vehicles_Classes;

public class Vehicles
{
    public List<Vehicle> vehicles;

    public Vehicles()
    {
        vehicles = new List<Vehicle>();
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
