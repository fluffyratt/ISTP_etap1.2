using System;
using System.Collections.Generic;

namespace Flights.WebApplication;

public partial class Flight
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Date { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Duration { get; set; }

    public int DepartureAiroport { get; set; }

    public int ArrivalAiroport { get; set; }

    public virtual Airport ArrivalAiroportNavigation { get; set; } = null!;

    public virtual ICollection<CategoriesFlight> CategoriesFlights { get; } = new List<CategoriesFlight>();

    public virtual Airport DepartureAiroportNavigation { get; set; } = null!;
}
