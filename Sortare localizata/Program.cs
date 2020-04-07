using System;
using System.Collections.Generic;
using System.Linq;

namespace Sortare_localizata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = IO.fileReader("../../input.txt");
            List<Person> persons = new List<Person>();
            Console.WriteLine("Original, formated list:");
            foreach (string line in lines)
            {
                Person p = lineToPerson(line);
                persons.Add(p);
                Console.WriteLine(p.ToString());

            }
            Console.WriteLine();

            Console.WriteLine("Sorted List:");
            persons.Sort();

            for (int i = 0; i < persons.Count(); i++)
            {
                Console.WriteLine(persons.ElementAt(i).ToString());
            }
            IO.fileWriter(persons, "../../output.txt");
            Console.WriteLine();
        }

        public static Person lineToPerson(string line)
        {
            char[] sep = { ' ', ';', ',', '.', ':', '!', '?', '\t', '|'};
            string[] Lines = line.Split(sep);
            List<string> Names = new List<string>();

            foreach (string name in Lines)
            {
                if (!name.Equals(""))
                {
                    Names.Add(name);
                }
            }

            int NamesCount = Names.Count();
            Person p = new Person();
            p.lastName = p.formatName(Lines[0]);

            for (int i = 1; i < NamesCount; i++)
            {
                p.AddFirstName(Names.ElementAt(i));
            }
            return p;
        }
    }
}
