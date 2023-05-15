using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVEnvironmentVariableEasy
{
    internal class Config
    {
        List<string> directories;
        List<string> commands;
        public Config(string filename)
        {
            directories = new List<string>();
            commands = new List<string>();

            StreamReader streamReader = new StreamReader(filename);
            string line;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                if (line.Length > 0 && line.StartsWith("#")) continue;
                if (line.Length > 0 && line.StartsWith("!"))
                {
                    commands.Add(line.Substring(1));
                    continue;
                }
                directories.Add(line.Replace("/","\\").Replace(".\\","\\").Replace("\n",""));
            }
        }

        public List<string> GetDirectories()
        {
            return directories;
        }
        public List<string> GetCommands()
        {
            return commands;
        }
    }
}
