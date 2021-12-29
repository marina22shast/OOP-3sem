using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Клиент */
public class TheClient : ThePerson, IFio
{

    public Address ClientAddress;      // адрес клиента
    public AccountCumulative AccCumul; // накопительный счет
    public AccountCurrency AccCurr;    // валютный счет
    public AccountSettlement AccSettl; // расчетный счет
    public AccountTotal AccTotal;      // общий счет
    public PayCardDebet CardDebet;      // дебетовая карта
    public PayCardCredit CradCredit;   // кредитная карта

    public TheClient(string theFio, int theAge, char theGender,                  // реквизиты Персоны (ФИО, возраст, пол)
              string City, string Street, int HouseNumber, int AppartmentNumber, // адрес
              string AccNumberCumul, double AccBallanceCumul, int PercentVal,    // накопительный счет клиента
              string AccNumberCurr, double AccBallanceCurr, string CurrCode,     // валютный счет клиента
              string AccNumberSettl, double AccBallanceSettl, string FirmName,   // расчетный счет клиента
              string AccNumberTotal, double AccBallanceTotal, int Owners,        // общий счет клиента
              string CNumDebet, string PinDebet, int MaxOperNum,                 // дебетовая карта
              string CNumCredit, string PinCredit, int CredAmt                   // кредитная карта
        ) : base(theFio, theAge, theGender)
    {
        // регистрируем клиента в системе (банковской)
        ClientAddress = new Address(City, Street, HouseNumber, AppartmentNumber);
        AccCumul = new AccountCumulative(AccNumberCumul, AccBallanceCumul, PercentVal);
        AccCurr = new AccountCurrency(AccNumberCurr, AccBallanceCurr, CurrCode);
        AccSettl = new AccountSettlement(AccNumberSettl, AccBallanceSettl, FirmName);
        AccTotal = new AccountTotal(AccNumberTotal, AccBallanceTotal, Owners);
        CardDebet = new PayCardDebet(CNumDebet, PinDebet, MaxOperNum);
        CradCredit = new PayCardCredit(CNumCredit, PinCredit, CredAmt);

    }

    public override string SayFio()
    {
        /* возвраащает ФИО клиента, метод объявлян как абстрактный в базовом классе (ThePerson), а значит мы обязаны его здесь определить  */

        string FioStr = Fio + " - вызов метода SayFio() объявленного в абстрактном классе ThePerson";

        return FioStr;
    }

    string IFio.SayFio()
    {
        /* возвраащает ФИО клиента, метод объявлян в Интерфейсе IFio и мы его определяем  */

        string FioStr = Fio + " - вызов метода SayFio() объявленного в Интерфейсе IFio";

        return FioStr;
    }

    public override void GetInfo()
    {
        /* вывод информации о клиенте на консоль */
        base.GetInfo(); // вызываем метод базового класса
        ClientAddress.GetInfo();
        AccCumul.GetInfo();
        AccCurr.GetInfo();
        AccSettl.GetInfo();
        AccTotal.GetInfo();
        CardDebet.GetInfo();
        CradCredit.GetInfo();
    }
    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = ClientAddress.ToString() + "\n" + AccCumul.ToString() + "\n" + AccCurr.ToString() + "\n" + AccSettl.ToString() + "\n" + AccTotal.ToString() + "\n" + CardDebet.ToString() + "\n" + CradCredit.ToString();

        return objinfo;

    }
}