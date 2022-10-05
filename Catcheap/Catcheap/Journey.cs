using System.ComponentModel;

namespace Catcheap;

public class Journey : INotifyPropertyChanged
{
    DateOnly journeyDate = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly JourneyDate
    {
        get { return journeyDate; }
        set { journeyDate = value; OnPropertyChanged(nameof(JourneyDate));  }
    }
    double journeyDistance;
    public double JourneyDistance
    {
        get { return journeyDistance; }
        set { journeyDistance = value; OnPropertyChanged(nameof(JourneyDistance)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void ClearFields()
    {
        JourneyDistance = 0;
    }

    public void ClearJourneys()
    {
        FileIO fileIO = new FileIO();
        if ("journeys.txt" != null)
            fileIO.ClearTextFile("journeys.txt");
    }
    
}

