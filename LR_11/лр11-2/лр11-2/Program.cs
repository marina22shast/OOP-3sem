/*
    2. Создайте коллекцию List<T> и параметризируйте ее типом (классом) из лабораторной №3 (при необходимости реализуйте нужные интерфейсы). 
       Заполните ее минимум 10 элементами. Если в задании указано свойство, которым ваш класс не обладает, то его нужно расширить, 
       чтобы класс соответствовал условию. 
       Один из запросов реализуйте используя язык LINQ и используя методы расширения LINQ.
    3. На основе LINQ сформируйте следующие запросы по вариантам. При необходимости добавьте в класс T (тип параметра) свойства.
       - вектора с заданным числом единиц/нулей; 
       - определить и вывести равные вектора в коллекции 
       - максимальный вектор 
       - первый вектор с n единицами 
       - упорядоченный вектор по числу единиц - имеется ввиду "упорядоченные вектора по числу единиц"
    4. Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: 
       условия, проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения.
    5. Придумайте запрос с оператором Join.
    -----
    ЛР №3
    Построить класс Булев вектор (BoolVector). 
    Реализовать методы для выполнения поразрядных конъюнкции, дизъюнкции и отрицания векторов, а также подсчета числа единиц и нулей в векторе. 
    Создать массив объектов. Вывести: a) вектора с заданным числом единиц/нулей; b) определить и вывести равные вектора.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // определим коллекцию булевых Векторов на основе списка (List<T>)
            List<BoolVector> MyBoolVectorCollection = new List<BoolVector>();

            // заполним нашу коллекцию 10 элементами - булевыми векторами размерности 5, заполненными рандомно
            int coll_size = 10, // кол-во векторов в коллекции 
                vector_size = 5 // размерность каждого вектора
                ;
            for (int i = 1; i <= coll_size; i++)
            {
                BoolVector new_vector = new BoolVector(vector_size);
                new_vector.fillRandom(); // заполняем вектор рандомно
                MyBoolVectorCollection.Add(new_vector);
            }

            Console.WriteLine("Коллекция из {0} рандомно заполненных векторов каждый размерности {1} : ", coll_size, vector_size);
            foreach (var vec in MyBoolVectorCollection) vec.printConsole();

            // a. вектора с заданным числом единиц/нулей
            Console.Write("Введите число единиц : ");
            int rq_ones = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вектора с числом единиц {0} :\n", rq_ones);

            var selectedVectors = from v in MyBoolVectorCollection
                                  where v.calcOnes() == rq_ones
                                  select v;
            if (selectedVectors.Count() == 0) Console.Write("ТАКИХ ВЕКТОРОВ В КОЛЛЕКЦИИ НЕТ.");
            else
            {
                foreach (var v in selectedVectors) v.printConsole();
            }

            Console.Write("Введите число нулей : ");
            int rq_zeros = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вектора с числом нулей {0} :\n", rq_zeros);

            selectedVectors = from v in MyBoolVectorCollection
                              where v.calcZeros() == rq_zeros
                              select v;
            if (selectedVectors.Count() == 0) Console.Write("ТАКИХ ВЕКТОРОВ В КОЛЛЕКЦИИ НЕТ.");
            else
            {
                foreach (var v in selectedVectors) v.printConsole();
            }

            // b. определить и вывести равные вектора в коллекции - здесь речь о поразрядном равенстве

            Console.WriteLine("равные вектора в коллекции :");
            /* алгоритм :
               сгруппировать по количеству вхождений - отбросить из рассмотрения входящие 1 раз - вывести каждую запись соответственно числу ее вхождений 
               
               на примере:
               1010, 1100, 1010, 1110, 1010, 1100
             
               на первом этапе получим:
               1010   3
               1110   1
               1100   2
               на втором этапе получим:
               1010   3
               1100   2
               
               и затем выведем трижды 1010, дважды 1100
               
             */

            // осуществим группировку векторов в коллекции по числу их вхождений
            var countGroups1 = from v in MyBoolVectorCollection
                                   // группируем по строковому представлению вектора - ToString() у нас переопределен и возвращает именно его
                               group v by v.ToString() into vectors
                               // Key (ключ) в данном случае - строковое представление вектора
                               select new { Name = vectors.Key, Count = vectors.Count() } // создадим из группы новый объект
                              ;
            // отбираем вектора, встречающиеся более одного раза
            var NonOneCountVectors = from v in countGroups1
                                     where v.Count > 1
                                     // orderby v.Name
                                     select v;

            // итогово - выведем каждый вектор столько раз, сколько раз он входит в коллекцию
            foreach (var group in NonOneCountVectors)
            {
                for (int i = 1; i <= group.Count; i++)
                {
                    Console.WriteLine("{0}", group.Name);
                }
            }

            // c. максимальный вектор

            /* Положим, для наших булевых векторов, что величина (вес) вектора определяется числом единиц в нем,
               соответственно максимальным будет являться вектор с наибольшим числом единиц. */
            // возьмем максимальное число единиц в векторе на всей нашей коллекции
            int maxOnes = MyBoolVectorCollection.Max(n => n.calcOnes());
            // возьмем первый вектор с maxOnes единицами - он и является максимальным
            // используем метод расширения First (он выбирает первый элемент коллекции)
            BoolVector maxVector = MyBoolVectorCollection.First(p => p.calcOnes() == maxOnes);
            Console.WriteLine("Максимальный вектор : {0}", maxVector.ToString());

            // d. первый вектор с n единицами
            // сделали в с.

            // e. упорядоченные вектора по числу единиц
            Console.WriteLine("Упорядоченные вектора по числу единиц :"); //СНАЧАЛА БУДЕТ например 0 единиц, потом вектора с 1ой единицей и тд
            MyBoolVectorCollection.Sort();
            foreach (var v in MyBoolVectorCollection) v.printConsole();

            /* 4. Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: 
               условия, проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения.
            условия          where
            проекций         select
            упорядочивания   OrderBy, ThenBy, Reverse
            группировки      GroupBy
            агрегирования    Count, Min, Max
            кванторов        Any, All, Contains
            разбиения        Skip, Take, +While
            */

            Console.WriteLine("Результат выполнения собственного запроса -");
            Console.WriteLine("вывести в порядке возрастания первые два вектора с числом нулей более двух, встречающиеся в коллекции ровно один раз : ");
            // 

            var countGroups2 = (
                               from t in
                               //
                               (
                                   from v in MyBoolVectorCollection // из исходной коллекции
                                   where v.calcZeros() > 2 // берем вектора с числом нулей более двух
                                   group v by v.ToString() into vectors // группируем их по строковому представлению вектора
                                   orderby vectors.Key                  // упорядочиваем по строковому представлению вектора 
                                   // создадим из группы новый объект с двумя членами Name (строковое предствление вектора) и Count (число вхождений)
                                   select new { Name = vectors.Key, Count = vectors.Count() }
                               )
                                   //
                               where t.Count == 1 // берем встречающеся один раз
                               select t
                               ).Take(2); // возьмем первые два в итоговой выборке
            ;

            if (countGroups2.Count() == 0) Console.Write("ТАКИХ ВЕКТОРОВ В КОЛЛЕКЦИИ НЕТ.\n");
            else
            {

                foreach (var item in countGroups2)
                    Console.WriteLine("{0}", item.Name);
            }

            /* 5. Придумайте запрос с оператором Join
             
             пусть есть аналогичная вторая коллекция - найти всевозможные пары из обоих коллекций у которых количество единиц совпадает
             
            */

            // определим еще одну коллекцию булевых Векторов на основе списка (List<T>)
            List<BoolVector> MyBoolVectorCollection2 = new List<BoolVector>();

            // заполним данную коллекцию элементами
            for (int i = 1; i <= coll_size; i++)
            {
                BoolVector new_vector = new BoolVector(vector_size);
                new_vector.fillRandom(); // заполняем вектор рандомно
                MyBoolVectorCollection2.Add(new_vector);
            }
            // выведем ее на консоль
            Console.WriteLine("Коллекция №2 из {0} рандомно заполненных векторов каждый размерности {1} : ", coll_size, vector_size);
            foreach (var vec in MyBoolVectorCollection2) vec.printConsole();

            var result = from v1 in MyBoolVectorCollection
                         join v2 in MyBoolVectorCollection2 on v1.calcOnes() equals v2.calcOnes()
                         select new { Name1 = v1.ToString(), Name2 = v2.ToString() };

            Console.WriteLine("Всевозможные пары из обоих коллекций у которых количество единиц совпадает : ");
            foreach (var item in result)
                Console.WriteLine("{0} - {1}", item.Name1, item.Name2); // выведем пару

            Console.ReadKey();

        }
    }
}