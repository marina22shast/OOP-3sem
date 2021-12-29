using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Карта дебетовая */

public class PayCardDebet : PayCard
{

    public int DailyOpersLimt; // суточный лимит операций (кол-во платежей в сутки разрешенное)

    public PayCardDebet() : base() // конструктор
    {
        DailyOpersLimt = 99; // лимит в 99 операций списания по умолчанию

    }

    public PayCardDebet(string CNum, string Pin, int MaxOperNum) : base(CNum, Pin) // конструктор
    {
        DailyOpersLimt = MaxOperNum;

    }

    public new void GetInfo()
    {
        /* вывод информации о дебетовой карте на консоль */

        Console.WriteLine("Платежная дебетовая карта : номер {0} пин в зашифрованном виде : {1} \n       дата регистрации в системе : {2} категория : {3} суточный лимит операций - {4}", CardNumber, PinCodeEncrypted, RegInfo.RegDate, Category, DailyOpersLimt);

    }
    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Дебетовая платежная карта : номер " + CardNumber + " пин в зашифрованном виде " + PinCodeEncrypted + " суточный лимит операций - " + DailyOpersLimt.ToString();

        return objinfo;

    }

}