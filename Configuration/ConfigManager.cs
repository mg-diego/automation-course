using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationFramework.Configuration
{
    public class ConfigManager
    {

        public Config getConfig(string configPath)
        {
            string jsonString = File.ReadAllText(configPath);

            Config config = JsonSerializer.Deserialize<Config>(jsonString);

            return config;
        }
    }
}
