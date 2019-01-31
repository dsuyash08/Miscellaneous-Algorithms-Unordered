//using System;
//using System.Collections.Generic;
//namespace subset
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            decimal finalresult = int.MinValue;
//            string[] input = Console.ReadLine().Split();
//            decimal[,] inputs = new decimal[int.Parse(input[0]) + int.Parse(input[1]) + 1, int.Parse(input[1]) + 1];

//            for (int i = 0; i < int.Parse(input[0]); i++)
//            {
//                string[] temp = Console.ReadLine().Split();
//                for (int j = 0; j < int.Parse(input[1]); j++)
//                    inputs[i, j] = Convert.ToDecimal(temp[j]);
//            }
//            string[] temp2 = Console.ReadLine().Split();
//            for (int k = 0; k < int.Parse(input[0]); k++)
//                inputs[k, int.Parse(input[1])] = Convert.ToDecimal(temp2[k]) + Convert.ToDecimal(.000001);

//            //adding row for each variable
//            int m = 0;
//            for (int k = int.Parse(input[0]); k < int.Parse(input[0]) + int.Parse(input[1]); k++, m++)
//            {
//                for (int l = 0; l < int.Parse(input[1]) + 1; l++)
//                    inputs[k, m] = 1;
//            }

//            //add for unbounded check
//            for (int l = 0; l < int.Parse(input[1]); l++)
//                inputs[int.Parse(input[0]) + int.Parse(input[1]), l] = 1;
//            inputs[int.Parse(input[0]) + int.Parse(input[1]), int.Parse(input[1])] = Convert.ToDecimal(Math.Pow(10, 9));

//            //Taking input of the equation to calculat;
//            string[] expression = Console.ReadLine().Split();


//            List<int[]> subsets = getsubset(int.Parse(input[1]), int.Parse(input[0]) + int.Parse(input[1]) + 1);
//            decimal[] matrixResult1 = new decimal[int.Parse(input[1]) + 1];
//            foreach (int[] a in subsets)
//            {
//                decimal[,] temp = createArrFromSubset(a, inputs, int.Parse(input[1]));
//                decimal[] matrixResult = calcElemination(temp, int.Parse(input[1]), int.Parse(input[1]) + 1);
//                matrixcheck(matrixResult);
//                if (matrixResult != null)
//                {
//                    int check = 0;
//                    for (int i = 0; i < a.Length; i++)
//                    {
//                        if (a[i] == 0)
//                        {
//                            decimal result = checkEq(matrixResult, i, inputs, int.Parse(input[1]), int.Parse(input[0]));
//                            if (result == int.MinValue)
//                            {
//                                check = -1;
//                                break;
//                            }
//                        }
//                    }
//                    if (check != -1)
//                    {
//                        decimal tempresult = 0;
//                        for (int i = 0; i < int.Parse(input[1]); i++)
//                            tempresult = tempresult + matrixResult[i] * int.Parse(expression[i]);
//                        if (tempresult > finalresult)
//                        {
//                            for (int i = 0; i < matrixResult.Length; i++)
//                                matrixResult1[i] = matrixResult[i];
//                            finalresult = tempresult;
//                        }
//                    }
//                }
//            }
//            if (finalresult >= Convert.ToDecimal(Math.Pow(10, 9)))
//                Console.WriteLine("Infinity");
//            else if (finalresult == int.MinValue)
//                Console.WriteLine("No solution");
//            else
//            {
//                Console.WriteLine("Bounded solution");
//                for (int i = 0; i < matrixResult1.Length - 1; i++)
//                    Console.Write((matrixResult1[i]) + " ");
//            }
//            Console.Read();
//        }

//        static void matrixcheck(decimal[] matrixresult)
//        {
//            for (int i = 0; i < matrixresult.Length; i++)
//            {
//                if (matrixresult[i] > Convert.ToDecimal(-0.000000001) && matrixresult[i] < 0)
//                    matrixresult[i] = 0;
//            }
//        }

//        static decimal checkEq(decimal[] matrixResult, int eqIndex, decimal[,] inputs, int cols, int rows)
//        {
//            decimal result = 0;
//            for (int i = 0; i < cols; i++)
//            {
//                result = result + matrixResult[i] * inputs[eqIndex, i];
//            }
//            if (eqIndex >= rows && eqIndex < rows + cols)
//            {
//                if (result < inputs[eqIndex, cols])
//                    return int.MinValue;
//                else
//                    return result;
//            }
//            else
//            {
//                if (result > inputs[eqIndex, cols])
//                    return int.MinValue;
//                else
//                    return result;
//            }
//        }

//        static decimal[,] createArrFromSubset(int[] a, decimal[,] inputs, int vars)
//        {
//            int[] temp1 = new int[vars];
//            int check = 0;
//            for (int i = 0; i < a.Length; i++)
//            {
//                if (a[i] == 1)
//                {
//                    temp1[check] = i;
//                    check++;
//                }
//            }
//            decimal[,] temp = new decimal[vars, vars + 1];
//            for (int i = 0; i < vars; i++)
//            {
//                for (int j = 0; j < vars + 1; j++)
//                {
//                    temp[i, j] = inputs[temp1[i], j];
//                }
//            }
//            return temp;
//        }


//        static List<int[]> getsubset(int subSetsize, int noOfCols)
//        {
//            List<int[]> subsets = new List<int[]>();
//            for (int i = 0; i < noOfCols - subSetsize + 1; i++)
//            {
//                if (subSetsize != 1)
//                    getsub(i, subSetsize, noOfCols, subsets);
//                else
//                {
//                    int[] temp = new int[noOfCols];
//                    temp[i] = 1;
//                    subsets.Add(temp);
//                }
//            }
//            return subsets;
//        }

//        static void getsub(int i, int subSetsize, int rows, List<int[]> subsets)
//        {
//            int index = i + 1;
//            while (true)
//            {
//                if (rows - index < subSetsize - 1)
//                    break;
//                for (int j = index + 1; j <= rows - (subSetsize - 2); j++)
//                {
//                    int[] temp = getvalue(j, index, i, subSetsize, rows);
//                    subsets.Add(temp);
//                    if (subSetsize - 2 <= 0)
//                        break;
//                }
//                index++;
//            }
//        }

//        static int[] getvalue(int j, int index, int i, int subSetsize, int rows)
//        {
//            int[] temp = new int[rows];
//            if (subSetsize == 1)
//            {
//                temp[i] = 1;
//                return temp;
//            }
//            temp[i] = 1;
//            temp[index] = 1;
//            for (int k = 0; k < subSetsize - 2; k++)
//            {
//                temp[k + j] = 1;
//            }
//            return temp;
//        }

//        static decimal[] calcElemination(decimal[,] inputs, int rows, int cols)
//        {
//            decimal[] result = new decimal[cols];
//            int k = 0;
//            decimal checkLastEQ = inputs[rows - 1, cols - 1];
//            for (int i = 0; i < cols - 1; i++)
//            {
//                int pivot = getPivot(inputs, rows, i, k);
//                if (pivot != -1)
//                {
//                    if (pivot != k)
//                        swaprow(inputs, k, pivot, rows);
//                    convertUnit(inputs, i, k, cols);
//                    transform(inputs, i, rows, k, cols);
//                    k++;
//                }

//            }

//            //appending matrix variable results
//            for (int i = 0; i < rows; i++)
//            {
//                int check = 0;
//                for (int j = 0; j < cols - 1; j++)
//                {
//                    if (inputs[i, j] != 0)
//                    {
//                        result[j] = inputs[i, cols - 1];
//                        if (result[j] > 68 && result[j] < 70)
//                            Console.Read();
//                        check = 1;
//                        break;
//                    }
//                }
//                if (check != 1)
//                    return null;
//            }
//            return result;
//        }

//        static void convertUnit(decimal[,] inputs, int i, int k, int input)
//        {
//            decimal temp = inputs[k, i];
//            for (int j = 0; j < input; j++)
//                inputs[k, j] = inputs[k, j] / temp;
//        }

//        static void transform(decimal[,] inputs, int i, int input, int k, int cols)
//        {
//            for (int j = 0; j < input; j++)
//            {
//                if (j == k)
//                    continue;
//                decimal temp = inputs[j, i];
//                for (int l = 0; l < cols; l++)
//                {
//                    inputs[j, l] = inputs[j, l] - inputs[i, l] * temp;
//                }
//            }
//        }

//        static void swaprow(decimal[,] inputs, int pivot, int i, int input)
//        {
//            for (int j = 0; j <= input; j++)
//            {
//                decimal temp = inputs[i, j];
//                inputs[i, j] = inputs[pivot, j];
//                inputs[pivot, j] = temp;
//            }
//        }

//        static int getPivot(decimal[,] inputs, int input, int i, int k)
//        {
//            for (int j = k; j < input; j++)
//            {
//                if (Math.Round(inputs[j, i], 5) != Convert.ToDecimal(0.00))
//                    return j;
//            }
//            return -1;
//        }
//    }
//}
