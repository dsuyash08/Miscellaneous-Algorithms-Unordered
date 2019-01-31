using System;
using System.Collections.Generic;
namespace Gaussian_Elemination
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            decimal[,] inputs = new decimal[input, 5];
            for (int i = 0; i < input; i++)
            {

                string[] temp = Console.ReadLine().Split();
                for (int j = 0; j < 5; j++)
                    inputs[i, j] = decimal.Parse(temp[j]);
            }calcElemination zbb
            calcElemination(inputs, input, 5);
            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    if (Math.Round(inputs[i, j], 10) != 0)
                    {
                        Console.Write(inputs[i, input] + " ");
                        break;
                    }
                }
            }
            Console.Read();
        }

        static void calcElemination(decimal[,] inputs, int input, int vars)
        {
            int k = 0;
            for (int i = 0; i < vars - 1; i++)
            {
                int pivot = getPivot(inputs, input, i, k);
                if (pivot != -1)
                {
                    if (pivot != k)
                        swaprow(inputs, k, pivot, input);
                    convertUnit(inputs, i, k, vars - 1);
                    transform(inputs, i, input, k);
                    k++;
                }
            }
        }

        static void convertUnit(decimal[,] inputs, int i, int k, int input)
        {
            decimal temp = inputs[k, i];
            for (int j = 0; j <= input; j++)
                inputs[k,j] = inputs[k,j] / temp;
        }

        static void transform(decimal[,] inputs, int i, int input, int k)
        {
            for (int j = 0; j < input; j++)
            {
                if (j == k)
                    continue;

                decimal temp = inputs[j, k];
                for (int l = 0; l <= input; l++)
                {
                    inputs[j, l] = inputs[j, l] - inputs[i, l] * temp;
                }
            }
        }

        static void swaprow(decimal[,] inputs, int pivot, int i, int input)
        {
            for (int j = 0; j <= input; j++)
            {
                decimal temp = inputs[i, j];
                inputs[i, j] = inputs[pivot, j];
                inputs[pivot, j] = temp;
            }
        }

        static int getPivot(decimal[,] inputs, int input, int i, int k)
        {
            int[] temp = new int[2];
            for (int j = k; j < input; j++)
            {
                if (Math.Round(inputs[j, i], 5) != Convert.ToDecimal(0.00))
                    return j;
            }

            return -1;
        }
    }
}
