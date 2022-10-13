using Catcheap.Models.Vehicles_Classes.Cars_Classes;

namespace Catcheap.Views;

public partial class StatsPage : ContentPage
{

    Car car = new Car();
    CarLoaderSaver carLoaderSaver = new CarLoaderSaver();

    public StatsPage()
	{
		InitializeComponent();
	}

    private void LoadButtonClicked(object sender, EventArgs e)
    {
        carLoaderSaver.Load(car);
        Monday.Text = "Monday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Monday)).ToString();
        Tuesday.Text = "Tuesday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Tuesday)).ToString();
        Wednesday.Text = "Wednesday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Wednesday)).ToString();
        Thursday.Text = "Thursday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Thursday)).ToString();
        Friday.Text = "Friday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Friday)).ToString();
        Saturday.Text = "Saturday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Saturday)).ToString();
        Sunday.Text = "Sunday: " + Journeys.AverageDistance(car.GetJourneys().GetWeekDayJourneyList(DayOfWeek.Sunday)).ToString();
    }
}