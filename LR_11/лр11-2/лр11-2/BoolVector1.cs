using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class BoolVector : IComparable /* реализуем единственный метод CompareTo интерфейса IComparable, чтобы иметь возможность сортировать наши вектора */
{
    public int[] vect; // реализация Булева Вектора - массив целых чисел (1 - Истина, 0 - Ложь)
    public int vectorsize = 0; //размерность Булева Вектора - количество элементов в нем

    /* константы должны быть определены во время компиляции, следовательно инициализировать константу можно только при ее определении */
    private const int vectorsize_deflt = 5; // размерность Булева Вектора по умолчанию

    /* поле только для чтения можно инициализировать при его объявлении либо на уровне класса, либо инициилизировать и изменять в конструкторе,
       инициализировать или изменять его значение в других местах нельзя, можно только считывать его значение. */

    public int ID; // хеш

    // статическое поле, хранящее количество созданных объектов класса
    static int total_vectors = 0; // инкрементируется в конструкторе

    public static String ClassInfo()
    {
        // статический метод вывода информации о классе - вернем название класса и созданных объектов данного класса
        return "Class BoolVector - " + total_vectors + " объектов данного класса создано на данный момент.";

    }

    public BoolVector()
    {
        // конструктор без параметров
        vectorsize = vectorsize_deflt;
        vect = new int[vectorsize];
        ID = GetHashCode();
    }

    public BoolVector(int size)
    {
        // конструктор с параметром size - размерность вектора

        total_vectors++;

        vectorsize = size;
        vect = new int[vectorsize];
        ID = GetHashCode();
    }

    // далее определим специальные методы доступа - Свойства, они обеспечивают простой доступ к полям классов и структур, позволяют узнать их значение или выполнить их установку

    public int vecsize      // свойство для размерности Вектора
    {
        /* пусть метод доступа get получит уровень доступа самого свойства (public), а к методу set явным образом применим модификатор доступа protected 

           protected (защищенный) - доступ к защищенному элементу базового класса может быть получен в производном классе

         */
        get { return vectorsize; }

        protected set { vectorsize = value; }

    }

    public int[] vecdata    // свойство для реализации Вектора
    {
        get { return vect; }
        set
        {
            vect = value;

        }
    }

    // зададим индексатор для доступа к элементам Вектора

    public int this[int index]
    {

        get
        {

            return vect[index];

        }

        set
        {

            vect[index] = value;

        }

    }

    public void fillConsole()
    {
        // метод считывает элементы вектора с консоли

        for (int j = 0; j < vectorsize; j++)
        {

            Console.Write("Введите {0}-й элемент Вектора :", j + 1);

            int consval = Convert.ToInt32(Console.ReadLine());

            if (consval == 0) vect[j] = 0;

            else vect[j] = 1; // если вводится ненулевое значение , то полагаем это Истина

        }

    }

    // статическая переменная - счетчик обращений к генератору случайных чисел - 
    // используется для задания начального значения генератора, чтобы при последовательных вызовах
    // получать разные случайные числа
    static int call_random_counter = 0;

    public void fillRandom()
    {

        // метод заполняет вектор рандомно

        // создание объекта для генерации случайных чисел
        Random rnd = new Random(++call_random_counter);

        for (int j = 0; j < vectorsize; j++)
        {
            // получим случайное число (в диапазоне от 0 до 1)
            int value = rnd.Next(0, 2); // у метода Next() верхний предел не включается в диапазон, поэтому граница диапазона - 2

            vect[j] = value;

        }

    }

    public string printConsole()
    {

        // метод выводит элементы вектора на консоль

        // метод String.Join() сцепляет элементы указанного массива или элементы коллекции, помещая между ними заданный разделитель

        // Console.WriteLine("Вектор : {0}", String.Join(" ", vect)) ;
        // Console.WriteLine("Вектор ID={0} : {1}", ID, String.Join(" ", vect));

        string ret_val = this.GetInfo() + "  " + String.Join(" ", vect);

        Console.WriteLine(ret_val);

        return ret_val;

    }

    public int calcZeros()
    {

        // метод подсчитывает количество нулей в векторе

        int zeroQtt = 0; // количество нулей в векторе

        for (int j = 0; j < vectorsize; j++)
        {
            if (vect[j] == 0) zeroQtt++;

        }

        return zeroQtt;

    }

    public int calcOnes()
    {

        // метод подсчитывает количество единиц в векторе

        int onesQtt = 0; // количество единиц в векторе

        for (int j = 0; j < vectorsize; j++)
        {
            if (vect[j] == 1) onesQtt++;

        }

        return onesQtt;
    }

    public BoolVector logicAND(BoolVector v2)
    {

        // метод выполняет поразрядную конъюнкцию двух векторов, возвращает Вектор

        BoolVector tmpVector = new BoolVector(vectorsize);

        for (int j = 0; j < vectorsize; j++)
        {

            tmpVector[j] = vect[j] & v2[j];

        }

        return tmpVector;
    }

    public BoolVector logicOR(BoolVector v2)
    {

        // метод выполняет поразрядную дизъюнкцию двух векторов, возвращает Вектор

        BoolVector tmpVector = new BoolVector(vectorsize);

        for (int j = 0; j < vectorsize; j++)
        {

            tmpVector[j] = vect[j] | v2[j];

        }

        return tmpVector;
    }

    public BoolVector logicNOT()
    {

        // метод выполняет поразрядное отрицание вектора, возвращает Вектор

        BoolVector tmpVector = new BoolVector(vectorsize);

        for (int j = 0; j < vectorsize; j++)
        {

            if (vect[j] == 0) tmpVector[j] = 1;
            else
                if (vect[j] == 1) tmpVector[j] = 0;

        }

        return tmpVector;
    }

    public int CompareTo(object o)
    {

        /* Реализуем единственный метод интерфейса IComparable, чтобы иметь возможность 
           сортировать наши вектора (использовать метод Sort() для объекта их коллекцци) 
        
           На выходе он возвращает целое число, которое может иметь одно из трех значений:
           - меньше нуля - значит, текущий объект должен находиться перед объектом, который передается в качестве параметра
           - равное нулю - значит, оба объекта равны
           - больше нуля - значит, текущий объект должен находиться после объекта, передаваемого в качестве параметра.
        Положим, для наших булевых векторов, что величина (вес) вектора определяется числом единиц в нем,
        соответственно больше тот вектор, число единиц у которого больше.
       */

        int ret_val = 0;

        BoolVector v2 = o as BoolVector; // трактуем параметр метода как объект класса BoolVector, приводим пришедший параметр к BoolVector

        if (this.calcOnes() == v2.calcOnes()) ret_val = 0;
        else
        {
            if (this.calcOnes() < v2.calcOnes()) ret_val = -1;
            else
            {
                if (this.calcOnes() > v2.calcOnes()) ret_val = +1;
            }
        }

        /* это альтернативный вариант - за правило сравнения векторов берем в точности сравнение их строковых представлений
         
        BoolVector v2 = o as BoolVector;
        ret_val = this.ToString().CompareTo(v2.ToString());
        */

        return ret_val;
    }
}