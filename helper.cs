using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightVar
{
    class helper
    {
        /// <summary>
        /// Метод ответственный за контроль ввода целых значений с клавиатуры
        /// </summary>
        /// <param name="OnlyPositive">Проверять на положительные значения</param>
        /// <param name="ExceptZero">Проверять на ноль</param>
        /// <returns></returns>
        public static int CheckInput(bool OnlyPositive = false, bool ExceptZero = false)
        {
            int resultat = 0;
            bool ok = false;
            do
            {
                string InputetString = Console.ReadLine();
                try
                {
                    resultat = Convert.ToInt32(InputetString);
                    ok = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода!!! Необходимо ввести целое число!!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Повторите ввод");
                    ok = false;
                }
                if (ok == true)
                {
                    // проверим условия заданные в параметрах метода
                    if (OnlyPositive)
                    {
                        if (resultat < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка !!! Необходимо ввести целое положительное значение!!!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Повторите ввод");
                            ok = false;
                        }
                    }
                    if (ExceptZero)
                    {
                        if (resultat == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка !!! Значение не должно равняться нулю!!!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Повторите ввод");
                            ok = false;
                        }
                    }
                }
            } while (ok == false);
            return resultat;
        }
    }
}
