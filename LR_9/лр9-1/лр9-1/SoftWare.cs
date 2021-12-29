using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Software // класс Программное Обеспечение (ПО)
{

    // автоматические свойства
    public string Name { get; set; } // наименование ПО
    public int Version { get; set; } // номер версии

    public bool State; // состояние ПО - true если работает в данный момент и false в противном случае
    public Software(string name, int ver) // конструктор
    {
        Name = name;
        Version = ver;
        State = false;
    }

    public void OnUpgrade(object sender, UpgradeEventArgs e)
    {
        /* обработчик события Upgrade */

        Console.WriteLine("{0} : получен запрос от пользователя на обновление- {1} - произвожу обновление до версии {2}", this.Name, e.Message, e.Version);

        // По скачивате обновления требуемой версии и обновляется

        Version = e.Version; // актуализируем номер версии ПО
    }

    public void OnWork(object sender, WorkEventArgs e)
    {
        /* обработчик события Work */

        Console.WriteLine("{0} : получен запрос от пользователя на запуск - {1} - стартую в : {2}", this.Name, e.Message, e.WorkDate);

        // По запускается

        State = true; // актуализируем флаг состояния ПО - "ПО работает"
    }
    public void PrnSoftInfo()
    {
        // метод выводит на консоль полную информацию о ПО

        Console.Write("ПО : " + Name + " текущая версия : " + Version + " текущее состояние : " + (State ? "работает\n" : "остановлено\n"));
    }

}