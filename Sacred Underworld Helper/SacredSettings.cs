using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sacred_Underworld_Helper
{
    class SacredSettings
    {
		Dictionary<string, string> pairs;
		string configFile;

		public ICollection<string> Settings
		{
			get { return pairs.Keys; }
		}

		public string this[string setting]
		{
			get
			{
				return pairs.ContainsKey(setting) ? pairs[setting] : string.Empty;
			}
			set
			{
				if (pairs.ContainsKey(setting))
					pairs[setting] = value;
			}
		}

		public string ConfigFile
		{
			get { return configFile; }
		}

		public SacredSettings(string configFile)
		{
			this.configFile = configFile;
			pairs = new Dictionary<string, string>();
			string[] content = File.ReadAllLines(configFile);
			char[] delimiter = {':'};

			foreach(string line in content)
			{
				string[] pair = line.Split(delimiter, 2, StringSplitOptions.RemoveEmptyEntries);

				if (pair.Length == 2)
				{
					string key = pair[0].Trim();
					string value = pair[1].Trim();

					if(!pairs.ContainsKey(key))
						pairs.Add(key, value);
				}
			}
		}

		public void Save(string fileName)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					foreach (string setting in Settings)
						sw.WriteLine("{0} : {1}", setting, pairs[setting]);
					
					sw.Close();
				}
			}
			this.configFile = fileName;
		}

		public void Save()
		{
			Save(configFile);
		}
	}
}
