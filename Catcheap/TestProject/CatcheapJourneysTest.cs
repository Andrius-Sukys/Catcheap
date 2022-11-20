using Catcheap;
using Catcheap.Models.Journeys_Classes;

namespace TestProject
{
    public class CatcheapJourneysTest
    {
        Journeys journeys = new Journeys(new List<Journey>(), new List<Journey>());
        [Fact]
        public void ClearListTest()
        {

            Journeys.distanceList.Add(new Journey());

            journeys.ClearList();

            Assert.True(Journeys.distanceList.Count == 0);
        }

        [Fact]
        public void GetDateOnlyTodayTest()
        {
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today), Journeys.GetDateOnlyToday());
        }

        [Fact]
        public void GetDateOnlyWeekBeforeTest()
        {
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today.AddDays(-7)), Journeys.GetDateOnlyWeekBefore());
        }

        [Fact]
        public void GetDateOnlyMonthBeforeTest()
        {
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today.AddMonths(-1)), Journeys.GetDateOnlyMonthBefore());
        }

        [Fact]
        public void GetDateOnlyThisMonthTest()
        {
            Assert.Equal(new DateOnly(DateTime.Now.Year, DateTime.Now.Month, 1), Journeys.GetDateOnlyThisMonth());
        }

        [Fact]
        public void GetDateOnlyPastYearTest()
        {
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today.AddYears(-1)), Journeys.GetDateOnlyPastYear());
        }

        [Fact]
        public void GetDateOnlyThisYearTest()
        {
            Assert.Equal(new DateOnly(DateTime.Now.Year, 1, 1), Journeys.GetDateOnlyThisYear());
        }

        [Fact]
        public void AverageDistanceTest()
        {
            List <Journey>  list = new List<Journey>();

            var journey1 = new Journey();
            var journey2 = new Journey();

            journey1.Dist = 400;
            journey2.Dist = 0;

            list.Add(journey1);
            list.Add(journey2);

            Assert.Equal(200, Journeys.AverageDistance(list));
        }

    }
}
