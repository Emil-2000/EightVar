using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightVar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - создание матрицы графа вручную");
            Console.WriteLine("2 - генерация матрицы графа случайно");
            int Inp = 0;
            do
            {
                Inp = helper.CheckInput(true, true);
                if (Inp == 1 || Inp == 2)
                    break;
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите 1 либо 2");
                }
            } while (true);
            if (Inp == 1)
            {
                GraphMatrix NewMatrix = GraphMatrix.ManualCreate();
                Console.WriteLine("Вы создали граф в виде матрицы связанности:");
                NewMatrix.Show();

                int Comp = NewMatrix.ComponentConnected();
                Console.WriteLine("Вычисление компонента связанности графа: " + Comp);
            }
            else
            {
                Console.WriteLine("Введите количество вершин графа:");
                Inp = helper.CheckInput(true, true);
                GraphMatrix NewMatrix = GraphMatrix.MatrixGenerator(Inp);
                Console.WriteLine("Вы создали граф в виде матрицы связанности:");
                NewMatrix.Show();
                int Comp = NewMatrix.ComponentConnected();
                Console.WriteLine("Вычисление компонента связанности графа: " + Comp);
            }
            Console.ReadLine();
        }
    }
}
