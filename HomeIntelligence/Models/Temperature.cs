using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeIntelligence.Models
{
    public class Temperature
    {
        public int ID { get; set; }
        public DateTime DateRecieved { get; set; }
        public double Value { get; set; }
        public Guid? Location { get; set; }
    }
}
