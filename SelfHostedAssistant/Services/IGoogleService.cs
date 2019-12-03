namespace SelfHostedAssistant.Services
{
    public interface IGoogleService
    {
        double? GetTravelTime(double lat, double lon);
    }
}