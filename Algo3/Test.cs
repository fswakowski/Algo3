﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    class Test
    { 

        public void PrintVector(double[] vector)
        {
            for (var i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }

        public double[] GenerateVector(int size)
        {
            double[] vector = new double[size];

            for (int i = 0; i < size-1; i++)
            {
                vector[i] = 0.0;
            }

            vector[size-1] = 1.0;

            return vector;
        }

        public void GaussPartialPivotTest(int numberOfAgents, int count)
        {
            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);

            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            MyMatrix<double> macierzKopia = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];
            double[] wektorKopia = new double[mg.size];

            //przygotowanie macierzy i wektorów
            macierz = macierzKopia = mg.GenerateMatrix();
            wektor = wektorKopia = GenerateVector(mg.size);

            macierz.PrintMatrix();
            Console.WriteLine();
            macierzKopia.PrintMatrix();

            //liczenie czasu
            //double[] czasy = new double[count];
            //double suma = 0.0;
            //double srednia = 0.0;

            //for (int i = 0; i < count; i++)
            //{
            //    var watchDouble = Stopwatch.StartNew();
            macierz.GaussPartialPivot(wektor);
            macierz.PrintMatrix();
            Console.WriteLine();
            macierzKopia.PrintMatrix();
            //    watchDouble.Stop();
            //    var elapsedMsDouble = watchDouble.ElapsedMilliseconds;
            //    czasy[i] = elapsedMsDouble;

            //    for (var j = 0; j < macierz.Rows(); j++)
            //    {
            //        for (var k = 0; k < macierz.Columns(); k++)
            //        {
            //            macierz[j, k] = macierzKopia[j, k];
            //            wektor[j] = wektorKopia[j];
            //        }
            //    }
            //    suma += czasy[i];
            //}

            //srednia = suma / count;

            //StreamWriter writer = new StreamWriter("CzasGaussPartialPivot.csv", append: true);
            //if (writer != null)
            //{
            //    writer.WriteLine(String.Format(mg.size + ";" + srednia + ";"));
            //}
            //writer.Close();

            //Console.WriteLine("Średni czas GaussPartialPivot: " + srednia + "ms");
        }
    }
}
