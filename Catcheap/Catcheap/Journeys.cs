using Catcheap.Models.Journeys_Classes;

namespace Catcheap
{

    public class Journeys
    {
        private List<Journey> distanceList = new List<Journey>();

        public void ClearList() { distanceList.Clear(); }

        public void AddJourney(Journey journey)
        {
            distanceList.Add(journey);
        }

        public List<Journey> GetDayJourneyList()
        {
           List<Journey> DayJourneyList = new List<Journey>();

           foreach(Journey journey in distanceList)
           {
                bool inDayJourney = false;

                foreach(Journey dayJourney in DayJourneyList)
                {
                    if(DateOnly.FromDateTime(dayJourney.Date) == DateOnly.FromDateTime(journey.Date))
                    {
                        inDayJourney = true;
                        Journey newJourney = new Journey();
                        newJourney.Date = dayJourney.Date;
                        newJourney.Dist = dayJourney.Dist + journey.Dist;
                        DayJourneyList.Remove(dayJourney);
                        DayJourneyList.Add(newJourney);
                        break;
                    }
                }

                if (!inDayJourney)
                {
                    DayJourneyList.Add(journey);
                }

           } 

           return DayJourneyList;
        }

        public String Test(List<Journey> DayJourneyList)
        {
            string temp = "";

            foreach (Journey journey in DayJourneyList)
            {
                temp += "Distance: " + journey.Dist + " Date: " + journey.Date + Environment.NewLine;
            }

            return temp;
        }

        public List<Journey> GetWeekDayJourneyList(DayOfWeek dayOfWeek)
        {
            List<Journey> WeekDayJourneyList = 
                (from weekDay in GetDayJourneyList()
                where weekDay.Date.DayOfWeek == dayOfWeek
                select weekDay).ToList();

            return WeekDayJourneyList;
        }

        public static float AverageDistance(List<Journey> journeyList)
        {
            float temp = 0;
            int count = 0;

            if (!journeyList.Any())
            {
                return 0;
            }

            foreach(Journey journey in journeyList)
            {
                temp += journey.Dist;
                count++;
            }

            return temp / count;
        }

        public override string ToString()
        {
            string temp = "";

            foreach (Journey journey in distanceList)
            {
                temp += "Distance: " + journey.Dist + " Date: " + journey.Date + Environment.NewLine;
            }

            return temp;
        }

    }
}
