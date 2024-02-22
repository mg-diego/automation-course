
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationFramework.Configuration
{
    public class ConfigurationManager
    {

        public Config LoadConfiguration(string path)
        {

            string jsonString = File.ReadAllText(path);

            Config config = JsonSerializer.Deserialize<Config>(jsonString);
            return config;
            
        }
    }
    
}
