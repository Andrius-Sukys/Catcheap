using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using System.Globalization;

namespace Catcheap.Views;

public partial class StatsPage : ContentPage
{
    readonly Car car;
    readonly JourneysLoaderSaver journeysLoaderSaver;

    public StatsPage(Car car, JourneysLoaderSaver journeysLoaderSaver)
	{
        this.car = car;
        this.journeysLoaderSaver = journeysLoaderSaver;
		InitializeComponent();
	}

    private void LoadButtonClicked(object sender, EventArgs e)
    {

        journeysLoaderSaver.Load(car.GetJourneys());
        Monday.Text = "Monday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Monday)).ToString();
        Tuesday.Text = "Tuesday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Tuesday)).ToString();
        Wednesday.Text = "Wednesday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Wednesday)).ToString();
        Thursday.Text = "Thursday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Thursday)).ToString();
        Friday.Text = "Friday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Friday)).ToString();
        Saturday.Text = "Saturday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Saturday)).ToString();
        Sunday.Text = "Sunday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Sunday)).ToString();

        PastWeek.Text = "Past week: " + car.Journeys.DistancePastWeek().ToString();
        PastMonth.Text = "Past month: " + car.Journeys.DistancePastMonth().ToString();
        PastYear.Text = "Past year: " + car.Journeys.DistancePastYear().ToString();

        ThisMonth.Text = "This month (" + (DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture)) + "): " + car.Journeys.DistanceThisMonth().ToString();
        ThisYear.Text = "This year (" + (DateTime.Now.Year.ToString()) + "): "  + car.Journeys.DistanceThisYear().ToString();
    }
}