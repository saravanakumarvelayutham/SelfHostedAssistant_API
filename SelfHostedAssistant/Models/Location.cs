using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfHostedAssistant.Models
{
    internal static class Location
    {
        internal static readonly object _locker = new object();
        internal static double Latitude { get; set; }
        internal static double Longitude { get; set; }
    }
}
