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
        public static Dictionary<String,String[]> Parse(string[] args)
        {
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
                    String[] FileNames= { };

                    if (firstSwitchPos > -1)
                    {
                        FileNames = new ArraySegment<String>(args, 0, firstSwitchPos).ToArray();
                    }
                    else FileNames = args;

                     
                    if (!Regex.IsMatch(String.Join(String.Empty,FileNames),"/.cfg"))
                        {
                        paramsDictionary.TryAdd("FileNames", FileNames);

                    }
                }                    
            }
            return paramsDictionary;

             static bool isSwitch(string arg)
            {
                return Regex.IsMatch(arg, @"^-(?=\D)(?=\S)\w+");
            }
        }
    }
}
