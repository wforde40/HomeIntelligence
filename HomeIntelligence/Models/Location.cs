using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace HomeIntelligence.Models
{
    public class Location
    {
        public SqlGuid Id { get; set; }
        public string Name { get; set; }
    }
}
