﻿using System.ComponentModel;
using Catcheap.Models.FileIO_Classes;

namespace Catcheap.Views;

public class JourneyField : INotifyPropertyChanged
{

    string journeyDate = DateOnly.FromDateTime(DateTime.Now).ToString();
    public string JourneyDate
    {
        get { return journeyDate; }
        set { journeyDate = DateOnly.FromDateTime(DateTime.Parse(value)).ToString(); OnPropertyChanged(nameof(JourneyDate)); }
    }
    double? journeyDistance;
    public double? JourneyDistance
    {
        get { return journeyDistance; }
        set { journeyDistance = value; OnPropertyChanged(nameof(JourneyDistance)); }
    }

    int? selectedIndex;
    public int? SelectedIndex
    {
        get { return selectedIndex; }
        set { selectedIndex = value; OnPropertyChanged(nameof(SelectedIndex)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void ClearFields()
    {
        JourneyDistance = null;
        SelectedIndex = null;
    }

    public void ClearJourneys()
    {
        FileIO fileIO = new FileIO();
        if ("journeys.txt" != null)
            fileIO.ClearTextFile("journeys.txt");
    }

}

