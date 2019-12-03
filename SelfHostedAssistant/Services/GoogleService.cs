using Google.Maps;
using Google.Maps.DistanceMatrix;
using SelfHostedAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfHostedAssistant.Services
{
    public class GoogleService : IGoogleService
    {
        public GoogleService(IAssistantDatabaseSettings settings)
        {
            var apiKey = Environment.GetEnvironmentVariable("MAP_API_KEY");
            Console.WriteLine(apiKey);
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = settings.MAP_API_KEY;
            }
            GoogleSigned.AssignAllServices(new GoogleSigned(apiKey));

        }

        public double? GetTravelTime(double lat, double lon)
        {
            if(!Models.Location.Latitude.HasValue || !Models.Location.Longitude.HasValue)
            {
                return null;
            }
            DistanceMatrixRequest request = new DistanceMatrixRequest()
            {
                WaypointsOrigin = new List<Google.Maps.Location> { new LatLng((decimal)Models.Location.Latitude, (decimal)Models.Location.Longitude) },
                WaypointsDestination = new List<Google.Maps.Location> { new LatLng((decimal)lat, (decimal)lon) }
            };
            var response = new DistanceMatrixService().GetResponse(request);
            var durationInMins = Math.Round((decimal)response.Rows.FirstOrDefault()?.Elements?.FirstOrDefault()?.duration?.Value / 60, 2);
            return (double)durationInMins;
        }
    }
}
