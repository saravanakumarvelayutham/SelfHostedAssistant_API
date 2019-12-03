using System;
namespace SelfHostedAssistant.Models
{
    public class AssistantDatabaseSettings : IAssistantDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string MAP_API_KEY { get; set; }
    }

    public interface IAssistantDatabaseSettings
    {
        string ConnectionString { get; set; }

        string MAP_API_KEY { get; set; }
    }
}
