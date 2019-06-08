using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightVar
{
    class GraphMatrix
    {
        /// <summary>
        /// Признак графа ориентированный или нет
        /// </summary>
        private bool OrientGraph;

        /// <summary>
        /// Массив с матрицей графа
        /// </summary>
        public int[,] Matrix;

        /// <summary>
        /// Количество элементов графа
        /// </summary>
        protected int N;

        /// <summary>
        /// Массив с использованными элементами
        /// </summary>
        protected char[] used;

        /// <summary>
        /// Ориентированный граф или нет?
        /// </summary>
        public bool IsOriented
        {
            get
            { return OrientGraph; }
        }

        /// <summary>
        /// Конструктор класса графа задаваемого матрицей
        /// </summary>
        /// <param name="Size">количетво элементов графа</param>
        public GraphMatrix(int Size, bool OrientGraph = true)
        {
            // инициализация элементов
            N = Size;
            Matrix = new int[N, N];
            used = new char[N];
            this.OrientGraph = OrientGraph;
        }

        /// <summary>
        /// Ввод матрицы графа вручню с клавиатуры
        /// </summary>
        /// <returns></returns>
        public static GraphMatrix ManualCreate()
        {
            Console.Write("Введите количество элементов графа:");
            int Size = helper.CheckInput(true, true);
            GraphMatrix retValue = new GraphMatrix(Size);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write("Введите элемент матрицы (" + i + ", " + j + " ):");
                    bool Ok = true;
                    int Inp = 0;
                    do
                    {
                        Inp = helper.CheckInput(true);
                        if (Inp == 0 || Inp == 1)
                        {
                            Ok = false;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка значение элемента может быть либо 1 либо 0. Повторите ввод!");
                        }
                    }
                    while (Ok);
                    retValue.Matrix[i, j] = Inp;
                }
            }
            return retValue;
        }

        /// <summary>
        /// Возвращает компонент связанности графа
        /// </summary>
        /// <returns></returns>
        public int ComponentConnected()
        {
            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                if(used[i] == 0)
                {
                    if (OrientGraph)
                        OrientGraphCheck(i);
                    else
                        NonOrientralGraphCheck(i);
                    cnt++;
                }
            }
            return cnt;
        }

        /// <summary>
        /// Поиск компонент связности ориентированного графа
        /// </summary>
        /// <param name="s"></param>
        protected void OrientGraphCheck(int s)
        {
            used[s] = '1';
            for (int i = 0; i < N; i++)
            {
                if (used[i] == 0 && (Matrix[s, i] == 1 || Matrix[i, s] == 1))
                {
                    OrientGraphCheck(i);
                }
            }
        }

        /// <summary>
        /// Поиск компонент связности неориентированного графа
        /// </summary>
        /// <param name="s"></param>
        protected void NonOrientralGraphCheck(int s)
        {
            for (int i = 0; i < N; i++)
            {
                if (used[i] == 0 && Matrix[s, i] == 1)
                {
                    NonOrientralGraphCheck(i);
                }
            }
        }

        /// <summary>
        /// генератор матриц смежности по заданным размерам
        /// </summary>
        /// <returns></returns>
        public static GraphMatrix MatrixGenerator(int Size)
        {
            GraphMatrix retVal = new GraphMatrix(Size);
            Random ran = new Random();
            retVal.Matrix = BuildMatrix(Size,ran);
            return retVal;
        }

        /// <summary>
        /// строит масссив матрицы смежности связанного неориентированного графа
        /// </summary>
        /// <param name="N">Количество элементов графа</param>
        /// <param name="ran">Генератор случайных чисел</param>
        /// <returns></returns>
        private static int[,] BuildMatrix(int N, Random ran)
        {
            int[,] matrix = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                // зануляем диагональ
                matrix[i, i] = 0;
                // запускаем генератор
                for (int j = i + 1; j < N; j++)
                {
                    matrix[i, j] = ran.Next(0, 2);
                    matrix[j, i] = matrix[i, j]; // обратный порядок индексов
                }
            }
            return matrix;
        }

        /// <summary>
        /// Отображение матрицы
        /// </summary>
        public void Show()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
