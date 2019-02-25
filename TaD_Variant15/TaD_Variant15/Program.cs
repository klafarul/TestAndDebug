using System;
using System.Collections.Generic;

namespace TaD_Variant15
{
    /* 
        + Данными программы являются линейные многочлены n-ой степени. 
        + Каждый член многочлена представлен элементом массива, содержащим коэффициент и степень. 
        + В обрабатываемом многочлене могут присутство-вать не все члены (например, 3x5+2x4+5x2+7). 
         Написать функцию вычис-ления значения многочлена.
         Вычислить значение выражения (P(x)*Q(y)-(P(Q(x+y)).
    */
    class Program
    {
     

        static void Main(string[] args)
        {

            //Ввод пользователем многочлена
            //      string enterUser = "3x5+2x4-5x2+7";
            // Функция создания многочлена с помощью массива
            //      List<Polynomial> arrayOfPolynomial = CreatePolynomial(enterUser);
            Console.WriteLine("Ответ: ");
            Console.WriteLine(CalculationPolynomial.MenuEnter());
        }

    }
}
