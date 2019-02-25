using System;
using System.Collections.Generic;
using System.Text;

namespace TaD_Variant15
{
    class PolynomialAsArr
    {
        private double variable = 0;
        public double Variable
        {
            get
            {
                return variable;
            }
        }

        public struct ElementOfPolynomial
        {
            private int multi;
            public int Multi
            {
                get
                {
                    return multi;
                }
                set
                {
                    if (value is int)
                    {
                        multi = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, multi - не число!");
                    }
                }
            }
            private int degree;
            public int Degree
            {
                get
                {
                    return degree;
                }
                set
                {
                    if (value is int)
                    {
                        degree = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, degree - не число!");
                    }
                }
            }
            public string sign;

            public string Sign
            {
                get
                {
                    return sign;
                }
                set
                {
                    if (value.GetType().BaseType is string)
                    {
                        sign = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, sing - не строка!");
                    }
                }
            }
        }
        private struct Polynomial
        {
            public string enterUserPolynomial;
            public double variable;
        }
        private static Polynomial ReadUsersString()
        {
            Polynomial enterUser = new Polynomial();
            Console.Write("Введите полином - :> ");
            enterUser.enterUserPolynomial = Console.ReadLine();
            Console.Write("Введите переменную :> ");
            enterUser.variable = int.Parse(Console.ReadLine());
            return enterUser;
        }
        public List<ElementOfPolynomial> CreatePolynomial()
        {
            //Ввод полинома и переменной
            Polynomial pInfo = ReadUsersString();
            //Сохраним все знаки в массиве
            List<String> arrayOfSign = arrayOfSing(pInfo.enterUserPolynomial);
            //Сохраним переменную в классе
            variable = pInfo.variable;
            //Разделим строку на подстроки: Например 3x5+4x6 -> Подстроки: 3x5 и 4x6
            string[] subStrings = pInfo.enterUserPolynomial.Split('-', '+');
            return GetArrayOfDegree(arrayOfSign, subStrings); ;
        }
        private static List<String> arrayOfSing(string enterUser)
        {
            List<String> arrayOfSign = new List<String>();
            for (int i = 0; i < enterUser.Length; i++)
            {
                if (enterUser[i] == '+')
                {
                    arrayOfSign.Add("+");
                }
                if (enterUser[i] == '-')
                {
                    arrayOfSign.Add("-");
                }
            }
            return arrayOfSign;
        }
        private static List<ElementOfPolynomial> GetArrayOfDegree(List<String> arrayOfSign, string[] subStrings)
        {
            List<ElementOfPolynomial> arrayOfDegree = new List<ElementOfPolynomial>();
            //Сначала необходимо понять, для каждой ли подстроки хватает знака
            if (arrayOfSign.Count < subStrings.Length)
            {
                arrayOfSign.Insert(0, "+");
            }
            if (arrayOfSign.Count != subStrings.Length)
            {
                Console.WriteLine("Ошибка!!!");
            }
            for (int i = 0; i < subStrings.Length; i++)
            {
                // Для каждой подстроки создадим элемент и добавим его в массив элементов
                arrayOfDegree.Add(GetElemOfArrayPolynomial(arrayOfSign[i], subStrings[i]));
            }
            return arrayOfDegree;
        }

        private static ElementOfPolynomial GetElemOfArrayPolynomial(string stringSign, string subString)
        {
            bool flag = true;
            ElementOfPolynomial ElemArray = new ElementOfPolynomial();
            ElemArray.Multi = 0;
            ElemArray.Degree = 0;
            ElemArray.sign = stringSign;//Запишем знак
            for (int i = 0; i < subString.Length; i++)
            {

                if (char.IsDigit(subString[i]) && flag == true)//Запишем в элемент массива множитель
                {
                    ElemArray.Multi = ElemArray.Multi * 10 + Convert.ToInt32(subString[i]) - 48;
                }
                if (char.IsDigit(subString[i]) && flag == false)//Запишем в элемент массива степень
                {
                    ElemArray.Degree = ElemArray.Degree * 10 + Convert.ToInt32(subString[i]) - 48;
                }
                if (!char.IsDigit(subString[i]))//Переключим флаг
                {
                    flag = false;
                }
            }
            return ElemArray;
        }
    }
}
