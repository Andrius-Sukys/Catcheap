namespace Catcheap.API.Models.MiscModels;

public class NordpoolPrice : IComparable<NordpoolPrice>
{
    public int Id { get; set; }

    public DateTime DateAndTime { get; set; }

    public double Price { get; set; }

    public int CompareTo(NordpoolPrice? other)
    {
        return Price.CompareTo(other.Price);
    }
}
