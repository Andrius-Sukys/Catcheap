using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Catcheap
{
    public struct Distance : IComparable<Distance>
    {
        public DateOnly date;
        public int dist;

        public int CompareTo(Distance other)
        {
            return date.CompareTo(other.date);
        }
    }

    public class CarDistance
    {
        private List<Distance> distanceList = new List<Distance>();
        FileIO fileIO = new FileIO();

        public void load()
        {

            distanceList.Clear();

            string temp = fileIO.ReadTextFile("CarDistance.txt");

            foreach(Match match in Regex.Matches(temp, @"\bDate: \S* Dist: \S*"))
            {
               Distance newDistance = new Distance();
               string tempDate = Regex.Replace(Regex.Match(match.Value, @"\bDate: \S*").Value, @"\bDate: ", "");
               string tempDist = Regex.Replace(Regex.Match(match.Value, @"\bDist: \S*").Value, @"\bDist: ", "");

                newDistance.date = DateOnly.Parse(tempDate);
                newDistance.dist = Int16.Parse(tempDist);

                distanceList.Add(newDistance);

            }
            
        }

        public void save()
        {
            fileIO.ClearTextFile("CarDistance.txt");
            foreach(Distance distance in distanceList)
            {
                fileIO.UpdateTextFile("Date: " + distance.date.ToString() + " Dist: " + distance.dist.ToString() + Environment.NewLine, "CarDistance.txt");
            }
        }

        public float averageDistance()
        {
            float temp = 0;
            int count = 0;

            foreach(Distance distance in distanceList)
            {
                temp += distance.dist;
                count++;
            }

            return temp / count;
        }

        public void addDistance(DateOnly date, int dist)
        {

            Distance newDistance = new Distance();

            newDistance.date = date;
            newDistance.dist = dist;

            distanceList.Add(newDistance);

        }

        public override string ToString()
        {
            string temp = "";

            foreach (Distance distance in distanceList)
            {
                temp += "Date: " + distance.date.ToString() + " Distance: " + distance.dist.ToString() + Environment.NewLine;
            }

            return temp;
        }

    }
}
