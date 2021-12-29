using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

/* Управляющий класс-Контроллер. */
public static class BankController
{

    public static void SearchAccount(Bank bank, string acc)
    {

        /* поиск счета в банке - по всему реестру клиентских персон */

        bool is_found = false;
        foreach (ThePerson P in bank.Persons) // по списку персон
        {
            if (((TheClient)P).AccTotal.AccountNumber == acc ||
                 ((TheClient)P).AccCumul.AccountNumber == acc ||
                 ((TheClient)P).AccCurr.AccountNumber == acc ||
                 ((TheClient)P).AccSettl.AccountNumber == acc
                 )
            {
                Console.WriteLine("\nИСКОМЫЙ СЧЕТ ОБНАРУЖЕН - КЛИЕНТСКИЙ ПРОФИЛЬ ВЛАДЕЛЬЦА :\n");

                ((TheClient)P).GetInfo();

                is_found = true;

                break;
            }


        }

        if (!is_found) Console.WriteLine("\nИСКОМЫЙ СЧЕТ НЕ ОБНАРУЖЕН.");

    }

    public static void SortAccounts(Bank bank)
    {

        /* выводит счета реестра клиентских персон в отсортированном порядке */

        List<string> acc_list = new List<string>(); // сохраним в него все счета реестра

        foreach (ThePerson P in bank.Persons) // по списку персон
        {

            acc_list.Add(((TheClient)P).AccTotal.AccountNumber);
            acc_list.Add(((TheClient)P).AccCumul.AccountNumber);
            acc_list.Add(((TheClient)P).AccCurr.AccountNumber);
            acc_list.Add(((TheClient)P).AccSettl.AccountNumber);

        }

        acc_list.Sort(); // сортировка

        Console.WriteLine("\nСЧЕТА РЕЕСТРА КЛИЕНТСКИХ ПЕРСОН (В ОТСОРТИРОВАННОМ ПОРЯДКЕ) :\n");
        foreach (string Acc in acc_list) Console.WriteLine(Acc);

    }

    public static void ClientAmount(Bank bank, string fio)
    {

        /* вычисляет и выводит на консоль общую сумму по НЕЗАБЛОКИРОВАННЫМ счетам заданного клиента */

        double TotalAmount = 0; // общая сумма

        foreach (ThePerson P in bank.Persons) // по списку персон
        {
            if (((TheClient)P).Fio == fio) // клиент обнаружен в реестре
            {

                if (((TheClient)P).AccTotal.IsLocked == false) TotalAmount += ((TheClient)P).AccTotal.AccountBalance;
                if (((TheClient)P).AccCumul.IsLocked == false) TotalAmount += ((TheClient)P).AccCumul.AccountBalance;
                if (((TheClient)P).AccCurr.IsLocked == false) TotalAmount += ((TheClient)P).AccCurr.AccountBalance;
                if (((TheClient)P).AccSettl.IsLocked == false) TotalAmount += ((TheClient)P).AccSettl.AccountBalance;

            }

        }

        Console.WriteLine("\nОБЩАЯ СУММА ПО НЕЗАБЛОКИРОВАННЫМ СЧЕТАМ КЛИЕНТА {0} = {1}\n", fio, TotalAmount);

    }

    public static void AccAmount(Bank bank)
    {

        /* Вычисление суммы по всем счетам, имеющим положительный и отрицательный балансы отдельно. */

        double TotalAmountPositiveBal = 0; // общая сумма по всем счетам, имеющим положительный баланс
        double TotalAmountNegativeBal = 0; // общая сумма по всем счетам, имеющим отрицательный баланс

        foreach (ThePerson P in bank.Persons) // по списку персон
        {
            if (((TheClient)P).AccTotal.AccountBalance >= 0) TotalAmountPositiveBal += ((TheClient)P).AccTotal.AccountBalance;
            else TotalAmountNegativeBal += ((TheClient)P).AccTotal.AccountBalance;

            if (((TheClient)P).AccCumul.AccountBalance >= 0) TotalAmountPositiveBal += ((TheClient)P).AccCumul.AccountBalance;
            else TotalAmountNegativeBal += ((TheClient)P).AccCumul.AccountBalance;

            if (((TheClient)P).AccCurr.AccountBalance >= 0) TotalAmountPositiveBal += ((TheClient)P).AccCurr.AccountBalance;
            else TotalAmountNegativeBal += ((TheClient)P).AccCurr.AccountBalance;

            if (((TheClient)P).AccSettl.AccountBalance >= 0) TotalAmountPositiveBal += ((TheClient)P).AccSettl.AccountBalance;
            else TotalAmountNegativeBal += ((TheClient)P).AccSettl.AccountBalance;

        }

        Console.WriteLine("\nОБЩАЯ СУММА ПО ВСЕМ СЧЕТАМ, ИМЕЮЩИМ ПОЛОЖИТЕЛЬНЫЙ БАЛАНС = {0}", TotalAmountPositiveBal);
        Console.WriteLine("ОБЩАЯ СУММА ПО ВСЕМ СЧЕТАМ, ИМЕЮЩИМ ОТРИЦАТЕЛЬНЫЙ БАЛАНС = {0}\n", TotalAmountNegativeBal);
    }

    public static void LoadFromTEXTFile(Bank bank, string fname)
    {

        /* метод, инициализирующий реестр персон банк данными из текстового файла */

        // загрузим данные из файла в список
        List<string> pers_list = File.ReadAllLines(fname, System.Text.Encoding.Default).ToList();

        //Console.WriteLine("\nСОДЕРЖИМОЕ ФАЙЛА {0} :\n", fname);
        //foreach (string Pers in pers_list) Console.WriteLine(Pers);

        string Fio = pers_list.ElementAt(0);
        int Age = int.Parse(pers_list.ElementAt(1));
        char Gender = char.Parse(pers_list.ElementAt(2));
        string City = pers_list.ElementAt(3);
        string Street = pers_list.ElementAt(4);
        int HouseNumber = int.Parse(pers_list.ElementAt(5));
        int AppartmentNumber = int.Parse(pers_list.ElementAt(6));

        string AccountNumberCumul = pers_list.ElementAt(7);
        double AccountBalanceCumul = double.Parse(pers_list.ElementAt(8));
        int DepPercent = int.Parse(pers_list.ElementAt(9));

        string AccountNumberCur = pers_list.ElementAt(10);
        double AccountBalanceCur = double.Parse(pers_list.ElementAt(11));
        string CurrenceCode = pers_list.ElementAt(12);

        string AccountNumberSettl = pers_list.ElementAt(13);
        double AccountBalanceSettl = double.Parse(pers_list.ElementAt(14));
        string Company = pers_list.ElementAt(15);

        string AccountNumberTot = pers_list.ElementAt(16);
        double AccountBalanceTot = double.Parse(pers_list.ElementAt(17));
        int OwnersQtt = int.Parse(pers_list.ElementAt(18));

        string CardNumberDebet = pers_list.ElementAt(19);
        string PinCodeEncryptedDebet = pers_list.ElementAt(20);
        int DailyOpersLimt = int.Parse(pers_list.ElementAt(21));

        string CardNumberCredit = pers_list.ElementAt(22);
        string PinCodeEncryptedCredit = pers_list.ElementAt(23);
        int CreditAmount = int.Parse(pers_list.ElementAt(24));

        bank.Add(new TheClient(Fio,
                               Age,
                               Gender,
                               City,
                               Street,
                               HouseNumber,
                               AppartmentNumber,
                               AccountNumberCumul,
                               AccountBalanceCumul,
                               DepPercent,
                               AccountNumberCur,
                               AccountBalanceCur,
                               CurrenceCode,
                               AccountNumberSettl,
                               AccountBalanceSettl,
                               Company,
                               AccountNumberTot,
                               AccountBalanceTot,
                               OwnersQtt,
                               CardNumberDebet,
                               PinCodeEncryptedDebet,
                               DailyOpersLimt,
                               CardNumberCredit,
                               PinCodeEncryptedCredit,
                               CreditAmount
                               ));

    }

    public static void LoadFromJSONFile(Bank bank, string fname)
    {

        /* метод, инициализирующий реестр персон банк данными из JSON-файла */

        using (StreamReader r = new StreamReader(fname))
        {
            string json = r.ReadToEnd();
     

            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                string Fio = item.Fio;
                int Age = item.Age;
                char Gender = item.Gender;
                string City = item.City;
                string Street = item.Street;
                int HouseNumber = item.HouseNumber;
                int AppartmentNumber = item.AppartmentNumber;

                string AccountNumberCumul = item.AccountNumberCumul;
                double AccountBalanceCumul = item.AccountBalanceCumul;
                int DepPercent = item.DepPercent;

                string AccountNumberCur = item.AccountNumberCur;
                double AccountBalanceCur = item.AccountBalanceCur;
                string CurrenceCode = item.CurrenceCode;

                string AccountNumberSettl = item.AccountNumberSettl;
                double AccountBalanceSettl = item.AccountBalanceSettl;
                string Company = item.Company;

                string AccountNumberTot = item.AccountNumberTot;
                double AccountBalanceTot = item.AccountBalanceTot;
                int OwnersQtt = item.OwnersQtt;

                string CardNumberDebet = item.CardNumberDebet;
                string PinCodeEncryptedDebet = item.PinCodeEncryptedDebet;
                int DailyOpersLimt = item.DailyOpersLimt;

                string CardNumberCredit = item.CardNumberCredit;
                string PinCodeEncryptedCredit = item.PinCodeEncryptedCredit;
                int CreditAmount = item.CreditAmount;

                bank.Add(new TheClient(Fio,
                                       Age,
                                       Gender,
                                       City,
                                       Street,
                                       HouseNumber,
                                       AppartmentNumber,
                                       AccountNumberCumul,
                                       AccountBalanceCumul,
                                       DepPercent,
                                       AccountNumberCur,
                                       AccountBalanceCur,
                                       CurrenceCode,
                                       AccountNumberSettl,
                                       AccountBalanceSettl,
                                       Company,
                                       AccountNumberTot,
                                       AccountBalanceTot,
                                       OwnersQtt,
                                       CardNumberDebet,
                                       PinCodeEncryptedDebet,
                                       DailyOpersLimt,
                                       CardNumberCredit,
                                       PinCodeEncryptedCredit,
                                       CreditAmount
                                       ));

            }
        }
      
    }

    
}