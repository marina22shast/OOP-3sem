using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed partial class Address
{
    public void GetInfo()
    {
        /* вывод информации об адресе на консоль */

        Console.WriteLine("Адрес : город {0} улица {1} дом {2} кв. {3}", City, Street, HouseNumber, AppartmentNumber);


    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Адрес : город " + City + " улица " + Street + " дом " + HouseNumber.ToString() + " кв. " + AppartmentNumber.ToString();

        return objinfo;

    }

}
