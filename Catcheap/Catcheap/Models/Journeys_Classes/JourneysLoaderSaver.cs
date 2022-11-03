﻿using System.Text.RegularExpressions;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.FileIO_Classes.Interfaces;
using Catcheap.Models.Journeys_Classes;

namespace Catcheap
{
    public class JourneysLoaderSaver : ILoader<Journeys>, ISaver<Journeys>
    {

        private FileIO file;

        public JourneysLoaderSaver(FileIO fileIO)
        {
            this.file = fileIO;
        }

        public void Load(Journeys journeys, String fileName = "journeys.txt")
        {
            journeys.ClearList();

            string temp = file.ReadTextFile(fileName);

            if (temp != null)
            {
                foreach (Match match in Regex.Matches(temp, @"\bDistance: \S+ Date: \S+"))
                {
                    Journey newDistance = new Journey();
                    string tempDate = Regex.Replace(Regex.Match(match.Value, @"\bDate: \S+").Value, @"\bDate: ", "");
                    string tempDist = Regex.Replace(Regex.Match(match.Value, @"\bDistance: \S+").Value, @"\bDistance: ", "");

                    newDistance.Date = DateOnly.Parse(tempDate);
                    newDistance.Dist = int.Parse(tempDist);

                    journeys.AddJourney(newDistance);

                }
            }
        }

        public void Save(Journeys journeys, String fileName = "journeys.txt")
        {
            journeys.SortList();

            file.WriteTextToFile(journeys.ToString(), fileName);
        }
    }
}
