using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7
{
    class SleighKit
    {
        private string InputPath { get; set; }

        public SleighKit(string path) => InputPath = path;

        private Regex lineRegex = new Regex(@"(?>[A-z]{4}) ([A-Z]{1})");


        /// <summary>
        /// Get the steps in the line 
        /// </summary>
        /// <param name="line">Line from the file</param>
        /// <returns>returns a tuple with the step that is required before the next one can be completed a.k.a(required,next) </returns>
        private (string, string) Translate(string line)
        {
            MatchCollection match = lineRegex.Matches(line);
            if (match[0].Success&& match[1].Success)
            {
                return (match[0].Groups[1].Value, match[1].Groups[1].Value);
            }
            return (null,null);
        }

        /// <summary>
        /// Read file
        /// </summary>
        /// <returns>Returns IEnumerable that iterates over all lines in the file</returns>
        public IEnumerable<(string, string)> ReadManual()
        {
            string line;
            using (System.IO.StreamReader file = new System.IO.StreamReader($@"..\..\Input\{InputPath}"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    yield return Translate(line);
                }
            }
        }
    }

}

