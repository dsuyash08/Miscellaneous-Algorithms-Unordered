using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            int[,] graph = new int[n,n];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    graph[i, j] = int.MaxValue;
            }
            for(int i = 0; i < m; i++)
            {
                string[] temp = Console.ReadLine().Split();
                graph[int.Parse(temp[0]) - 1,int.Parse(temp[1]) - 1] = int.Parse(temp[2]);
                graph[int.Parse(temp[1]) - 1,int.Parse(temp[0]) - 1] = int.Parse(temp[2]);
            }

            tsp(graph, n);

        }

        

        static void tsp(int[,] graph, int n)
        {
            int[,] c = new int[Convert.ToInt32(Math.Pow(2, n))-1,n];
            for(int i = 0; i < Convert.ToInt32(Math.Pow(2, n))- 1; i++)
            {
                for (int j = 0; j < n; j++)
                    c[i, j] = int.MaxValue;
            }
            c[0, 0] = 0;
            List<string> b = new List<string>();
            List<int> path = new List<int>();
            for (int i = 1; i <= n; i++)
                path.Add(Convert.ToInt32(Math.Pow(2, i)) - 1);
            for (int i = 1; i < Convert.ToInt32(Math.Pow(2, n)); i++)
            {
                b.Add(Convert.ToString(i,2));
            }
            

            for(int i = 2; i <= n; i++)
            {
                for (int j= 0;j< Convert.ToInt32(Math.Pow(2, n))- 1; j++)
                {
                    List<int> temp = new List<int>();
                    if (sum(b[j], temp, j) == i && int.Parse(b[j])%10 ==1)
                    {
                        int k = Convert.ToInt32(b[j],2);
                        foreach(int index in temp)
                        {
                            if (index != 0)
                            {
                                foreach (int l in temp)
                                {
                                    if (l != index && c[(k ^ (1 << index)) - 1, l] != int.MaxValue && graph[index, l] != int.MaxValue)
                                    {
                                        c[k - 1, index] = Math.Min(c[k - 1, index], c[(k ^ (1 << index)) - 1, l] + graph[index, l]);
                                    }
                                }
                            }                            
                        }
                    }
                }
            }
            getMin(c,n, graph, path);                   
            Console.Read();
        }

        static void getMin(int[,] c, int n, int[,] graph, List<int> path)
        {
            int k = Convert.ToInt32(Math.Pow(2, n)) - 2;
            int j = int.MaxValue;
            int ind = -1;
            for (int i = 0; i < n; i++)
            {
                if (j > c[k, i])
                {
                    ind = i;
                    j = c[k, i];
                }
            }
            if (j != int.MaxValue && graph[0, ind] != int.MaxValue)
            {
                Console.WriteLine(j + graph[0, ind]);
                Console.Write("1" + " " + (ind + 1) + " ");
                for (int i = path.Count - 2; i > 0; i--)
                {
                    for (int l = 0; l < n; l++)
                    {
                        if (c[path[i] - 1, l] + graph[ind, l] == j)
                        {
                            j = c[path[i] - 1, l];
                            ind = l;
                            Console.Write((l + 1) + " ");
                        }
                    }
                }
            }
            else
                Console.Write("-1");

           

        }
        static int sum(string k, List<int> temp,  int j)
        {
            int s = 0;
            for(int i = 0; i < k.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToString(k[i])) == 1)
                {
                    temp.Add(i);
                    s++;
                }
            }
            return s;
        }
    }
}

