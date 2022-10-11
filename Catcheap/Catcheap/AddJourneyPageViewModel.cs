using System.ComponentModel;
using System.Windows.Input;

namespace Catcheap;

public class AddJourneyPageViewModel : INotifyPropertyChanged
{
    public Journey Journey { get; } = new Journey();
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
        fileIO.UpdateTextFile(Journey.JourneyDistance + " " + Journey.JourneyDate + '\n', "journeys.txt");
        Car car = new Car();
        CarLoaderSaver carLoaderSaver = new CarLoaderSaver();
        carLoaderSaver.Load(car);
        car.UpdateCarPropertiesAfterJourney(Journey.JourneyDistance);
        carLoaderSaver.Save(car);

        Journey.ClearFields();

    }
}
