using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockInfor:BaseEntity
    {
        public string? Symbol { get; set; } 
        public string? Description { get; set; }
        public ICollection<StockData> StockDatas { get; set; }
    }
}
