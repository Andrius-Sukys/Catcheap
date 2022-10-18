namespace Catcheap.Models.Journeys_Classes
{
    public struct Journey : IComparable<Journey>
    {
        public DateOnly Date { get; set; }
        public int Dist { get; set; }

        public int CompareTo(Journey other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
