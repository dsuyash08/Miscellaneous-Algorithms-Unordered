using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> res = get(4, 13);
            Console.Read();
        }

        static List<int[]> get(int sub, int total)
        {
            List<string> res = new List<string>();
            List<string> a = new List<string>();
            for(int i = 1; i < Math.Pow(2,total); i++)
            {
                a.Add(Convert.ToString(i, 2));
            }
            foreach(string b in a)
            {
                int s = b.ToString().Sum(c => c - '0');
                if (s == sub)
                {
                    //if (b.Length < total)
                    //    res.Add(Convert.ToInt32(b, 10) * Convert.ToInt32(Math.Pow(10, total - b.Length)));
                    //else
                        res.Add(b);
                }
            }
            List<int[]> temp = new List<int[]>();
            foreach(string i in res)
            {
                int[] temp1 = new int[total];
                int c = total - 1;
                for (int j = i.Length -1; j >= 0; j--)
                {
                    temp1[c] = i[j]- '0';
                    c--;
                }
                if(c != 0)
                {
                    while(c>= 0)
                    {
                        temp1[c] = 0;
                        c--;
                    }
                }
                temp.Add(temp1);
                //int k = i;
                //for(int j = total - 1; j >= 0; j--)
                //{
                //    temp1[j] = k % 10;
                //    k = k / 10;
                //}
                //temp.Add(temp1);
            }
            return temp;
            Console.Read();
        }

        static List<int[]> getsubset(int subSetsize, int noOfCols)
        {
            List<int[]> subsets = new List<int[]>();
            for (int i = 0; i < noOfCols - subSetsize + 1; i++)
            {
                if (subSetsize != 1)
                    getsub(i, subSetsize, noOfCols, subsets);
                else
                {
                    int[] temp = new int[noOfCols];
                    temp[i] = 1;
                    subsets.Add(temp);
                }
            }
            return subsets;
        }

        static void getsub(int i, int subSetsize, int rows, List<int[]> subsets)
        {
            int index = i + 1;
            while (true)
            {
                if (rows - index < subSetsize - 1)
                    break;
                for (int j = index + 1; j <= rows - (subSetsize - 2); j++)
                {
                    int[] temp = getvalue(j, index, i, subSetsize, rows);
                    subsets.Add(temp);
                    if (subSetsize - 2 <= 0)
                        break;
                }
                index++;
            }
        }

        static int[] getvalue(int j, int index, int i, int subSetsize, int rows)
        {
            int[] temp = new int[rows];
            if (subSetsize == 1)
            {
                temp[i] = 1;
                return temp;
            }
            temp[i] = 1;
            temp[index] = 1;
            for (int k = 0; k < subSetsize - 2; k++)
            {
                temp[k + j] = 1;
            }
            return temp;
        }

    }
}
