using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace @interface
{
    /*// интерфейс - похож на объявление класса
    // хранит только сигнатуры свойств, методов или событий
    // класс который наследует интерфейс будет определять все свойства методов и свойств (типа абстрактный класс)

    *//*interface IA
    {
        void fa();

        void Print();
    }

    interface IC
    {
        void fc();

        void Print();
    }

    class MyClass : IA, IC
    {
        public void fa()
        {
            WriteLine($"IA = fa");
        }

        public void fc()
        {
            WriteLine($"IC = fc");
        }

        void IA.Print()
        {
            WriteLine($"IA - print");
        }

        void IC.Print()
        {
            WriteLine($"IC - print");
        }

        public void Print()
        {
            WriteLine($"MyClass - print");
        }*//*
   
    internal class Program
    {
       *//* static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.Print();

            // явное приведение объекта к типу интерфейса
            ((IA)obj).Print();

            // создание объекта
            IC ic = new MyClass();
            ic.Print();

        }*//*
    }*/

    // 3
    /*interface IA
    {
        string A1(int n);
    }

    interface IB
    {
        int B1(int n);

        void B2();
    }

    interface IC : IA, IB
    {
        void C1(int n);
    }

    class MyClass : IC
    {
        public string A1(int n)
        {
            throw new NotImplementedException();
        }

        public int B1(int n)
        {
            throw new NotImplementedException();
        }

        public void B2()
        {
            throw new NotImplementedException();
        }

        public void C1(int n)
        {
            throw new NotImplementedException();
        }
    }*/

    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: { Series} { Number} ";
        }
    }

    class Student : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }

        public int CompareTo(object obj)
        {
            if(obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {BirthDate.ToShortDateString()} {StudentCard}";
        }
    }

    // IEnumerable - статический интерфейс 
    class Auditory :IEnumerable
    {
        Student[] students =
        {
        new Student {
        FirstName ="John",
        LastName ="Miller",
        BirthDate =new DateTime(1997,3,12),
        StudentCard =new StudentCard { Number=189356, Series="AB" }
        },
        new Student {
        FirstName ="Candice",
        LastName ="Leman",
        BirthDate =new DateTime(1998,7,22),
        StudentCard = new StudentCard { Number=345185, Series="XA" }
        },
        new Student {
        FirstName ="Joey",
        LastName ="Finch",
        BirthDate = new DateTime(1996,11,30),
        StudentCard = new StudentCard { Number=258322,Series="AA" }
        },
        new Student {
        FirstName ="Nicole",
        LastName ="Taylor",
        BirthDate = new DateTime(1996,5,10),
        StudentCard = new StudentCard { Number=513484, Series="AA" }
        }
        };

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public void Sort() // CompareTo
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comp) 
        {
            Array.Sort(students, comp);
        }


    }

    class Class_FN : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return Compare((x as Student).FirstName, (y as Student).FirstName);
            }
            throw new NotImplementedException();
        }
    }

    class Class_BD : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
            }
            throw new NotImplementedException();
        }      
    }

    
    internal class Program_3 
    {
        static void Main(string[] args)
        {
            // АНАЛИЗ СТАНДАРТНЫХ ИНТЕРФЕЙСОВ
            Auditory aud = new Auditory();
            WriteLine($"Список  студентов");
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("****************************");
            aud.Sort();
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("*************************** SORT First Name **************************");
            aud.Sort(new Class_FN());
            foreach (Student item in aud)
            {
                WriteLine(item);
            }

            WriteLine("*************************** SORT birthday **************************");
            aud.Sort(new Class_BD());
            foreach (Student item in aud)
            {
                WriteLine(item);
            }
        }
    
    }


}


// 2

/*using System;
using System.Collections.Generic;
using static System.Console;
namespace SimpleProject
{
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"\nФамилия: {LastName} Имя: {FirstName} Дата рождения: {BirthDate.ToLongDateString()}";
        }
    }
    abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nДолжность: {Position} Заработная плата: {Salary} $";
        }
    }
    interface IWorker
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorker> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager
    {
        public List<IWorker> ListOfWorkers { get; set; }
        public void Control()
        {
            WriteLine("Контролирую работу!");
        }
        public void MakeBudget()
        {
            WriteLine("Формирую бюджет!");
        }
        public void Organize()
        {
            WriteLine("Организую работу!");
        }
    }
    class Seller : Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Продаю товар!";
        }
    }
    class Cashier : Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Принимаю оплату за товар!";
        }
    }
    class Storekeeper : Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Учитываю товар!";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director { LastName = "Doe", FirstName = "John", BirthDate = new DateTime(1998, 10, 12), Position = "Директор", Salary = 12000 };
            IWorker seller = new Seller { LastName = "Beam", FirstName = "Jim", BirthDate = new DateTime(1956, 5, 23), Position = "Продавец", Salary = 3780 };
            if (seller is Employee)
                WriteLine($"Заработная плата продавца: {(seller as Employee).Salary}");
            // приведение интерфейсной ссылки  к классу Employee
            director.ListOfWorkers = new List<IWorker>
{
    seller, new Cashier { LastName = "Smith", FirstName = "Nicole", BirthDate = new DateTime(1956, 5, 23), Position = "Кассир", Salary = 3780 },
    new Storekeeper { LastName = "Ross", FirstName = "Bob", BirthDate = new DateTime(1956, 5, 23), Position = "Кладовщик", Salary = 4500 }
};
            WriteLine(director);
            if (director is IManager)
            {
                director.Control();
            }
            foreach (IWorker item in director.ListOfWorkers)
            {
                WriteLine(item);
                if (item.IsWorking)
                {
                    WriteLine(item.Work());
                }
            }
        }
    }
}*/