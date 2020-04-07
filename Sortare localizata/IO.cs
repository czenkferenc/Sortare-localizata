using System;
using System.Collections.Generic;
using System.IO;


namespace Sortare_localizata
{
    internal class IO
    {
        internal static List<string> fileReader(string path)
        {
            List<string> fileLines = new List<string>();
            string line;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {

                    while (true)
                    {
                        line = sr.ReadLine();
                        if (line == null) break;
                        fileLines.Add(line);
                        //Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return fileLines;
        }

        internal static void fileWriter(List<Person> persons,string path)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach (Person pers in persons)
                {
                    sw.WriteLine(pers.ToString());
                }
            }
        }
    }
}