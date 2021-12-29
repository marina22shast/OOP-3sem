using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Наследование, полиморфизм, абстрактные классы и интерфейсы
namespace lab5
{

    interface Iq
    {
        void Sum();
    }

    interface Iq2
    {
        void Sum2();
    }

    //нельзя использовать конструкторы абстрактного класса для создания объекта
    public abstract class Person
    {
        public string name;
        public string surname;
        static int count = 0;
        public Person()
        {
            count++;
        }



        public virtual void Inf() //Методы и свойства которые мы хотим переопределить помечаются ключевым словом virtual.
        {
            Console.WriteLine("Имя ");
            Console.WriteLine("Фамилия ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

    }

    public class working : Person, Iq
    {
        public int numbers;
        static int count = 0;

        public working()
        {
            count++;
        }


        public void Sum()
        {
            Console.WriteLine("Количество персон работающих: " + count);
            Console.WriteLine(" ");
        }
    }
    public class Teaching : Person, Iq2
    {
        public int numbers;
        static int count2 = 0;

        public Teaching()
        {
            count2++;
        }


        public void Sum2()
        {
            Console.WriteLine("Количество персон обучающихся: " + count2);
            Console.WriteLine(" ");
        }
    }
    class Programmerr : working
    {
        public int year;

        public Programmerr(string name, string surname, int numbers, int year)
        {
            this.name = name;
            this.surname = surname;
            this.numbers = numbers;
            this.year = year;
        }

        public override void Inf() //
        {
            Console.WriteLine("Программист: ");
            Console.WriteLine("Имя " + name);
            Console.WriteLine("Фамилия " + surname);
            Console.WriteLine("Возраст " + numbers);
            Console.WriteLine("Сколько лет проработал " + year);
            Console.WriteLine(" ");
            Console.WriteLine(" ");


        }

    }

    class Studentt : Teaching
    {
        public int year;
        public Studentt(string name, string surname, int numbers, int year)
        {
            this.name = name;
            this.surname = surname;
            this.numbers = numbers;
            this.year = year;
        }

        public override void Inf()
        {
            Console.WriteLine("Токарь: ");
            Console.WriteLine("Имя " + name);
            Console.WriteLine("Фамилия " + surname);
            Console.WriteLine("Возраст " + numbers);
            Console.WriteLine("Сколько лет работал " + year);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    }

    class Programmer : working
    {
        public int year;
        public Programmer(string name, string surname, int numbers, int year)
        {
            this.name = name;
            this.surname = surname;
            this.numbers = numbers;
            this.year = year;
        }

        public override void Inf()
        {
            Console.WriteLine("Студент: ");
            Console.WriteLine("Имя " + name);
            Console.WriteLine("Фамилия " + surname);
            Console.WriteLine("Возраст " + numbers);
            Console.WriteLine("Курс " + year);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

        }
    }

    class StudentZ : Teaching
    {
        public int year;

        public StudentZ(string name, string surname, int numbers, int year)
        {
            this.name = name;
            this.surname = surname;
            this.numbers = numbers;
            this.year = year;
        }

        public override void Inf()
        {
            Console.WriteLine("Студент-заочник: ");
            Console.WriteLine("Имя " + name);
            Console.WriteLine("Фамилия " + surname);
            Console.WriteLine("Возраст " + numbers);
            Console.WriteLine("Курс " + year);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Programmerr Tokar = new Programmerr("Александр", "Зайцев", 30, 10);
            Studentt Student = new Studentt("Виктория", "Азарко", 19, 2);
            Programmer Programmer = new Programmer("Никита", "Дрозд", 25, 7);
            StudentZ StudentZ = new StudentZ("Наталья", "Будчан", 20, 4);

            Console.WriteLine("Информация:");
            Console.WriteLine(" ");
            Tokar.Inf();
            Student.Inf();
            StudentZ.Inf();
            Programmer.Inf();
            working working = Tokar as working;
            if (working != null)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");

            working.Sum();
            StudentZ.Sum2();

        }
    }
}