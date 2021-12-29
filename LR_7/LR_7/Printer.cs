using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Printer
{

    public void IAmPrinting(ThePerson someobj)
    {

        string ObjInfoStr = someobj.Fio + "\n" + (someobj as TheClient).ToString() + "\n";

        Console.WriteLine(ObjInfoStr);

    }

}