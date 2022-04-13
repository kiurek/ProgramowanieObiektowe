using System;
using System.Collections.Generic;

namespace lab6
{
	class Student
	{ 
		public string Name { get; set; }
		public int ECTS { get; set; }

		public int CompareTo(Student other)
        {
			if (Name.CompareTo(Student other) == 0)
            {
				return ECTS.CompareTo()
            }
			return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
			Console.WriteLine("Student Equals");
			return obj is Student student &&
				Name == student.Name &&
				ECTS == student.ECTS;
        }

        public override int GetHashCode()
        {
			Console.WriteLine("Student HashCode");
			return HashCode.Combine(Name, Ects);
        }

		public override str
    }
foreach (string name in names)
{
	Console.WriteLine(name);
}
Console.WriteLine(names.Contains("Adam"));

ICollection<Student> students = new List<Student>();
students.Add(new Student() { Name = "Ewa", ECTS = 12 });
students.Add(new Student() { Name = "Karol", ECTS = 11 });
students.Add(new Student() { Name = "Adam", ECTS = 17 });
students.Remove(new Student() { Name = "Adam", ECTS = 17 });
foreach (Student name in students)
{
	Console.WriteLine(name.Name + " " + name.Ects);
}
Console.WriteLine(students.Contains(new Student() { Name = "Adam", ECTS = 17 }));
List<Student> list = (List<Student>)students;
Console.WriteLine(list[0]);
list.Insert(1, new Student() { Name = "Robert", ECTS = 45 });
foreach (Student name in students)
{
	Console.WriteLine(name.Name + " " + name.Ects);
}
int index = list.IndexOf(new Student() { Name = "Karol", ECTS = 11 });
Console.WriteLine("Karol ma pozycję " + index);
list.RemoveAt(0);

Console.WriteLine("-------------------------------SET--------------------------------------");

ISet<string> set = new HashSet<string>();
set.Add("Ewa");
set.Add("Karol");
set.Add("Adam");
set.Add("Adam");
set.Add("Zofia");
foreach (string name in set)
{
	Console.WriteLine(name);
}

ISet<Student> studentGroup = new HashSet<Student>();
set.Add(new Student() { Name = "Ewa", ECTS = 12 });
set.Add(new Student() { Name = "Karol", ECTS = 11 });
set.Add(new Student() { Name = "Adam", ECTS = 17 });
set.Remove(new Student() { Name = "Adam", ECTS = 17 });
foreach (Student name in students)
{
	Console.WriteLine(name.Name + " " + name.Ects);
}
studentGroup.Contains(new Student() { Name = "Adam", ECTS = 17 });
//ABC = 1 + 2 + 3 = 6
//BB = 6
//studentGroup.Remove(new Student() {Name = "Karol", ECTS = 11});
studentGroup = new SortedSet<Student>(studentGroup);
studentGroup.Add(new Student() { Name = "Ewa", ECTS = 3 });
foreach (Student name in studentGroup)
{
	Console.WriteLine(name.Name + " " + name.ECTS);
}
Console.WriteLine(studentGroup.Contains(new Student() { Name = "Adam", ECTS = 17 }));

Dictionary<Student, string> phoneBook = new Dictionary<Student, string>();
phoneBook[list[0]] = "123456789";
phoneBook[list[1]] = "155346789";
phoneBook[list[2]] = "125256789";
Console.WriteLine(phoneBook.Keys);
if (phoneBook.ContainsKey(new Student() { Name = "Ewa", ECTS = 12 }))
{
	Console.WriteLine("Jest telefon");
} else
{
	Console.WriteLine("Brak telefonu");
}

foreach(var item in phoneBook)
{
	Console.WriteLine(item.Key + " " + item.Value);
}
string[] arr = { "Adam", "Ewa", "Karol", "Ewa", "Ania", "Karol", "Adam", "Adam", "Ewa" };
//oblicz ile razy występuje każde z imion w tablicy arr
Dictionary<string, int> counters = new Dictionary<string, int>();
foreach (string name in arr)
{
	if (counters.ContainsKey(name))
    {
		counters[name] += 1;
    } else
    {
		counters.Add(name, 1);
    }
}
foreach(var item in counters)
{
	Console.WriteLine(item.Key + " występuje " + item.Value);
}
		}
	}
}