using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyStringOpers // класс поддержки опраций нестандартных операций со строками
{

    public string MyStr; // строка ддя проведения операций преобразования
    public char[] arr; // представление строки в виде символьного массива

    public MyStringOpers(string var_str) // конструктор
    {
        MyStr = var_str;
        arr = var_str.ToCharArray(); // представление строки в виде символьного массива
    }

    public void ChangeSpaces(Action<int> var_act, Predicate<char> var_pred)
    {
        /* метод заменяет в строке все знаки препинания на пробелы */

        // преобразование элементов массива

        for (int i = 0; i < arr.Length; i++)
        {

            if (var_pred(arr[i])) var_act(i);
        }

        MyStr = new String(arr); // заново определим строку на основании символьного массива

    }

    public void UpLowers(Action<int> var_act, Predicate<char> var_pred)
    {
        /* метод приводит в строке все символы нижнего регистра - к верхнему */

        // преобразование элементов массива

        for (int i = 0; i < arr.Length; i++)
        {

            if (var_pred(arr[i])) var_act(i);
        }

        MyStr = new String(arr); // заново определим строку на основании символьного массива

    }

    public void RemoveChars(Func<string, string> workFunc)
    {
        /* метод удаляет из строки все вхождения определенного символа */

        MyStr = workFunc(MyStr);

    }

    public void AddCharToEnd(Func<string, string> workFunc)
    {
        /* метод производит добавление символа в конец строки */

        MyStr = workFunc(MyStr);

    }

    public void InsertCharToBegin(Func<string, string> workFunc)
    {
        /* метод производит добавление символа в начало строки */

        MyStr = workFunc(MyStr);

    }

    // методы проверки символов на выполнение некоторого условия
    public bool CheckPunctMarks(char varChar)
    {
        /* 
          метод проверяет значение символьной переменной на принадлежность знакам препинания (.,;:-)
          данный метод будет присвоен предикату
         */

        bool ret_val = false;

        if (varChar == '.' || varChar == ',' || varChar == ';' || varChar == ':' || varChar == '-') ret_val = true;

        return ret_val;

    }

    public bool CheckIsLower(char varChar)
    {
        /* 
          метод проверяет значение символьной переменной на принадлежность символам в нижнем регистре
          данный метод будет присвоен предикату
         */

        return (char.IsLower(varChar));

    }


    // методы обработки элементов символьного массива arr

    public void SetCharToSpace(int idx)
    {
        /* метод устанавливает значение элемента массива с индексом idx в пробельное */

        arr[idx] = ' ';
    }

    public void SetCharToUpper(int idx)
    {
        /* метод приводит значение элемента массива с индексом idx к верхнему регистру */

        arr[idx] = char.ToUpper(arr[idx]);
    }

    public string SpaceKiller(string var_str)
    {
        /* метод удаляет пробелы из строки */

        string ret_val = "";

        // преобразование элементов массива

        for (int i = 0; i < var_str.Length; i++)
        {

            if (var_str.ElementAt(i) != ' ') ret_val += var_str.ElementAt(i);
        }

        return ret_val;

    }

    public string AddPercent(string var_str)
    {

        /* метод добавляет % к концу строки */

        string ret_val = var_str + "%";

        return ret_val;

    }

    public string InsertUnderLine(string var_str)
    {
        /* метод вставляет _ в начало строки */

        string ret_val = "_" + var_str;

        return ret_val;

    }

}
