/*
    
    3) Создайте объект наблюдаемой коллекции ObservableCollection<T>. 
       Создайте произвольный метод и зарегистрируйте его на событие CollectionChanged. 
       Напишите демонстрацию с добавлением и удалением элементов. В качестве типа T используйте свой класс из таблицы.
    ТЕОРИЯ
    Кроме стандартных классов коллекций типа списков, очередей, словарей, стеков .NET также предоставляет 
    специальный класс ObservableCollection - он по функциональности похож на список List за тем исключением,
    что позволяет известить внешние объекты о том, что коллекция была изменена.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // обязательно подключить!
using System.Collections.Specialized; // обязательно подключить!
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем объект наблюдаемой коллекции, в качестве типа T берем класс GeomFigure из Задания 1
            ObservableCollection<GeomFigure> MyFigures = new ObservableCollection<GeomFigure>();

            MyFigures.CollectionChanged += Figures_CollectionChanged; // регистрируем обработчик события CollectionChanged; 
            //CollectionChanged - событие (основано на делегате - ссылка на метод)

            // Добавляем три элемента в коллекцию
            MyFigures.Add(new GeomFigure("Ромб", 210.15, 456.23));
            MyFigures.Add(new GeomFigure("Квадрат", 453.55, 345.89));
            MyFigures.Add(new GeomFigure("Эллипс", 267.15, 245.11));

            // Удалим второй элемент из коллекции (элемент с индексом 1)
            MyFigures.RemoveAt(1);

            // Выведем коллекцию на консоль
            Console.WriteLine("\nЭлементы коллекции : ");
            foreach (var x in MyFigures) x.GetInfo();


            Console.ReadKey();
        }

        private static void Figures_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            /* обработчик события CollectionChanged */
            //NotifyCollectionChangedEventArgs - информация о происходящем изменении в коллекции.

            switch (e.Action) //Action - действие
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    GeomFigure newFigure = e.NewItems[0] as GeomFigure; //В масстве NewItems[] содержится добавляемый в коллекцию элемент; as GeomFigure - трактуем как объект класса GeomFigure
                    Console.WriteLine("Добавлен новый объект : {0}", newFigure.Type);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    GeomFigure oldFigure = e.OldItems[0] as GeomFigure; //В масстве OldItems[] содержится удаляемый из коллекции элемент;
                    Console.WriteLine("Удален объект: {0}", oldFigure.Type);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    GeomFigure replacedFigure = e.OldItems[0] as GeomFigure;
                    GeomFigure replacingFigure = e.NewItems[0] as GeomFigure;
                    Console.WriteLine("Объект {0} заменен объектом {1}", replacedFigure.Type, replacingFigure.Type);
                    break;
            }
        }
    }
}