using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
//////////////////////ТИП////////////////////////////////////////////
 // Инициализация переменных
            bool var1 = false;
            byte var2 = 255;
            sbyte var3 = 127;
            short var4 = 30000;
            ushort var5 = 0;
            int var6 = 987548378;
            uint var7 = 0xFF; //в 16-чной 255
            long var8 = 0b101011; // 43
            ulong var9 = 54667778776767877;
            float var10 = 134.45E-2f;
            double var11 = 999999999.9999;
            decimal var12 = -1.2334234m;
            char var13 = 'M';
            string var14 = "Hi, how are you?";

//Осуществите ввод и вывод их значений используя консоль
            // Ввод строковой переменной

            Console.Write("Введите значение переменной var14: ");
            var14 = Console.ReadLine();
            Console.WriteLine();

            // Вывод переменных в консоль
            Console.WriteLine($"bool: \t{var1}\n" +
            $"byte: \t{var2}\n" +
            $"sbyte: \t{var3}\n" +
            $"short: \t{var4}\n" +
            $"ushort: {var5}\n" +
            $"int: \t{var6}\n" +
            $"uint: \t{var7}\n" +
            $"long: \t{var8}\n" +
            $"ulong: \t{var9}\n" +
            $"float: \t{var10}\n" +
            $"double: {var11}\n" +
            $"decimal: {var12}\n" +
            $"char: \t{var13}\n" +
            $"string: {var14}\n");


//b) Выполните операций явного и неявного приведения.
// Неявные преобразования

            byte x1 = 255;
            short x2 = x1;
            Console.WriteLine("x2 = {0}", x2);

//Явные преобразования
         
            float y1 = -5.4F;
            short y2 = (short)y1;
            Console.WriteLine("y2 = {0}", y2);

 //Класс Convert

            float z1 = -49.34F;
            int z2 = Convert.ToInt32(z1);
            Console.WriteLine("z2 = {0}", z2); //округление до int

 //с)Выполните упаковку и распаковку значимых типов.
          
            int ip = 666;
            object myobj = ip; //упаковка
            int k = (int)myobj; //распаковка
            Console.WriteLine("k = {0}", k);

            //d)Продемонстрируйте работу с неявно типизированной переменной.
            var v = 5; 
            var st = "Hi, how are you?"; 
            var fl = 0.34F;
//e)Продемонстрируйте пример работы с Nullable переменной
  
            int? x = null;
            x = 9;

 //f)Ошибка с var

            var h = 134.45E-2f;
            h = 6776; 

 ////////////////////////// СТРОКИ///////////////////////////////////////
//a)Объявите строковые литералы. Сравните их.
           
            string str1= "Marinaaaaaaa",str12 = "hello!";

            Console.WriteLine("Сравниваемые строки: \"" + str1 + "\" и \"" + str12 + "\nРезультат сравнения: " + String.Compare(str1, str12));
//b)Создайте три строки на основе String  
//сцепление
            string string1 = "What fgjhjfhgugh",
            string2 = "a nice hffffffffffff ",
            string3 = "day";

            Console.WriteLine("Сцепление: " + string1 + string2 + string3);

// Разделение строки на подстроки
            string w = "What a good day , what a good stump";
            Console.WriteLine("Разделение строки на подстроки:");
            string[] words = w.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string cc in words)
                Console.WriteLine(cc);

//КОПИРОВАНИЕ - метод String.CopyTo() -  Этот метод копирует из строки часть символов, начиная с заданной позиции, и вставляет их !в массив символов!, также с указанной позиции. 
            char[] myarray = string3.ToCharArray(); //cоздание символьного массива на основе строки 3
            string2.CopyTo(0, myarray, 0, 3); //вставляем 2, начиная с 0 позиции, в символьный массив, начиная с 0 позиции, вставляем 3 элемента
            Console.WriteLine(myarray);

//ВЫДЕЛЕНИЕ ПОДСТРОКИ - метод String.Substring() - Извлекает подстроку из данного экземпляра. Подстрока начинается в указанном положении символов и продолжается до конца строки.
            string str4 = string1.Substring(5);
            Console.WriteLine(str4);

            str4 = string2.Substring(0, 3);
            Console.WriteLine(str4);

//ВСТАВКА ПОДСТРОКИ В ЗАДАННУЮ ПОЗИЦИЮ - метод String.Insert() 
            string modified = string2.Insert(5, string1);
            Console.WriteLine(modified);

            // Удаление подстроки
            string num = "0123456789";
            Console.WriteLine("Удаление подстроки: " + num.Remove(0, 5));

            // Интерполирование строк
            int one = 1,
            two = 2;
            Console.WriteLine($"Интерполирование строк: один - {one}, два - {two}");

            // Пустые и null строки
            string nullString = null;
            string emptyString = "";
            bool IsEmptyStr1 = String.IsNullOrEmpty(emptyString);//Указывает, действительно ли указанная строка является строкой null или пустой строкой
            Console.WriteLine(IsEmptyStr1);
            //Можно проверить, являются ли равными пустая строка и null-строка:
            bool AreEquals = (emptyString == nullString);

            // d. StringBuilder
            StringBuilder sb = new StringBuilder("Hello World!");
            Console.WriteLine("\n---StringBuilder---\nНачальная строка: " + sb);
            sb.Remove(0, 5);// Метод Remove -удаляет определенное количество символов, начиная с определенного индекса
            sb.AppendFormat("!!");//Добавляет к данному экземпляру строку
            sb.Insert(0, "Привет"); //Метод Insert -вставляет подстроку в объект StringBuilder, начиная с определенного индекса
            Console.WriteLine("Строка после форматирования: " + sb);

//////////////////// МАССИВЫ/////////////////////////////////////////////////
//Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица).

            int[,] arr = {{1,10},{2,20},{3,30},{4,40}};

            Console.WriteLine("Матрица:");
            for (int km = 0; km < 4; km++)
            {
                for (int n = 0; n < 2; n++)
                    Console.Write(arr[k, n] + "\t");
                Console.WriteLine();
            }
// Одномерный массив строк
            string[] arrOfStr = { "Hello ", "World!" };
            //Поменяйте произвольный элемент, пользователь определяет позицию и значение
            foreach (string smth in arrOfStr)
            Console.WriteLine(smth);
            Console.WriteLine("Длина массива строк: " + arrOfStr.Length);
            Console.Write("Выберете индекс строки: ");
            int index = Convert.ToInt32((Console.ReadLine()));
            if (index != 0 && index != 1)
                Console.WriteLine("Введены неверные данные!");
            else
            {
                Console.Write("Введите строку: ");
                arrOfStr[index] = Console.ReadLine();
                Console.Write("Полученная строка: ");
            foreach (string smth in arrOfStr)
             Console.Write(smth);
             Console.WriteLine();
            }

// Ступенчатый массив
            int[][] steppedArray = new int[3][];
            steppedArray[0] = new int[2];
            steppedArray[1] = new int[3];
            steppedArray[2] = new int[4];
            for (i = 0; i < steppedArray.Length; i++)
                for (j = 0; j < steppedArray[i].Length; j++)
                {
                    Console.Write($"Введите число с координатами ({i},{j}): ");
                    steppedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Полученный массив: ");
            for (i = 0; i < steppedArray.Length; i++)
            {
                for (j = 0; j < steppedArray[i].Length; j++)
                    Console.Write(steppedArray[i][j] + "\t");
                Console.WriteLine();
            }

// неявно типизированные переменные для хранения массива и строки. 
            var varArr = new[] { 5, 10, 23, 16, 8 };
            var varStr = "Hi, how are you?";

////////////////////////КОРТЕЖИ-множество симвалов разного типа
//Задайте кортеж и вывести
            
            (int, string, char, string, ulong) t = (88, "Help", 'm', "meeee", 999);
            Console.WriteLine($"Кортеж: {t.Item1}, {t.Item2}, {t.Item3}, {t.Item4}, {t.Item5}");
            Console.WriteLine($"1, 3 и 4 элементы кортежа: {t.Item1}, {t.Item3}, {t.Item4}");

 // Распаковка кортежей
            (int q, string wd, char e, string r, ulong y) = t;
            int cortInt;
            string cortStr1, cortStr2;
            char cortChar;
            ulong cortUlong;
            (cortInt, cortStr1, cortChar, cortStr2, cortUlong) = t;
            var (c1, c2, c3, c4, c5) = t;
            _ = Console.ReadLine(); //_ - переменная, которая ничего не хранит, не выделяется память под нее

            // Сравнение кортежей
            (long a, int b) righttuple = (5, 10);
            (float a, int b) middletuple = (-5.77F, 10);
            Console.WriteLine(righttuple != middletuple);  // output: True

 // Локальная функция, которая возвращает кортеж
            static (int, int, int, char) func(int[] arr, string str)
            {
                int min = arr[0],
                max = arr[0],
                sum = 0;
                foreach (int i in arr)
                {
                    if (i > max)
                        max = i;
                    if (i < min)
                        min = i;
                    sum += i;
                }
                return (max, min, sum, str[0]);
            }

            var returnedCort = func(new int[] { 1, 2, 3, 4, 5 }, "Hello");

            // checked/unchecked-Проверенное и непроверенное ключевое слово
            //a. Определите две локальные функции. 
            // b.Разместите в одной из них блок checked, в котором определите переменную типа int с максимальным возможным значением этого типа.
            //Во второй функции определите блок unchecked стаким же содержимым. 
            //c.Вызовите две функции.
            static void checkedFunc()
            {
                int x = checked(int.MaxValue);
            }
            static void uncheckedFunc()
            {
                int x = unchecked(int.MaxValue);
            }
            checkedFunc();
            uncheckedFunc();
        }
    }
}