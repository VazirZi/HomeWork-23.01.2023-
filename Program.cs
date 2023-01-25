using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void FillArray(double[ , ] arrayRealNumbers)         // Заполнение массива вещественными числами
        {
            Random rand = new Random();
            
            for (int i = 0; i < arrayRealNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < arrayRealNumbers.GetLength(1); j++)
                {
                    arrayRealNumbers[i, j] = rand.Next(-9, 10);
                }
            }
        }

        static void FillArray(int[ , ] arrayIntNumbers)              // Заполнение массива целыми числами
        {
            Random rand = new Random();
            
            for (int i = 0; i < arrayIntNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < arrayIntNumbers.GetLength(1); j++)
                {
                    arrayIntNumbers[i, j] = rand.Next(1, 10);
                }
            }
        }

        static void PrintArray(double[ , ] arrayRealNumbers)        // Вывод массива вещественных чисел
        {
            for (int i = 0; i < arrayRealNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < arrayRealNumbers.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0, 5}", arrayRealNumbers[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintArray(int[ , ] arrayIntNumbers)            // Вывод массива целых чисел
        {
            for (int i = 0; i < arrayIntNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < arrayIntNumbers.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0, 5}", arrayIntNumbers[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int EnterNumber (string str)                         // Ввод значений в консоль
        {
            Console.Write(str);
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return number;
        }

        static void FindElement(int[ , ] arrayIntNumbers, int iPosition, int jPosition) // Поиск элемента по заданным позициям
        {
            bool isFind = true;

            for (int i = 0; i < arrayIntNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < arrayIntNumbers.GetLength(1); j++)
                {
                    if (i == iPosition && j == jPosition)
                    {
                        Console.WriteLine("Число по заданным позициям = " + arrayIntNumbers[i, j]);
                        Console.WriteLine();
                        return;
                    }
                    else isFind = false;
                }
            }
            if (isFind == false) Console.WriteLine("Такого числа нет в массиве...");
            Console.WriteLine();
        }

        static void FindArithmeticMeanOnEachColumn(int[ , ] arrayIntNumbers)      // Нахождение среднего арифметического в каждом столбце
        {
            double arithmeticMean = 0;
            double sum = 0;

            for (int j = 0; j < arrayIntNumbers.GetLength(1); j++)
            {
                for (int i = 0; i < arrayIntNumbers.GetLength(0); i++)
                {
                    sum+= arrayIntNumbers[i, j];
                }
                arithmeticMean = sum / (arrayIntNumbers.GetLength(0));

                Console.Write($"Среднее арифметическое {j} столбца = ");
                Console.WriteLine("{0:0.0}", arithmeticMean);

                arithmeticMean = 0;
                sum = 0;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Clear();

            // Задача 1. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
            // m = 3, n = 4.

            double[ , ] arrayRealNumbers = new double[3, 4];

            FillArray(arrayRealNumbers);
            PrintArray(arrayRealNumbers);

            // Задача 2. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
            // и возвращает значение этого элемента или же указание, что такого элемента нет.

            int[ , ] arrayIntNumbers = new int[3, 4];

            FillArray(arrayIntNumbers);
            PrintArray(arrayIntNumbers);

            Console.WriteLine("Введите позиции элемента в массиве:");
            int iPosition = EnterNumber("Введите индекс строки: ");
            int jPosition = EnterNumber("Введите индекс столбца: ");

            FindElement(arrayIntNumbers, iPosition, jPosition);

            // Задача 3. Задайте двумерный массив из целых чисел. Найдите 
            // среднее арифметическое элементов в каждом столбце.

            FindArithmeticMeanOnEachColumn(arrayIntNumbers);
        }
    }
}