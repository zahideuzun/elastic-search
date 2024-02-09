﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs
{
    public record ProductUpdateDto(string Id, string Name, decimal Price, int Stock, ProductFeatureDto Feature)
    {

    }
}
