using System;
using System.Collections.Generic;

namespace Flights.WebApplication;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CategoriesFlight> CategoriesFlights { get; } = new List<CategoriesFlight>();
}
