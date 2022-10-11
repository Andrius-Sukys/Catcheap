using System.ComponentModel;
using System.Windows.Input;

namespace Catcheap;

public class AddJourneyPageViewModel : INotifyPropertyChanged
{
    public JourneyField JourneyField { get; } = new JourneyField();
    public AddJourneyPageViewModel()
    {
        PostJourneys = new Command(AddJourney);
    }

    public ICommand PostJourneys { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void AddJourney()
    {
        FileIO fileIO = new FileIO();
        fileIO.UpdateTextFile("Distance: " + JourneyField.JourneyDistance + " Date: " + JourneyField.JourneyDate + Environment.NewLine, "journeys.txt");
        Car car = new Car();
        CarLoaderSaver carLoaderSaver = new CarLoaderSaver();
        carLoaderSaver.Load(car);
        car.UpdateCarPropertiesAfterJourney(JourneyField.JourneyDistance);
        carLoaderSaver.Save(car);

        JourneyField.ClearFields();

    }
}
