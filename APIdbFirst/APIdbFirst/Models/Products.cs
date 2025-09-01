using System;
using System.Collections.Generic;

namespace APIdbFirst.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
