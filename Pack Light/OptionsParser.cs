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
                 }
            }
           if (paramsDictionary.Count==0)
            {
               if (args.Length == 1) 
                {
                    paramsDictionary.TryAdd("FileNames",args);
                }
               else
                {
                    String argsJoined = String.Join(" ", args);
                    if (!Regex.IsMatch(argsJoined,"/.cfg"))
                        {
                        paramsDictionary.TryAdd("FileNames", args);

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
