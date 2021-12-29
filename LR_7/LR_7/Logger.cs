using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Logger
{

    /* класс поддержки логирования событий и информации исключений */

    public string LogData;  // данные для логирования - строка события

    public Logger() // конструктор
    {
        LogData = "";
    }

    public string build_log_data(string evt_str, char evt_type)
    {

        /* метод конструирует и возвращает строку события для записи в журнал
        evt_str - информационная строка события
        evt_type - тип данных события : 'I' - Information, 'E' - error, 'U' - uncknown
        */

        string result_str = "";

        // формат записи журнала на примере : 27.10.2019 02:36, INFO: Test log message.

        result_str = "\n" + DateTime.Now.ToString() + ", ";
        if (evt_type == 'I') result_str += "INFO: ";
        else if (evt_type == 'E') result_str += "ERROR: ";
        else if (evt_type == 'U') result_str += "UNCKNOWN EVENTTYPE: ";
        result_str += evt_str;

        return result_str;

    }

    public virtual void LogEvent(string evt_str, char evt_type)
    {

        /* записывает информацию события в строковый объект
         evt_str - информационная строка события
         evt_type - тип данных события : 'I' - Information, 'E' - error, 'U' - uncknown
         */

        LogData = build_log_data(evt_str, evt_type);

    }

}

public class ConsoleLogger : Logger
{

    /* логгер, выводящий сообщения на консоль */

    public ConsoleLogger() : base() // конструктор
    {
    }

    public override void LogEvent(string evt_str, char evt_type)
    {

        /* выводит информацию события в консоль
         evt_str - информационная строка события
         evt_type - тип данных события : 'I' - Information, 'E' - error, 'U' - uncknown
         */

        LogData = build_log_data(evt_str, evt_type);

        Console.WriteLine(LogData);

    }

}

public class FileLogger : Logger
{

    /* логгер, выводящий сообщения в файл на диске */

    string file_name = "LOG.TXT";

    public FileLogger() : base() // конструктор
    {
    }

    public override void LogEvent(string evt_str, char evt_type)
    {

        /* выводит информацию события в файл на диске
         evt_str - информационная строка события
         evt_type - тип данных события : 'I' - Information, 'E' - error, 'U' - uncknown
         */

        LogData = build_log_data(evt_str, evt_type);

        // добавляем информацию в файл
        using (StreamWriter f = new StreamWriter(file_name, true, Encoding.GetEncoding(1251)))
        {
            f.Write(LogData);
        }

    }

}