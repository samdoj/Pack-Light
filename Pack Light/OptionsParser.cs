using System;
using System.Collections;
//using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Pack_Light
{
    class OptionsParser
    {
        public static Dictionary<String,String[]> Parse(string[] args)
        {
            int i = 0;
            Dictionary<String, String[]> paramsDictionary = new Dictionary<String, String[]>(); 
           for (i = 0; i < args.Length; i++)
            {
                String arg = args[i];
                if (isSwitch(arg))
                {
                    i++;
                    ArrayList paramsList = new ArrayList();
                     while (i < args.Length && !isSwitch(args[i]))
                    {
                        paramsList.Add(args[i]);
                        i++;
                    }
                    paramsDictionary.Add(arg, (string[])paramsList.ToArray(type: typeof(String)));
                    i--;
                    Console.WriteLine($"switch: {arg} \t Parameters: {String.Join(' ',paramsDictionary.GetValueOrDefault(arg))}");   
                }
            }
            return null;

             static bool isSwitch(string arg)
            {
                return Regex.IsMatch(arg, @"^-(?=\D)(?=\S)\w+");
            }
        }
    }
}
