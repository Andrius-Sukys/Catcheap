using System.Text.RegularExpressions;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.FileIO_Classes.Interfaces;

namespace Catcheap.Models.Journeys_Classes
{
    internal class JourneysLoaderSaver : ILoader<Journeys>, ISaver<Journeys>
    {

        private FileIO file = new FileIO();

        public void Load(Journeys journeys, string fileName = "journeys.txt")
        {
            journeys.ClearList();

            string temp = file.ReadTextFile(fileName);

            foreach (Match match in Regex.Matches(temp, @"\bDistance: \S* Date: \S*"))
            {
                Journey newDistance = new Journey();
                string tempDate = Regex.Replace(Regex.Match(match.Value, @"\bDate: \S*").Value, @"\bDate: ", "");
                string tempDist = Regex.Replace(Regex.Match(match.Value, @"\bDistance: \S*").Value, @"\bDistance: ", "");

                newDistance.Date = DateTime.Parse(tempDate);
                newDistance.Dist = Int32.Parse(tempDist);

                journeys.AddJourney(newDistance);

            }
        }

        public void Save(Journeys journeys, string fileName = "journeys.txt")
        {
            file.WriteTextToFile(journeys.ToString(), fileName);
        }
    }
}
