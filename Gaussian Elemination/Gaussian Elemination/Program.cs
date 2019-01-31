using System;
using System.Collections.Generic;
namespace Gaussian_Elemination
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            decimal[,] inputs = new decimal[input, input + 1];
            for(int i = 0; i < input; i++)
            {
                
                string[] temp = Console.ReadLine().Split();
                for (int j = 0; j < input + 1; j++)
                    inputs[i,j] = decimal.Parse(temp[j]);
            }
            calcElemination(inputs, input);
            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++) 
                {
                    if (Math.Round(inputs[i, j],10) != 0)
                    {
                        Console.Write(inputs[i, input] + " ");
                        break;
                    }
                }
            }
            Console.Read();
        }

        static void calcElemination(decimal[,] inputs, int input)
        {
            int k = 0;
            for (int i =0; i < input; i++)
            {
                int pivot = getPivot(inputs, input, i, k);
                if (pivot != -1)
                {
                    if (pivot != i)
                        swaprow(inputs, i, pivot, input);
                    convertUnit(inputs, i, k, input);
                    transform(inputs, i, input, k);
                }
                k++;
            }
        }

        static void convertUnit(decimal[,] inputs,int i, int k,int input)
        {
            decimal temp = inputs[i, k];
            for (int j = 0; j <= input; j++)
                inputs[i, j] = inputs[i, j] / temp;
        }

        static void transform(decimal[,] inputs, int i, int input,int k)
        {
            for(int j = 0; j < input; j++)
            {
                if (j == i)
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
            for(int j = 0; j <= input; j++)
            {
                decimal temp = inputs[i, j];
                inputs[i, j] = inputs[pivot, j];
                inputs[pivot, j] = temp;
            }
        }

        static int getPivot(decimal[,] inputs, int input,int i,int k)
        {
            int[] temp = new int[2];
            for(int j = i; j < input; j++)
            {
                if (Math.Round(inputs[j, k],5) != Convert.ToDecimal(0.00))
                    return j;                 
            }
            
            return -1;
        }
    }
}
