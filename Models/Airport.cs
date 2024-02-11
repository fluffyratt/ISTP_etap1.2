using System;
using System.Collections.Generic;

namespace Flights.WebApplication;

public partial class Airport
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Flight> FlightArrivalAiroportNavigations { get; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAiroportNavigations { get; } = new List<Flight>();
}
