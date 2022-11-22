using System.ComponentModel.DataAnnotations;

namespace CatcheapAPI.Models.Journeys_Classes
{
    public class Journey : IComparable<Journey>
    {
        [Key]
        public int JourneyId { get; set; }
        public DateTime Date { get; set; }
        public int Dist { get; set; }

        public int JourneysJourneysId { get; set; }

        public int CompareTo(Journey other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
