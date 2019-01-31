using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random ran = new Random();
            
            //for(int l = 0; l < 1000; l++)
            //{ 

            int input = int.Parse(Console.ReadLine());
           // int input = ran.Next(2, 5);
            decimal[,] inputs = new decimal[input, input + 1];
            decimal[,] inputs2 = new decimal[input, input + 1];
            for (int i = 0; i < input; i++)
            {

                    string[] temp = Console.ReadLine().Split();
                //for (int j = 0; j < input + 1; j++)
                //{
                //    inputs[i, j] = ran.Next(-10, 10);
                //    if (inputs[i, j] == 0)
                //        inputs[i, j]++;
                //    inputs2[i, j] = inputs[i, j];
                //}
                for (int j = 0; j < input + 1; j++)
                    inputs[i, j] = decimal.Parse(temp[j]);
            }
            decimal[] result = calcElemination(inputs, input, input + 1);
            //decimal[] result2 = calcElemination2(inputs, input);

            for (int i = 0; i < input; i++)
            {
                //if ( result != null && result2[i] != result[i] )
                //{
                //    Console.Write("Error");
                //    Console.Read();
                //}
                Console.Write(result[i] + " ");
                //for (int j = 0; j < input; j++)
                //{
                //    if (Math.Round(inputs[i, j], 10) != 0)
                //    {
                //        Console.Write(inputs[i, input] + " ");
                //        break;
                //    }
                //}
            //}
            //Console.WriteLine("pass");
        }
            Console.Read();
        }
        static decimal[] calcElemination(decimal[,] inputs, int rows, int cols)
        {
            decimal[] result = new decimal[cols - 1];
            int k = 0;
            decimal checkLastEQ = inputs[rows - 1, cols - 1];
            for (int i = 0; i < cols - 1; i++)
            {
                int pivot = getPivot(inputs, rows, i, k);
                if (pivot != -1)
                {
                    if (pivot != k)
                        swaprow(inputs, k, pivot, rows);
                    convertUnit(inputs, i, k, cols);
                    transform(inputs, i, rows, k, cols);
                    k++;
                }

            }

            //appending matrix variable results
            for (int i = 0; i < rows; i++)
            {
                int check = 0;
                for (int j = 0; j < cols - 1; j++)
                {
                    if (inputs[i, j] != 0)
                    {
                        result[j] = inputs[i, cols - 1];
                        check = 1;
                        break;
                    }
                }
                if (check != 1)
                    return null;
            }
            return result;
        }

        static void convertUnit(decimal[,] inputs, int i, int k, int input)
        {
            decimal temp = inputs[k, i];
            for (int j = 0; j < input; j++)
                inputs[k, j] = inputs[k, j] / temp;
        }

        static void transform(decimal[,] inputs, int i, int input, int k, int cols)
        {
            for (int j = 0; j < input; j++)
            {
                if (j == k)
                    continue;
                decimal temp = inputs[j, i];
                for (int l = 0; l < cols; l++)
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
            for (int j = k; j < input; j++)
            {
                if (Math.Round(inputs[j, i], 5) != Convert.ToDecimal(0.00))
                    return j;
            }
            return -1;
        }

        static decimal[] calcElemination2(decimal[,] inputs, int input)
        {
            int k = 0;
            for (int i = 0; i < input; i++)
            {
                int pivot = getPivot2(inputs, input, i, k);
                if (pivot != -1)
                {
                    if (pivot != i)
                        swaprow2(inputs, i, pivot, input);
                    convertUnit2(inputs, i, k, input);
                    transform2(inputs, i, input, k);
                }
                k++;
            }
            decimal[] result = new decimal[input];
            for (int i = 0; i < input; i++)
            {
                //Console.Write(result[i] + " ");
                for (int j = 0; j < input; j++)
                {
                    if (Math.Round(inputs[i, j], 10) != 0)
                    {
                        result[i] = inputs[i, input];
                        break;
                    }
                }
            }
            return result;
        }

        static void convertUnit2(decimal[,] inputs, int i, int k, int input)
        {
            decimal temp = inputs[i, k];
            for (int j = 0; j <= input; j++)
                inputs[i, j] = inputs[i, j] / temp;
        }

        static void transform2(decimal[,] inputs, int i, int input, int k)
        {
            for (int j = 0; j < input; j++)
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

        static void swaprow2(decimal[,] inputs, int pivot, int i, int input)
        {
            for (int j = 0; j <= input; j++)
            {
                decimal temp = inputs[i, j];
                inputs[i, j] = inputs[pivot, j];
                inputs[pivot, j] = temp;
            }
        }

        static int getPivot2(decimal[,] inputs, int input, int i, int k)
        {
            int[] temp = new int[2];
            for (int j = i; j < input; j++)
            {
                if (Math.Round(inputs[j, k], 5) != Convert.ToDecimal(0.00))
                    return j;
            }

            return -1;
        }
    }
}
