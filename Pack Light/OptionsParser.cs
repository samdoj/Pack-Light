using Newtonsoft.Json;
using System;
using System.Collections;
//using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Pack_Light
{
    public class OptionsParser
    {
        public static Dictionary<String, String[]> Parse(string[] args)
        {
            if (args.Length == 0) return getConfigFromFile("plcfg.json");
            if (args.Length==1 && !Regex.IsMatch(args[0], @"plcfg\.json"))
            {
                try
                {
                    Dictionary<String, String[]> dict;
                    dict = getConfigFromFile("plcfg.json");
                    if (!dict.ContainsKey("FileNames"))
                    {
                        dict.Add("FileNames", new string[] { args[0] });
                    }
                    else 
                    {
                       string[] fnames = new string[dict["FileNames"].Length+1];
                        fnames[fnames.Length-1] = args[0];
                        dict["FileNames"] = fnames;
                     }
                    return dict;
                }
                catch (Exception)
                {
                    return getConfigFromFile(args[0]);
                }
            }
            int i = 0;
            int firstSwitchPos = -1;
            Dictionary<String, String[]> paramsDictionary = new Dictionary<String, String[]>();
            for (i = 0; i < args.Length; i++)
            {
                String arg = args[i];
                if (isSwitch(arg))
                {
                    firstSwitchPos = firstSwitchPos == -1 ? i : firstSwitchPos;

                    i++;
                    ArrayList paramsList = new ArrayList();
                    while (i < args.Length && !isSwitch(args[i]))
                    {
                        paramsList.Add(args[i]);
                        i++;
                    }
                    paramsDictionary.Add(arg, (string[])paramsList.ToArray(type: typeof(String)));
                    i--;
                }
            }
            if (firstSwitchPos != 0)
            {
                {
                    String[] FileNames = { };

                    if (firstSwitchPos > -1)
                    {
                        FileNames = new ArraySegment<String>(args, 0, firstSwitchPos).ToArray();
                    }
                    else FileNames = args;


                    if (!Regex.IsMatch(String.Join(String.Empty, FileNames), @"plcfg\.json"))
                    {
                        paramsDictionary.TryAdd("FileNames", FileNames);

                    }
                    else
                    {
                        if (FileNames.Length == 1 && !Regex.IsMatch(String.Join(String.Empty, FileNames), @"plcfg\.json"))
                        {
                            paramsDictionary.TryAdd("ConfigFileName", FileNames);
                        }
                        else
                        {
                            
                            string joinedParamsBeforeSwitches = String.Join(' ', FileNames);
                            string cfgFileName = Regex.Match(joinedParamsBeforeSwitches, pattern: @".*?plcfg\.json").Value;
                            string[] otherFiles = joinedParamsBeforeSwitches.Replace(cfgFileName, String.Empty).Split(' ');
                            paramsDictionary.TryAdd("ConfigFileName", new string[] { cfgFileName });
                            if (otherFiles[0] == String.Empty)
                            {
                                paramsDictionary = getConfigFromFile(cfgFileName);
                                if (paramsDictionary.Count == 0)
                                    throw new Exception("You need to provide a filename either through the command line or" +
                                        $" through {cfgFileName}");
                            }
                            paramsDictionary.TryAdd("FileName", otherFiles);

                        }
                    }
                }
            }
            return paramsDictionary;

            static bool isSwitch(string arg)
            {
                return Regex.IsMatch(arg, @"^-(?=\D)(?=\S)\w+");
            }
        }

        static Dictionary<String, string[]> getConfigFromFile(string cfgName)
        {
            bool fileExists = System.IO.File.Exists(cfgName);
            if (!fileExists) throw new Exception("Config file doesn't exist." +
                "  Please make sure it exists and is in the current directory" +
                " or is included in the PATH environment variable.");
            var data = System.IO.File.OpenRead(cfgName);
            Byte[] bytes = new Byte[data.Length];
            data.Read(bytes);
            data.Flush();
            string dataRead = Encoding.UTF8.GetString(bytes);
            if (dataRead == String.Empty) throw new Exception("Config file contains no configurations.");
            Dictionary<string, string[]> optionsReader
                = JsonConvert.DeserializeObject<Dictionary<String, string[]>>(dataRead);
            
            optionsReader.TryAdd("ConfigFileName", new string[] { cfgName });
            return optionsReader;
        }
    }
}
