using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Independent_SET_Fun_Party
{
    class node
    {
        public int value;
        public int weight;
        public int fun = int.MinValue;
        public List<int> neighbours = new List<int>();
        public node(int k,int w)
        {
            value = k;
            weight = w;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            node[] nodes = new node[num];

            string[] w;
            if (nodes.Length != 0)
            {
                w = Console.ReadLine().Split();
                for (int j = 0; j < num; j++)
                {
                    nodes[j] = new node(j, int.Parse(w[j]));
                }
            }

            for (int i = 1; i < num; i++)
            {
                string[] temp = Console.ReadLine().Split();
                int first = int.Parse(temp[0]);
                int second = int.Parse(temp[1]);
                nodes[first - 1].neighbours.Add(second - 1);
                nodes[second - 1].neighbours.Add(first - 1);
            }
            int result = 0;
            if (nodes.Length != 0)
                result = calculateFun(nodes, 0, -1);
            //maxfun(nodes, 0, -1);
            //Console.WriteLine(nodes[0].fun);
            Console.WriteLine(result);
            Console.Read();
        }

        static void maxfun(node[] a, int v, int parent)
        {
            foreach (int b in a[v].neighbours)
            {
                if (b != parent)
                    maxfun(a, b, v);
            }
            int m1 = a[v].weight;
            int m2 = 0;
            foreach (int child in a[v].neighbours)
            {
                if (child != parent)
                {
                    m2 = m2 + a[child].fun;
                    foreach (int granC in a[child].neighbours)
                    {
                        if (granC != child && granC != parent)
                            m1 = m1 + a[granC].fun;
                    }
                }
            }
            a[v].fun = Math.Max(m1, m2);
        }

        static int calculateFun(node[] a, int curr, int parent)
        {
            if (a[curr].fun == int.MinValue)
            {
                if (a[curr].neighbours.Count == 1 && curr != 0)
                    a[curr].fun = a[curr].weight;
                else
                {
                    int m1 = a[curr].weight;
                    int m2 = 0;
                    foreach (int child in a[curr].neighbours)
                    {
                        if (child != parent)
                        {                           
                            foreach (int granchild in a[child].neighbours)
                            {
                                if (granchild != curr && granchild != parent && granchild != child)
                                    m1 = m1 + calculateFun(a, granchild, child);
                            }
                        }
                    }
                    foreach (int child in a[curr].neighbours)
                    {
                        if (child != parent) 
                        m2 = m2 + calculateFun(a, child, curr);
                    }
                    a[curr].fun = Math.Max(m1, m2);
                }
            }
            return a[curr].fun;
        }
    }
}
