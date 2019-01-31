using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_SAT_Special_Cases
{
    class node
    {
        public int key;
        public int visited;
        public List<node> neighbours = new List<node>();
        public node(int k)
        {
            key = k;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();

            //Random r = new Random();
            //String[] inputs = new String[2];
            //inputs[0] = r.Next(100000, 100000).ToString();
            //inputs[1] = r.Next(100000, 100000).ToString();
            int num = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            node[] nodes = new node[num*2];
            node[] rnodes = new node[num*2];

            for(int j = 0; j < num; j++)
            {
                node n = new node(j+1);
                node rn = new node(j+1);
                node n_neg = new node(-(j+1));
                node rn_neg = new node(-(j+1));
                nodes[2*j] = n;
                nodes[2*j + 1] = n_neg;
                rnodes[2*j] = rn;
                rnodes[2*j + 1] = rn_neg;
            }

            for(int i = 0; i < m; i++)
            {
                string[] temp = Console.ReadLine().Split();
                int first = int.Parse(temp[0]);
                int second = int.Parse(temp[1]);

                //int first = r.Next(-int.Parse(inputs[0]), int.Parse(inputs[0]));
                //int second = r.Next(-int.Parse(inputs[0]), int.Parse(inputs[0]));
                //if (first == 0)
                //    first = first + 1;
                //if (second == 0)
                //    second = second + 1;

                createGraph(first, second , nodes, rnodes);               
            }

            List<HashSet<int>> scc = getscc(nodes, rnodes, int.Parse(inputs[0]));
            //var watch = new System.Diagnostics.Stopwatch();

            //watch.Start();
            int[] res = new int[num];
            
            if (checkscc(scc, res))
            {
                Console.WriteLine("SATISFIABLE"); 
                
                for (int i = 0; i < num; i++)
                      Console.Write(res[i] + " ");       
            }
            else
                Console.WriteLine("UNSATISFIABLE");


            //watch.Stop();

            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //Console.Read();
        }

        static bool checkscc(List<HashSet<int>> sccs, int[] res)
        {
            foreach(HashSet<int> scc in sccs)
            {
                //var anyDuplicate = scc.GroupBy(x => Math.Abs(x)).Any(g => g.Count() > 1);
                //if (anyDuplicate)
                //    return false;

                foreach (int i in scc)
                {
                    if (i > 0 && res[i - 1] == 0)
                        res[i - 1] = i;
                    else if (i < 0 && res[-1 * i - 1] == 0)
                        res[-i - 1] = i;
                    if (scc.Contains(-i))
                        return false;
                }
            }
            return true;
        }

        static List<HashSet<int>> getscc(node[] nodes, node[] rnodes, int vars)
        {
            List<HashSet<int>> sccs = new List<HashSet<int>>();
            Stack<int> porder = new Stack<int>();
                    
            dfs(rnodes, porder, vars*2);            
            for (int i = porder.Count - 1; i >= 0; i--)
            {
                int k = porder.Pop();
                node temp;
                if (k > 0)
                    temp = nodes[(k - 1) * 2];
                else
                    temp = nodes[(-k - 1) * 2 + 1];
                if (temp.visited == 0)
                    sccs.Add(explore2(temp, vars));                
            }
            return sccs;
        }

        static HashSet<int> explore2(node a, int vars)
        {
            HashSet<int> scc = new HashSet<int>();
            Stack<node> s = new Stack<node>();
            s.Push(a);
            a.visited = 1;
            scc.Add(a.key);

            while (true)
            {
                if (s.Count == 0)
                    break;
                node temp = s.Pop();
                foreach (node b in temp.neighbours)
                {
                    if (b.visited == 0)
                    {
                        b.visited = 1;
                        s.Push(b);
                        scc.Add(b.key);
                    }
                }
            }
            return scc;            
        }



        static void dfs(node[] rnodes, Stack<int> porder, int vars)
        {            
            foreach(node a in rnodes)
            {
                if (a.visited == 0)
                    explore(a, rnodes, porder);
            }            
        }

        static void explore(node a, node[] nodes, Stack<int> porder)
        {
            Stack<node> s = new Stack<node>();
            s.Push(a);
            a.visited = 1;
            while (true)
            {
                if (s.Count == 0)
                    break;
                bool c = false;
                foreach (node b in s.Peek().neighbours)
                {
                    if (b.visited == 0)
                    {
                        b.visited = 1;
                        s.Push(b);
                        c = true;
                        break;
                    }
                }
                if (!c)
                    porder.Push(s.Pop().key);
            }
        }


        static void createGraph(int first, int second, node[] nodes, node[] rnodes)
        {
            
            int x,y,x1, y1;
            if (first < 0)
            {
                x = (-first - 1) * 2 + 1;
                x1 = (-first - 1) * 2 + 1 - 1;
            }
            else
            {
                x = ((first - 1) * 2);
                x1 = ((first - 1) * 2) + 1;
            }
            if (second < 0)
            {
                y = (-second - 1) * 2 + 1;
                y1 = (-second - 1) * 2 + 1 - 1;
            }
            else
            {
                y = (second - 1) * 2;
                y1 = (second - 1) * 2 + 1;
            }

            if (x == y)
            {
                if (first < 0)
                {
                    nodes[x - 1].neighbours.Add(nodes[y]);
                    rnodes[y].neighbours.Add(rnodes[x - 1]);
                }
                else
                {
                    nodes[x + 1].neighbours.Add(nodes[y]);
                    rnodes[y].neighbours.Add(rnodes[x + 1]);
                }
            }
            else
            {
                nodes[x1].neighbours.Add(nodes[y]);
                nodes[y1].neighbours.Add(nodes[x]);
                rnodes[y].neighbours.Add(rnodes[x1]);
                rnodes[x].neighbours.Add(rnodes[y1]);
            }
        }
    }
}
