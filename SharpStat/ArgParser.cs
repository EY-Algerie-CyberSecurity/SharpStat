using System;
using System.Collections.Generic;

namespace SharpStat
{
    class ArgParser
    {
        public static Dictionary<string, string> Parse(string[] args)
        {
            Dictionary<string, string> returnVal = new Dictionary<string, string>();
            // set defaults
            returnVal["dc"] = Environment.GetEnvironmentVariable("USERDNSDOMAIN");
            returnVal["domain"] = Environment.GetEnvironmentVariable("USERDOMAIN");
            returnVal["computers"] = "";
            returnVal["file"] = "";
            returnVal["output"] = "";
            returnVal["verbose"] = null;
            string currentKey = "";
            foreach (string str in args)
            {
                if (str.Substring(0, 1) == "-")
                {
                    currentKey = str.Substring(1);
                    bool expectedKey = false;
                    foreach (string exp in returnVal.Keys)
                    {
                        if (string.Equals(currentKey, exp, StringComparison.OrdinalIgnoreCase))
                        {
                            expectedKey = true;
                            break;
                        }
                    }
                    if (!expectedKey)
                    {
                        ArgParser.Usage();
                    }
                    else
                    {
                        returnVal[currentKey] = "";
                    }
                }
                else
                {
                    returnVal[currentKey] = str;
                }
            }
            return returnVal;
        }

        public static void Usage()
        {
            Console.WriteLine(" Usage:  .\\SharpStat.exe -computers \"ip,ip2,ip3\" -file \"C:\\Users\\Public\\crashlog.txt\" -output \"C:\\Users\\Public\\result\"[-domain <domain_name>] [-dc <domain_controller>]");
            Console.WriteLine();
            Console.WriteLine("     This script will attempt to connect to all the supplied computers");
            Console.WriteLine("     and use WMI to execute 'cmd.exe /c netstat -n > <file>'");
            Console.WriteLine("     The file the output is saved to is specified by '-file'. Once the");
            Console.WriteLine("     netstat command is running, the output is read via remote SMB call");
            Console.WriteLine("     and then deleted.");
            Console.WriteLine("     The script will save the result on an output file in two format (.txt");
            Console.WriteLine("     and .csv), you have to indicate juste the name of the file");
            Console.WriteLine();
            Console.WriteLine("     While this isn't the stealthiest of scripts (because of the cmd.exe ");
            Console.WriteLine("     execution and saving to a file), sometimes you gotta do what you gotta");
            Console.WriteLine("     do. An alternative would be to use WMI to remotely query netstat information,");
            Console.WriteLine("     but that WMI class is only available on Win10+ systems, which isn't ideal.");
            Console.WriteLine();
            Console.WriteLine("     Mandatory Options:");
            Console.WriteLine("         -file         = This is the file that the output will be saved in temporarily before being remotely read/deleted");
            Console.WriteLine("         -output       = This is the file that the output will be saved and returned to you");
            Console.WriteLine();
            Console.WriteLine("     Optional Options:");
            Console.WriteLine("         -computers    = A list of systems to run this against, separated by commas");
            Console.WriteLine("            [or]");
            Console.WriteLine("         -dc           = A domain controller to get a list of domain computers from");
            Console.WriteLine("         -domain       = The domain to get a list of domain computers from");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Examples:");
            Console.WriteLine("         SharpStat.exe -file \"C:\\Users\\Public\\test.txt\" -computers 127.0.0.1 -output \"C:\\Users\\Public\\result\"");
            Console.WriteLine("         SharpStat.exe -file \"C:\\Users\\Public\\test.txt\" -domain lab.raikia.com -dc lab.raikia.com");
            Console.WriteLine("         SharpStat.exe -file \"C:\\Users\\Public\\test.txt\" -computers \"wkstn7.lab.raikia.com,wkstn10.lab.raikia.com\"");
            Console.WriteLine();
            Environment.Exit(1);
        }
    }
}
