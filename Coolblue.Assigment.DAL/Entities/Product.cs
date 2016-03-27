using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolblue.Assigment.DAL.Entities
{
    public class Product
    {
        [BsonId]
        public string ProductId { get; set; }
        [BsonRequired]
        public string Title { get; set; }
        [BsonRequired]
        public double UnitPrice { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime LastModified { get; set; }
    }
}
