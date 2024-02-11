using System;
using System.Collections.Generic;

namespace Flights.WebApplication;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; } = new List<City>();
}
