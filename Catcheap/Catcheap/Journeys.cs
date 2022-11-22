using Catcheap.Models.Journeys_Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap
{

    public class Journeys
    {
        public int JourneysId { get; set; }
        public  List<Journey> DistanceList { get; set; }
        private  List<Journey> HelperList { get; set; }

        public int CarVehicleId { get; set; }

        public Journeys(List<Journey> journeyList, List<Journey> helpList)
        {
            DistanceList = journeyList;
            HelperList = helpList;
        }

        public void ClearList() { DistanceList.Clear(); }

        public void AddJourney(Journey journey)
        {
            DistanceList.Add(journey);
        }

        public void SortList()
        {
            DistanceList.Sort();
        }

        public  List<Journey> GetDayJourneyList()
        {
           HelperList.Clear();
           List<Journey> DayJourneyList = HelperList;

           foreach(Journey journey in DistanceList)
           {
                bool inDayJourney = false;

                foreach(Journey dayJourney in DayJourneyList)
                {
                    if(dayJourney.Date == journey.Date)
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

        public List<Journey> GetWeekDayJourneyList(DayOfWeek dayOfWeek)
        {
            List<Journey> WeekDayJourneyList = 
                (from weekDay in GetDayJourneyList()
                where weekDay.Date.DayOfWeek == dayOfWeek
                select weekDay).ToList();

            return WeekDayJourneyList;
        }

        public List<Journey> GetJourneysInRange(DateOnly endDate, DateOnly startDate)
        {
            List<Journey> JourneysThisWeek =
                (from journey in GetDayJourneyList()
                where journey.Date <= endDate &&
                      journey.Date >= startDate
                select journey).ToList();

            return JourneysThisWeek;
        }

        public double DistancePastWeek()
        {
            double weeklyDistance = 0;
            foreach(Journey journey in GetJourneysInRange(GetDateOnlyToday(), GetDateOnlyWeekBefore()))
            {
                weeklyDistance = weeklyDistance + journey.Dist;
            }

            return weeklyDistance;
        }

        public double DistancePastMonth()
        {
            double monthlyDistance = 0;
            foreach (Journey journey in GetJourneysInRange(GetDateOnlyToday(), GetDateOnlyMonthBefore()))
            {
                monthlyDistance = monthlyDistance + journey.Dist;
            }

            return monthlyDistance;
        }

        public  double DistanceThisMonth()
        {
            double monthlyDistance = 0;
            foreach (Journey journey in GetJourneysInRange(GetDateOnlyToday(), GetDateOnlyThisMonth()))
            {
                monthlyDistance = monthlyDistance + journey.Dist;
            }

            return monthlyDistance;
        }
        public double DistancePastYear()
        {
            double yearlyDistance = 0;
            foreach (Journey journey in GetJourneysInRange(GetDateOnlyToday(), GetDateOnlyPastYear()))
            {
                yearlyDistance = yearlyDistance + journey.Dist;
            }

            return yearlyDistance;
        }

        public double DistanceThisYear()
        {
            double yearlyDistance = 0;
            foreach (Journey journey in GetJourneysInRange(GetDateOnlyToday(), GetDateOnlyThisYear()))
            {
                yearlyDistance = yearlyDistance + journey.Dist;
            }

            return yearlyDistance;
        }



        public static DateOnly GetDateOnlyToday()
        {
            return new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day);
        }

        public static DateOnly GetDateOnlyWeekBefore()
        {
            return DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-7));
        }

        public static DateOnly GetDateOnlyMonthBefore()
        {
            return DateOnly.FromDateTime(DateTime.Now.Date.AddMonths(-1));
        }

        public static DateOnly GetDateOnlyThisMonth()
        {
            return new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
        }

        public static DateOnly GetDateOnlyPastYear()
        {
            return DateOnly.FromDateTime(DateTime.Now.Date.AddYears(-1));
        }

        public static DateOnly GetDateOnlyThisYear()
        {
            return new DateOnly(DateTime.Now.Date.Year, 1, 1);
        }

        public static double AverageDistance(List<Journey> journeyList)
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

            return Math.Round(temp / count, 2);
        }

        public override string ToString()
        {
            string temp = "";

            foreach (Journey journey in DistanceList)
            {
                temp += "Distance: " + journey.Dist + " Date: " + journey.Date + '\n';
            }

            return temp;
        }

    }
}
