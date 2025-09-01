using System;
using System.Collections.Generic;

namespace APIdbFirst.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Products> Product1s { get; set; } = new List<Products>();
}
