using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace Sortare_localizata
{

    class Person : IEquatable<Person>, IComparable<Person>
    {
        public List<string> firstNames { get; set; }
        public string lastName { get; set; }

        public Person()
        {
            firstNames = new List<string>();
        }

        public string formatName(string name)
        {
            char[] a = name.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = char.ToLower(a[i]);
            }
            return new string(a);
        }

        public void AddFirstName(string name)
        {
            string formattedName = formatName(name);
            firstNames.Add(formattedName);
        }

        public int CompareTo(Person p)
        {
            StringComparer comparer = StringComparer.Create(new CultureInfo("ro-RO"), true);
            int orderLastName = comparer.Compare(lastName, p.lastName);
            if (orderLastName != 0)
                return orderLastName;
            int length = Math.Min(firstNames.Count(), p.firstNames.Count());
            for (int i = 0; i < length; i++)
            {
                int orderFirstName = comparer.Compare(firstNames.ElementAt(i), p.firstNames.ElementAt(i));
                if (orderFirstName != 0)
                {
                    return orderFirstName;
                }
            }
            return 0;
        }

        public override string ToString()
        {
            string firstName = "";
            foreach (string fn in firstNames)
            {
                firstName += fn + ' ';
            }
            return lastName + ' ' + firstName;
        }

        public bool Equals(Person other)
        {
            bool lastnameEqual = lastName.Equals(other.lastName);
            bool firstnameEgual = firstNames.Equals(other.firstNames);
            return lastnameEqual && firstnameEgual;
        }
    }
}