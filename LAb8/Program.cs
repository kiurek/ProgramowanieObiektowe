using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8
{
    record Student(int Id, string Name, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 4, 6, 7, 3, 2, 8, 9 };
            IEnumerable<int> evenNumbers =
                from n in ints
                where !(n % 2 == 0) && n > 5
                select n;
            Console.WriteLine(string.Join(", ", evenNumbers));
            //
            Predicate<int> intPredicate = n =>
            {
                Console.WriteLine("Wywoływanie predykatu dla " + n);
                return n % 2 == 0;
            };

            evenNumbers =
                from n in ints
                where intPredicate.Invoke(n)
                select n;
            evenNumbers =
                from n in evenNumbers
                where n > 5
                select n;
            Console.WriteLine("Wywoływanie ewaluacji wyrażenia LINQ");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine(evenNumbers.Sum());
            //Średnia
            evenNumbers =
                from n in ints
                where intPredicate.Invoke(n)
                select n;

            Console.WriteLine(evenNumbers.Average());
            //Ile jest liczb w evenNumber
            Console.WriteLine(evenNumbers.Count());
            //Jaka jest największa liczba
            Console.WriteLine(evenNumbers.Max());
            //Jaka jest najmniejsza liczba
            Console.WriteLine(evenNumbers.Min());

            Student[] students =
            {
                new Student(1, "Ewa", 67),
                new Student(2, "Karol", 67),
                new Student(3, "Ewa", 63),
                new Student(4, "Ania", 67),
                new Student(5, "Karol", 37)
            };

            Console.WriteLine("-----------------------------");
            IEnumerable<string> enumerable =
                from s in students
                orderby s.Ects
                orderby s.Name descending
                select s.Name + " " + s.Ects;
            Console.WriteLine(string.Join("\n ", enumerable));
            //wyswietl liczby z ints w kolejnosci malejacej
            Console.WriteLine(string.Join(", ",
                    from i in ints
                    orderby i descending
                    select i
                ));
            Console.WriteLine(string.Join(", ", ints.OrderByDescending(i => i)));
            //Za pomoca fluent API wyświetlić posortowaną liste studentów wg 
            Console.WriteLine(string.Join(", ", students.OrderBy(s => s.Name).ThenBy(s => s.Ects)));

            //Grupowanie
            Console.Write("---------GRUPOWANIE-------");
            IEnumerable<IGrouping<string, Student>> studentNameGroup =
                from s in students
                group s by s.Name;
            foreach (var item in studentNameGroup)
            {
                Console.WriteLine(item.Key + " " + string.Join(", ", item));
            }
            IEnumerable<(string Key, int)> NameCounters = from s in students
                                                          group s by s.Name into groupItem
                                                          select (groupItem.Key, groupItem.Count());
            Console.WriteLine(string.Join(", ", NameCounters));

            string str = "Ala ma kota ala lubi koty karol lubi psy";
            //oblicz ile razy występuje każde słowo w łańcuchu str
            IEnumerable<(string Key, int)> texts =
                from w in str.Split(" ")
                group str by w into groupItem
                select (groupItem.Key, groupItem.Count());
            Console.WriteLine(string.Join(", ", texts));
            Console.WriteLine();

            evenNumbers = ints.Where(i => i % 2 == 0).Select(i => i + 2);
            (int Id, string Name) p =
            students
                .Where(s => s.Ects > 20)
                .OrderBy(s => s.Id)
                .Select(s => (s.Id, s.Name))
                .FirstOrDefault(s => s.Name.StartsWith("Ż"));
            Console.WriteLine(p);

            int[] powerInts =
            Enumerable
                .Range(0, ints.Length)
                .Select(i => ints[i] * ints[i])
                .ToArray();
            Console.WriteLine(string.Join(", ", powerInts));

            Random random = new Random();
            random.Next(5); //zwraca losowa liczbe od 0 do 4
            //Wygeneruj tablice 100 licb losowych od 0 do 9
            Enumerable
                    .Range(0, 101)
                    .Select(i => random.Next(9)).
                    ToList().
                    ForEach(s => Console.Write(", " + s));

            Console.WriteLine();
            Console.WriteLine("-------------------------");
            int page = 0;
            int size = 3;
            List<Student> pageStudent = students.Skip(page * size).Take(size).ToList();
            Console.WriteLine(string.Join(", ", pageStudent));
        }
    }
}
