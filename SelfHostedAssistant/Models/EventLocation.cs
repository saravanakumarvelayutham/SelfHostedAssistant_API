using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfHostedAssistant.Models
{
    public class EventLocation
    {
        public double? latitude { get; set; }

        public double? longitude { get; set; }

        public string address { get; set; }
    }
}
