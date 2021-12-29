using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UpgradeEventArgs  // класс поддержки информации о событии Upgrade (запрос на обновление ПО)
{

    // автоматические свойства
    public string Message { get; set; } // информационное cообщение

    public int Version { get; set; } // версия, на которую требуется обновление версии ПО

    public UpgradeEventArgs(string mes, int ver) // конструктор
    {
        Message = mes;
        Version = ver;
    }

}
public class WorkEventArgs  // класс поддержки информации о событии Work (запрос на запуск ПО)
{

    // автоматические свойства
    public string Message { get; set; } // информационное cообщение

    public string WorkDate { get; set; } // дата-время запроса на запуск ПО

    public WorkEventArgs(string mes, string workdate) // конструктор
    {
        Message = mes;
        WorkDate = workdate;
    }

}