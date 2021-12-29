using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GeomFigure
{
    public string Type; // разновидность фигуры (прямоугольник, ромб, квадрат, круг, эллипс и т.д.)
    public double SurfArea; // площадь поверхности
    public double Volume; // объем

    public GeomFigure(string var_type, double var_sarea, double var_volume) // конструктор
    {
        Type = var_type;
        SurfArea = var_sarea;
        Volume = var_volume;
    }

    public string GetInfo()
    {
        // метод выводит на консоль и возвращает полную информацию о геометрической фигуре

        String ret_val = "Фигура " + Type + " : площадь поверхности (см2) " + SurfArea + " , объем (см3) " + Volume;

        Console.WriteLine(ret_val);

        return ret_val;

    }

}