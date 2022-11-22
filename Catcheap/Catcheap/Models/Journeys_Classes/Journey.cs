namespace Catcheap.Models.Journeys_Classes
{
    public struct Journey : IComparable<Journey>
    {
        public int JourneyId { get; set; }
        public DateOnly Date { get; set; }
        public int Dist { get; set; }
        public int JourneysJourneysId { get; set; }

        public int CompareTo(Journey other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
