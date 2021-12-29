using System;
using System.Collections.Generic;
namespace Эксперимент
{
    /*Класс - стек Stack. Дополнительно перегрузить следующие
    операции: - - извлечение всех элементов равных заданному;
    ++ - дублирование верхнего элемента; < копирование
    неповторяющихся элементов из второго стека.
    Методы расширения:
    1) Подсчет количества восклицательных предложений в
    строке
    2) Проверка стека на наличие отрицательных элементов

    Перегрузка используется для создания универсальных методов,
    логика поведения которых одинакова, но типы данных или количество аргументов разное.
    */

    /*
    public: Такой член класса доступен из любого места в коде, а также из других программ и сборок.

    private: класса доступен только из кода в том же классе или контексте.

    protected: такой член класса доступен из любого места в текущем классе или в производных классах.
    При этом производные классы могут располагаться в других сборках.
    */
    public static class StatisticOperation
    {

        public static bool IsNegative(this FixedStack stack)
        {

            for (int i = 0; i < stack.Count; i++)
            {
                if (stack[i] < 0)
                {
                    return true;

                }
            }

            return false;

        }

        public static int Sentence(this FixedStack stack)
        {

            string checkString = stack.Stroke;
            int length = checkString.Length;
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (checkString[i] == '!')
                {
                    counter++;
                }
            }

            return counter;
        }




    }

    public class FixedStack
    {
        private int[] items;
        private int count;
        private string stroke;
        const int n = 10;

        public FixedStack()
        {
            items = new int[n];
            stroke = "Just useless string";
        }
        public FixedStack(int length, string stroke)
        {
            items = new int[length];
            this.stroke = stroke;
        }

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public string Stroke
        {

            get
            {
                return stroke;
            }
        }


        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Push(int item)
        {

            if (count == items.Length)
            {
                Console.WriteLine("Стек заполнен");
                return;
            }
            items[count++] = item;
        }
        // извлечение элемента
        public int Pop()
        {

            if (IsEmpty)
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            int item = items[--count];
            items[count] = 0;
            return item;
        }

        public int Peek()
        {

            if (IsEmpty)
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            return items[count - 1];
        }

        public int this[int index]
        {

            get
            {
                return items[index];
            }

        }

        public static FixedStack operator -(FixedStack stack)
        {
            int[] arr = new int[stack.items.Length];
            int length = stack.Count;
            int counter = 0;
            int lengthCounter = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < lengthCounter; j++)
                {
                    if (arr[j] != stack[i])
                    {
                        counter++;
                    }
                }
                if (counter == lengthCounter)
                {
                    arr[i] = stack[i];
                }
                counter = 0;
                lengthCounter++;
            }

            int counter2 = 0;
            for (int i = 0; i < stack.Count; i++)
            {
                if (arr[i] == 0)
                {
                    counter2++;

                }
            }

            stack.count = stack.count - counter2;
            stack.items = arr;

            return stack;
        }

        public static FixedStack operator ++(FixedStack stack)
        {
            stack.Push(stack.Peek());
            return stack;
        }

        public static bool operator >(FixedStack stack, FixedStack stack2)
        {
            if (stack.Count > stack2.Count)
            {
                return true;

            }
            return false;
        }
        public static bool operator <(FixedStack stack, FixedStack stack2)
        {
            if (stack.Count > stack2.Count)
            {
                return false;

            }
            return true;
        }

        public class Owner
        {

            private string name = "Alina";
            private int ID = 123;
            private string organization = "BSTU";

            public void Information()
            {
                Console.WriteLine("Информация о владельце " + name + " " + " " + ID + " " + organization);
            }
        }

        public class Data
        {

            private string year;
            private string month;
            private string day;

            public Data(string year, string month, string day)
            {
                this.year = year;
                this.month = month;
                this.day = day;
            }
            public void Information()
            {
                Console.WriteLine("Время создания " + year + " " + " " +
                month + " " + day);
            }

        }


    }


    class Program
    {

        static void Main(string[] args)
        {

            FixedStack stack = new FixedStack();
            stack.Push(4);
            stack.Push(5);
            stack.Push(8);
            stack.Push(23);
            stack.Push(5);
            stack.Push(4);
            Console.WriteLine("Демонстрируем работу —");
            Console.WriteLine(stack.Peek());
            Console.WriteLine("Это был вывод вершины стека с повторяющимися элементами");
            (stack)--;
            Console.WriteLine("Это вывод вершины без повторяющихся элементов");
            Console.WriteLine(stack.Peek());
            Console.WriteLine("Демонстрируем работу ++ бех дублирования элемента");
            Console.WriteLine(stack.Count);
            stack++;
            Console.WriteLine("Дублируем и выводим новый размер стека");
            Console.WriteLine(stack.Count);
            Console.WriteLine("Расширяемые методы");

            Console.WriteLine("Содержит ли стек отрицательные элементы" + stack.IsNegative());

            FixedStack stack1 = new FixedStack(10, "I m angry ! I hate you!");
            Console.WriteLine("Количество восклицательных предложений в строке " + stack1.Sentence());

            Console.WriteLine("Вложенные объекты");
            FixedStack.Owner owner = new FixedStack.Owner();
            owner.Information();
            FixedStack.Data data = new FixedStack.Data("2020", "October", "Friday");
            data.Information();
        }
    }
}