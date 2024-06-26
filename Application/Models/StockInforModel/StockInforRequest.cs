﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.StockInforModel
{
    public class StockInforRequest
    {
        public string? Symbol { get; set; }
        public string? Description { get; set; }
        public ICollection<StockDataDto>? StockDataDtos { get; set; }
    }
}
