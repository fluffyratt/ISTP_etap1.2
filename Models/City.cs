using System;
using System.Collections.Generic;

namespace Flights.WebApplication;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<Airport> Airports { get; } = new List<Airport>();

    public virtual Country Country { get; set; } = null!;
}
