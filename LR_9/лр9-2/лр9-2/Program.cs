/*
    
2. Создайте пять методов пользовательской обработки строки (например, удаление знаков препинания, добавление символов, 
   замена на заглавные, удаление лишних пробелов и т.п.). 
   Используя стандартные типы делегатов (Action, Func, Predicate) организуйте алгоритм последовательной обработки строки написанными вами методами.
   ТЕОРИЯ
   Делегат Action является обобщенным, принимает параметры и возвращает значение void:   
   public delegate void Action<T>(T obj)
   Как правило, этот делегат передается в качестве параметра метода и предусматривает вызов определенных действий в ответ на произошедшие действия
   Делегат Func возвращает результат действия и может принимать параметры.
   TResult Func<out TResult>()
   Делегат Predicate<T>, как правило, используется для сравнения, сопоставления некоторого объекта T определенному условию. 
   В качестве выходного результата возвращается значение true, если условие соблюдено, и false, если не соблюдено
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Введите строку : ");

        string the_str = Console.ReadLine();

        MyStringOpers MyStringOpers1 = new MyStringOpers(the_str); // создаем экземпляр класса

        // 1. заменим в исходной строке все знаки препинания на пробелы
        // создадим предикат - в качестве него возьмем метод проверки значения символьной переменной на принадлежность знакам препинания (.,;:-)
        Predicate<char> Mypredicate1 = MyStringOpers1.CheckPunctMarks;
        Action<int> Action1 = MyStringOpers1.SetCharToSpace;

        MyStringOpers1.ChangeSpaces(Action1, Mypredicate1);

        Console.WriteLine("Строка после преобразования (замена знаков препинания на пробелы) : '{0}'", MyStringOpers1.MyStr);

        // 2. заменим все символы нижнего регистра на символы верхнего
        // создадим предикат - в качестве него возьмем метод проверки значения символьной переменной на принадлежность символам в нижнем регистре
        Predicate<char> Mypredicate2 = MyStringOpers1.CheckIsLower;
        Action<int> Action2 = MyStringOpers1.SetCharToUpper;

        MyStringOpers1.UpLowers(Action2, Mypredicate2);

        Console.WriteLine("Строка после преобразования (замена символов нижнего регистра на символы верхнего) : '{0}'", MyStringOpers1.MyStr);

        // 3. удалим из строки все пробелы

        Func<string, string> Func1 = MyStringOpers1.SpaceKiller; //y Func последний параметр - то, что он возвращает
        MyStringOpers1.RemoveChars(Func1);
        Console.WriteLine("Строка после преобразования (удаление пробелов) : '{0}'", MyStringOpers1.MyStr);

        // 4. добавление символа % в конец строки
        Func<string, string> Func2 = MyStringOpers1.AddPercent;
        MyStringOpers1.AddCharToEnd(Func2);
        Console.WriteLine("Строка после преобразования (добавления % в конец строки) : '{0}'", MyStringOpers1.MyStr);

        // 5. добавление символа _ в начало строки
        Func<string, string> Func3 = MyStringOpers1.InsertUnderLine;
        MyStringOpers1.InsertCharToBegin(Func3);
        Console.WriteLine("Строка после преобразования (добавления _ в начало строки) : '{0}'", MyStringOpers1.MyStr);


        Console.ReadKey();


    }
}