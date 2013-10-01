using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SacredUnderworldHelper
{
    class Configuration
    {
        string configFile;
        Dictionary<string, string> pairs;

        public string this[string setting]
        {
            get { return pairs.ContainsKey(setting) ? pairs[setting] : string.Empty; }
            set
            {
                if (!pairs.ContainsKey(setting))
                    pairs.Add(setting, value);
                else
                    pairs[setting] = value;
            }
        }

        public string ConfigFile
        {
            get { return configFile; }
        }

        public Configuration(string configFile)
        {            
            this.configFile = configFile;
            pairs = new Dictionary<string, string>();
            if(File.Exists(configFile))
                ParseConfigFile();
        }

        void ParseConfigFile()
        {
            string[] content = File.ReadAllLines(configFile);
            char[] delimiter = {'='};

            foreach (string line in content)
            {
                if (!line.Trim().StartsWith("#"))
                {
                    string[] pair = line.Split(delimiter, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (pair.Length == 2)
                    {
                        string key = pair[0].Trim();
                        if (!pairs.ContainsKey(key))
                            pairs.Add(key, pair[1].Trim());
                    }
                }
            }
        }

        public void Save(string configFile)
        {
            using (FileStream fs = new FileStream(configFile, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (string setting in pairs.Keys)
                    {
                        sw.WriteLine("{0} = {1}", setting, pairs[setting]);
                    }

                    sw.Close();
                }
            }

            this.configFile = configFile;
        }

        public void Save()
        {
            Save(configFile);
        }
    }
}
