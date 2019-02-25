using System;
using System.Collections.Generic;
using System.Text;

namespace TaD_Variant15
{
   
    class CalculationPolynomial
    {
        
        private static double GetResultCalculationPolynomial(List<PolynomialAsArr.ElementOfPolynomial> oneArrayOfPolynomial, double x, List<PolynomialAsArr.ElementOfPolynomial> twoArrayOfPolynomial, double y)//Надо подумать что будет входными данными для вычисления (два многочлена)
        {
            double resultPolynomial = 0;
            //Необходимо сложить два многочлена 
            // Функция вычисления значения выражения (P(x)*Q(y)-(P(Q(x+y))
            //Для вычисления полинома 
            resultPolynomial = GetValuePolynomial(oneArrayOfPolynomial, x) * GetValuePolynomial(twoArrayOfPolynomial, y) - GetValuePolynomial(oneArrayOfPolynomial, GetValuePolynomial(twoArrayOfPolynomial, x + y));
            return resultPolynomial;
        }

        private static double GetValuePolynomial(List<PolynomialAsArr.ElementOfPolynomial> arrayOfPolynomial, double variable)
        { // Функция возвращает значение полинома 
            double resultValue = 0;
            for (int i = 0; i < arrayOfPolynomial.Count; i++)
            {
                resultValue += arrayOfPolynomial[i].Multi * Math.Pow(variable, arrayOfPolynomial[i].Degree);
            }
            return resultValue;
        }
        public static double MenuEnter()
        {
            Console.WriteLine("Данная программа вычисляет значение выражения многочленов (P(x)*Q(y)-(P(Q(x+y))");
            Console.WriteLine("Пример ввода данных: 3x5-4x6 - где 3 - число, x - переменная, 5 - степень. Другие способы ввода могут привести к ошибке!");

            PolynomialAsArr P = new PolynomialAsArr();
            List < PolynomialAsArr.ElementOfPolynomial > Plist = P.CreatePolynomial();

            PolynomialAsArr Q = new PolynomialAsArr();
            List<PolynomialAsArr.ElementOfPolynomial> Qlist = Q.CreatePolynomial();

            return GetResultCalculationPolynomial(Plist, P.Variable, Qlist, Q.Variable);
            
        }
    }
}
