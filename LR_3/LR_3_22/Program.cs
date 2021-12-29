using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Вектор заполненный рандомно");
            BoolVector MyVector1 = new BoolVector(5);//Это в конструктор передаётся размер вектора,И создаётся вектор размером 5 элементов
            MyVector1.fillRandom(); // заполняем вектор рандомно
            MyVector1.printConsole();
            // проверим тип нашего объекта
            if (MyVector1 is BoolVector)
            Console.WriteLine("Тип объекта - BoolVector");
            Console.WriteLine("Количество нулей в векторе : {0}", MyVector1.calcZeros());//{0}-это cтрока составного формата
            Console.WriteLine("Количество единиц в векторе : {0}", MyVector1.calcOnes());

// следующий вектор введем с консоли
            Console.WriteLine("\nВводим Вектор с консоли : ");
            BoolVector MyVector2 = new BoolVector(5);
            MyVector2.fillConsole();
            MyVector2.printConsole();

            // следующему вектору присвоим значение поразрядной конъюнкции (тоже вектор) первых двух векторов
            Console.WriteLine("Выведем Вектор являющийся поразрядной конъюнкцией первого и второго Векторов : ");
            BoolVector MyVector3 = MyVector1.logicAND(MyVector2);
            MyVector3.printConsole();

            // следующему вектору присвоим значение поразрядной дизъюнкции (тоже вектор) первых двух векторов
            Console.WriteLine("Выведем Вектор являющийся поразрядной дизъюнкцией первого и второго Векторов : ");
            BoolVector MyVector4 = MyVector1.logicOR(MyVector2);
            MyVector4.printConsole();

            // следующему вектору присвоим значение поразрядного отрицания (тоже вектор) первого вектора
            Console.WriteLine("Выведем Вектор являющийся поразрядным отрицанием первого Вектора : ");
            BoolVector MyVector5 = MyVector1.logicNOT();
            MyVector5.printConsole();

            // cоздади массив векторов из 12-ти элементов, каждый Вектор размерности 3
            int arraysize = 12;
            BoolVector[] MyArray = new BoolVector[arraysize];
            // выведем массив (все его элементы - вектора) на консоль
            Console.WriteLine("Массив из {0} Булевых векторов : ", arraysize);
            for (int i = 0; i < arraysize; i++)
            {
                MyArray[i] = new BoolVector(3); // конструктор для Вектора (элемента массива)
                MyArray[i].fillRandom();    // заполняем рандмино
                MyArray[i].printConsole();  // выводим на консоль
            }

// выведем вектора с заданным число единиц :
            Console.Write("Введите число единиц : ");
            int rq_ones = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вектора с числом единиц {0} :\n", rq_ones);
            int k = 0; // число векторов с данным количеством единиц
            for (int i = 0; i < arraysize; i++)
            {
                if (MyArray[i].calcOnes() == rq_ones)
                {

                    MyArray[i].printConsole();

                    k++;

                }
            }
            if (k == 0) Console.Write("ТАКИХ ВЕКТОРОВ НЕТ.");

// выведем вектора с заданным число нулей :
            Console.Write("Введите число нулей : ");
            int rq_zeros = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вектора с числом нулей {0} :\n", rq_zeros);
            int z = 0; // число векторов с данным количеством нулей
            for (int i = 0; i < arraysize; i++)
            {
                if (MyArray[i].calcZeros() == rq_zeros)
                {

                    MyArray[i].printConsole();

                    z++;

                }
            }
            if (z == 0) Console.Write("ТАКИХ ВЕКТОРОВ НЕТ.");

 // определим и выведем равные вектора
            int qequals = 0; // счетчик равных векторов массива

            Console.WriteLine("Равные вектора : ");
            for (int i = 0; i < arraysize - 1; i++)
            {
                for (int j = i + 1; j < arraysize; j++)
                {

                    if (MyArray[i].Equals(MyArray[j]))
                    {
                        Console.Write("{0} : ", i + 1);
                        MyArray[i].printConsole();
                        Console.Write("{0} : ", j + 1);
                        MyArray[j].printConsole();

                        Console.WriteLine(""); // визуально разделим группы равенства

                        qequals++;

                    }

                }
            }
            if (qequals == 0) Console.Write("РАВНЫХ ВЕКТОРОВ В МАССИВЕ НЕТ.");

            // выведем информацию о классе
            Console.WriteLine(BoolVector.ClassInfo());

            // cоздайте и выведите анонимный тип по образцу вашего класса

            /* анонимные типы позволяют создать объект с некоторым набором свойств без определения класса, 
               анонимный тип определяется с помощью ключевого слова var и инициализатора объектов */

            var myvector = new { vec = "10001001001010001", sz = 17 };
            Console.WriteLine("свойство vec объекта анонимного типа myvector : {0}", myvector.vec);
            Console.WriteLine("свойство size объекта анонимного типа myvector : {0}", myvector.sz);

            Console.ReadKey();
        }
    }
}