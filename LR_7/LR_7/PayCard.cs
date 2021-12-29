using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Платежная карта */

public class PayCard
{

    public struct RegistrationInfo // информации о регистрации счета
    {
        public String Organization;    // организация принадлежности карты
        public String RegDate;         // дата регистрации счета в системе
    };

    public enum BankingCategory   // банковская категория объекта
    {
        Low = 1,
        Middle,    // 2
        High = 9,
        SuperHigh  // 10
    }

    public string CardNumber;       // номер карты
    public string PinCodeEncrypted; // пин код карты (зашифрованное значение)
    public RegistrationInfo RegInfo; // данные о регистрации карты
    public BankingCategory Category;

    public PayCard() // конструктор
    {
        CardNumber = "";
        PinCodeEncrypted = "";

        RegInfo.Organization = "Банк TrustCapital";
        RegInfo.RegDate = DateTime.Today.ToString(); // присваиваем текущую дату
        Category = BankingCategory.High; // присваиваем категорию

    }

    public PayCard(string CNum, string Pin) // конструктор
    {
        // проверка основных параметров платежной карты на валидность

        foreach (char c in CNum)
        {
            if (!Char.IsDigit(c) && c != '-') // валидный формат карты "XXX-XXXX-XXXX-XXX"
            {
                throw new PayCardException("Отказ в регистрации карты - НОМЕР КАРТЫ может содержать только цифры и символ '-'", CNum);
            }
        }

        if (Pin.Length != 4)
        {

            throw new PayCardException("Отказ в регистрации карты - зашифрованное значение PIN не соответствует формату (требование размерности).", Pin);

        }

        CardNumber = CNum;
        PinCodeEncrypted = Pin;

        RegInfo.Organization = "Банк TrustCapital";
        RegInfo.RegDate = DateTime.Today.ToString(); // присваиваем текущую дату
        Category = BankingCategory.High; // присваиваем категорию

    }

    public void GetInfo()
    {
        /* вывод информации о платежной карте на консоль */

        Console.WriteLine("Платежная карта : номер {0} пин в зашифрованном виде : {1} дата регистрации в системе : {2} категория : {3}", CardNumber, PinCodeEncrypted, RegInfo.RegDate, Category);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Платежная карта : номер " + CardNumber + " пин в зашифрованном виде " + PinCodeEncrypted;

        return objinfo;

    }

}