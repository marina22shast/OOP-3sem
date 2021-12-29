using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// определим делегат на метод, который (метод) принимает параметром строку и не возвращает значение
public delegate void PrintUserInfo(string some_user_info);

public class SoftWareUser // класс Пользователь (программного обеспечения)
{
    // автоматические свойства
    public string UserName { get; set; } // имя пользователя
    public string Password { get; set; } // пароль
    public string Position { get; set; } // должность

    public SoftWareUser(string var_name, string var_pwd, string var_pos)
    {
        UserName = var_name;
        Password = var_pwd;
        Position = var_pos;
    }

    public delegate void UpgradeHandler(object sender, UpgradeEventArgs e); // делегат поддержки события UpgradeNotify

    public event UpgradeHandler UpgradeNotify; // событие 'Запрос на обновление ПО'

    public void DoUpgrade(int var_ver) // метод, инициирующий Upgrade и соответственно событие UpgradeNotify
    {

        Console.WriteLine("\n\nПользователь запрашивает обновление версии ПО!\n");

        // если событие (событие это делегат) указывает на методы, тоесть можем сказать, что на событие кто-то подписался, то осуществляем срабатывание события - вызываем его
        if (UpgradeNotify != null) UpgradeNotify(this, new UpgradeEventArgs("требуется обновление версии", var_ver));

    }

    public delegate void WorkHandler(object sender, WorkEventArgs e); // делегат поддержки события WorkNotify

    public event WorkHandler WorkNotify; // событие 'Запрос на запуск ПО'

    public void DoWork() // метод, инициирующий Work и соответственно событие WorkNotify
    {

        Console.WriteLine("\nПользователь запрашивает запуск ПО!\n");

        // если событие (событие это делегат) указывает на методы, тоесть можем сказать, что на событие кто-то подписался, то осуществляем срабатывание события - вызываем его
        if (WorkNotify != null) WorkNotify(this, new WorkEventArgs("требуется запуск ПО", DateTime.Now.ToString("HH:mm:ss yy-MM-dd")));

    }

    public void GetUserFullInfo()
    {
        // метод выводит на консоль полную информацию о Пользователе

        // объявим переменные делегата PrintUserInfo
        // используем Лямбда-выражения
        PrintUserInfo PrintName = (string fio) => Console.WriteLine("Пользователь : {0}", fio);
        PrintUserInfo PrintPassword = (string pwd) => Console.WriteLine("пароль : {0}", pwd);
        PrintUserInfo PrintPosition = (string pos) => Console.WriteLine("должность : {0}", pos);

        PrintName(UserName);
        PrintPassword(Password);
        PrintPosition(Position);

    }

}