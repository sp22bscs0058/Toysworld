using System;
using System.Collections.Generic;

namespace Toysworld.Models;

public partial class Toy
{
    public int Id { get; set; }

    public string? ToyName { get; set; }

    public string? TypeOfToy { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }
}
