﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.API.Models.CarModels;

public class CarJourney
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public double Distance { get; set; }

    public string StartLocation { get; set; } = null!;

    public string EndLocation { get; set; } = null!;

    [JsonIgnore]
    public Car Car { get; set; } = null!;

}
