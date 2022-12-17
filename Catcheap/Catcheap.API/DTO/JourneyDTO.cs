namespace Catcheap.API.DTO;

public class JourneyDTO
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public double Distance { get; set; }

    public string StartLocation { get; set; } = null!;

    public string EndLocation { get; set; } = null!;

}
