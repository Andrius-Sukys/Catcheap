using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Catcheap
{
    public class Car
    {

        string Name { get; set; }
        string BatterySize { get; set; }
        string Consumption { get; set; }
        string ChargingPower { get; set; }

        public CarDistance carDistance = new CarDistance();

        private FileIO file = new FileIO();

        private string NamePattern = "Name: ";
        private string BatteryPattern = "Battery size: ";
        private string ConsumtionPattern = "Consumption rate: ";
        private string ChargingPattern = "Charging power: ";

        public void Load() {

            string temp = file.ReadTextFile("carinfo.txt");

            Name = Regex.Replace(Regex.Match(temp, @"\b" + NamePattern + @"\S*").Value, @"\b" + NamePattern, "");

            BatterySize = Regex.Replace(Regex.Match(temp, @"\b" + BatteryPattern + @"\S*").Value, @"\b" + BatteryPattern, "");

            Consumption = Regex.Replace(Regex.Match(temp, @"\b" + ConsumtionPattern + @"\S*").Value, @"\b" + ConsumtionPattern, "");

            ChargingPower = Regex.Replace(Regex.Match(temp, @"\b" + ChargingPattern + @"\S*").Value, @"\b" + ChargingPattern, "");

            carDistance.load();

        }

        public void Save() {

            file.WriteTextToFile(NamePattern + Name + '\n' + 
                               BatteryPattern + BatterySize + '\n' +
                               ConsumtionPattern + Consumption + '\n' +
                               ChargingPattern + ChargingPower + '\n', "carinfo.txt");

            carDistance.save();

        }

        public void SetAll(string Name, string BatterySize, string Consumption, string ChargingPower)
        {
            this.Name = Name;
            this.BatterySize = BatterySize;
            this.Consumption = Consumption;
            this.ChargingPower = ChargingPower;
        }

        public override string ToString() {

            return NamePattern + Name + '\n' +
                               BatteryPattern + BatterySize + " kWh" + '\n' +
                               ConsumtionPattern + Consumption + " kWh/100 km" + '\n' +
                               ChargingPattern + ChargingPower + " kW" + '\n' +
                               carDistance.ToString();


        }

    }
}
