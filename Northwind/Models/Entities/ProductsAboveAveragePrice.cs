﻿using System;
using System.Collections.Generic;

namespace Northwind.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }
}
