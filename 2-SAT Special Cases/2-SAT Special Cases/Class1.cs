////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace _2_SAT_Special_Cases
////{
////    class node
////    {
////        public int key;
////        public int visited;
////        public List<node> neighbours = new List<node>();
////        public node(int k)
////        {
////            key = k;
////        }
////    }
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            string[] inputs = Console.ReadLine().Split();
////            //Random r = new Random();
////            //String[] inputs = new String[2];
////            //inputs[0] = r.Next(100000, 100000).ToString();
////            //inputs[1] = r.Next(100000, 100000).ToString();
////            List<int[]> clauses = new List<int[]>();
////            List<node> nodes = new List<node>();
////            List<node> rnodes = new List<node>();

////            for (int j = 0; j < int.Parse(inputs[0]); j++)
////            {
////                node n = new node(j + 1);
////                node rn = new node(j + 1);
////                node n_neg = new node(-(j + 1));
////                node rn_neg = new node(-(j + 1));
////                nodes.Add(n);
////                nodes.Add(n_neg);
////                rnodes.Add(rn);
////                rnodes.Add(rn_neg);
////            }

////            for (int i = 0; i < int.Parse(inputs[1]); i++)
////            {
////                string[] temp = Console.ReadLine().Split();
////                int[] clause = new int[2];
////                clause[0] = int.Parse(temp[0]);
////                clause[1] = int.Parse(temp[1]);

////                //int[] clause = new int[2];
////                //clause[0] = r.Next(-int.Parse(inputs[0]), int.Parse(inputs[0]));
////                //clause[1] = r.Next(-int.Parse(inputs[0]), int.Parse(inputs[0]));
////                //if (clause[0] == 0)
////                //    clause[0] = clause[0] + 1;
////                //if (clause[1] == 0)
////                //    clause[1] = clause[1] + 1;

////                createGraph(clause, nodes, rnodes);
////                clauses.Add(clause);
////            }

////            List<List<int>> scc = getscc(nodes, rnodes, int.Parse(inputs[0]));
////            //var watch = new System.Diagnostics.Stopwatch();

////            //watch.Start();
////            int[] res = new int[int.Parse(inputs[0])];
////            for (int i = 0; i < int.Parse(inputs[0]); i++)
////                res[i] = -10000000;
////            if (checkscc(scc, res))
////            {
////                Console.WriteLine("SATISFIABLE");
////                //int[] vars = new int[int.Parse(inputs[0])];
////                //foreach (List<int> sc in scc)
////                //{
////                //    foreach (int a in sc)
////                //    {
////                //        if (a > 0 && vars[a - 1] == 0)
////                //        {
////                //            vars[a - 1] = 1;
////                //            count++;
////                //        }
////                //        if (a < 0 && vars[(-1) * a - 1] == 0)
////                //        {
////                //            vars[(-1) * a - 1] = -1;
////                //            count++;
////                //        }
////                //    }
////                //    if (count == vars.Length)
////                //        break;
////                //}
////                //string result = null;
////                for (int i = 0; i < int.Parse(inputs[0]); i++)
////                {
////                    Console.Write(res[i] + " ");
////                    //if (vars[i] == 1)
////                    //    Console.Write((i + 1) + " ");
////                    //else
////                    //    Console.Write(-(i + 1) + " ");
////                }
////                //Console.Write(result);
////            }
////            else
////                Console.Write("UNSATISFIABLE");


////            //watch.Stop();

////            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
////            //Console.Read();
////        }

////        static bool checkscc(List<List<int>> sccs, int[] res)
////        {
////            foreach (List<int> scc in sccs)
////            {

////                foreach (int i in scc)
////                {
////                    if (i > 0 && res[i - 1] == -10000000)
////                        res[i - 1] = i;
////                    else if (i < 0 && res[-1 * i - 1] == -10000000)
////                        res[-1 * i - 1] = i;
////                    if (scc.Contains(-i))
////                        return false;
////                }
////                //int[] temp = new int[vars];
////                //foreach(node a in scc)
////                //{
////                //    if (a.key > 0 && temp[a.key -1] == 0)
////                //        temp[a.key - 1] = 1;
////                //    else if(a.key < 0 && temp[-1*a.key -1] == 0)
////                //        temp[-1*a.key - 1] = -1;
////                //    else if((a.key < 0 && temp[-1*a.key - 1]== 1 )|| (a.key > 0 && temp[a.key -1] == -1))
////                //    {
////                //        Console.Write("UNSATISFIABLE");
////                //        return 0;
////                //    }                    
////                //}
////            }
////            return true;
////        }

////        static List<List<int>> getscc(List<node> nodes, List<node> rnodes, int vars)
////        {
////            List<List<int>> sccs = new List<List<int>>();
////            List<Stack<node>> porder = new List<Stack<node>>();
////            //var watch = new System.Diagnostics.Stopwatch();

////            //watch.Start();         
////            dfs(rnodes, porder, vars * 2);
////            //watch.Stop();
////            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
////            //watch.Start();
////            for (int i = porder.Count - 1; i >= 0; i--)
////            {
////                while (porder[i].Count != 0)
////                {
////                    node temp = nodes[getindex(porder[i].Pop().key)];
////                    if (temp.visited == 0)
////                    {
////                        List<int> scc = new List<int>();
////                        if (explore2(temp, scc, vars))
////                            sccs.Add(scc);
////                        else
////                            return null;
////                    }
////                }
////            }

////            //watch.Stop();

////            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
////            return sccs;
////        }

////        static bool explore2(node a, List<int> scc, int vars)
////        {
////            Stack<node> s = new Stack<node>();
////            s.Push(a);
////            a.visited = 1;
////            scc.Add(a.key);

////            while (true)
////            {
////                if (s.Count == 0)
////                    break;
////                node temp = s.Pop();
////                foreach (node b in temp.neighbours)
////                {
////                    if (b.visited == 0)
////                    {
////                        b.visited = 1;
////                        s.Push(b);
////                        scc.Add(b.key);
////                    }
////                }
////            }
////            return true;
////        }

////        static int getindex(int k)
////        {
////            if (k < 0)
////                return (k * (-1) - 1) * 2 + 1;
////            else
////                return ((k - 1) * 2);
////        }

////        static void dfs(List<node> rnodes, List<Stack<node>> porder, int vars)
////        {
////            foreach (node a in rnodes)
////            {
////                if (a.visited == 0)
////                    explore(a, rnodes, porder);
////            }
////        }

////        static void explore(node a, List<node> nodes, List<Stack<node>> porder)
////        {
////            Stack<node> s = new Stack<node>();
////            Stack<node> q = new Stack<node>();
////            s.Push(a);
////            a.visited = 1;
////            while (true)
////            {
////                if (s.Count == 0)
////                    break;
////                node temp = s.Peek();
////                bool c = false;
////                foreach (node b in temp.neighbours)
////                {
////                    if (c)
////                        break;
////                    if (b.visited == 0)
////                    {
////                        b.visited = 1;
////                        s.Push(b);
////                        c = true;
////                    }
////                }
////                if (!c)
////                    q.Push(s.Pop());
////            }
////            porder.Add(q);
////        }


////        static void createGraph(int[] clause, List<node> nodes, List<node> rnodes)
////        {
////            int x = getindex(clause[0]);
////            int y = getindex(clause[1]);
////            int x1, y1;

////            if (clause[0] < 0)
////                x1 = x - 1;
////            else
////                x1 = x + 1;
////            if (clause[1] < 0)
////                y1 = y - 1;
////            else
////                y1 = y + 1;

////            if (x == y)
////            {
////                if (clause[0] < 0)
////                {
////                    nodes[x - 1].neighbours.Add(nodes[y]);
////                    rnodes[y].neighbours.Add(rnodes[x - 1]);
////                }
////                else
////                {
////                    nodes[x + 1].neighbours.Add(nodes[y]);
////                    rnodes[y].neighbours.Add(rnodes[x + 1]);
////                }
////            }
////            else
////            {
////                nodes[x1].neighbours.Add(nodes[y]);
////                nodes[y1].neighbours.Add(nodes[x]);
////                rnodes[y].neighbours.Add(rnodes[x1]);
////                rnodes[x].neighbours.Add(rnodes[y1]);
////            }
////        }
////    }
////using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _2_SAT_Special_Cases
//{
//    class node
//    {
//        public int key;
//        public int visited;
//        public List<node> neighbours = new List<node>();
//        public node(int k)
//        {
//            key = k;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string[] inputs = Console.ReadLine().Split();

//            //Random r = new Random();
//            //String[] inputs = new String[2];
//            //inputs[0] = r.Next(100000, 100000).ToString();
//            //inputs[1] = r.Next(100000, 100000).ToString();
//            int num = int.Parse(inputs[0]);
//            int m = int.Parse(inputs[1]);

//            List<node> nodes = new List<node>();
//            List<node> rnodes = new List<node>();

//            for (int j = 0; j < num; j++)
//            {
//                node n = new node(j + 1);
//                node rn = new node(j + 1);
//                node n_neg = new node(-(j + 1));
//                node rn_neg = new node(-(j + 1));
//                nodes.Add(n);
//                nodes.Add(n_neg);
//                rnodes.Add(rn);
//                rnodes.Add(rn_neg);
//            }

//            for (int i = 0; i < m; i++)
//            {
//                string[] temp = Console.ReadLine().Split();
//                int[] clause = new int[2];
//                clause[0] = int.Parse(temp[0]);
//                clause[1] = int.Parse(temp[1]);

//                //int[] clause = new int[2];
//                //clause[0] = r.Next(-int.Parse(inputs[0]), int.Parse(inputs[0]));
//                //clause[1] = r.Next(-int.Parse(inputs[0]), int.Parse(inputs[0]));
//                //if (clause[0] == 0)
//                //    clause[0] = clause[0] + 1;
//                //if (clause[1] == 0)
//                //    clause[1] = clause[1] + 1;

//                createGraph(clause, nodes, rnodes);
//            }

//            List<List<int>> scc = getscc(nodes, rnodes, int.Parse(inputs[0]));
//            //var watch = new System.Diagnostics.Stopwatch();

//            //watch.Start();
//            int[] res = new int[num];

//            if (checkscc(scc, res))
//            {
//                Console.WriteLine("SATISFIABLE");
//                for (int i = 0; i < num; i++)
//                    Console.Write(res[i] + " ");
//            }
//            else
//                Console.WriteLine("UNSATISFIABLE");


//            //watch.Stop();

//            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
//            //Console.Read();
//        }

//        static bool checkscc(List<List<int>> sccs, int[] res)
//        {
//            foreach (List<int> scc in sccs)
//            {
//                foreach (int i in scc)
//                {
//                    if (i > 0 && res[i - 1] == 0)
//                        res[i - 1] = i;
//                    else if (i < 0 && res[-1 * i - 1] == 0)
//                        res[-i - 1] = i;
//                    if (scc.Contains(-i))
//                        return false;
//                }
//            }
//            return true;
//        }

//        static List<List<int>> getscc(List<node> nodes, List<node> rnodes, int vars)
//        {
//            List<List<int>> sccs = new List<List<int>>();
//            Stack<int> porder = new Stack<int>();
//            dfs(rnodes, porder, vars * 2);
//            for (int i = porder.Count - 1; i >= 0; i--)
//            {
//                node temp = nodes[getindex(porder.Pop())];
//                if (temp.visited == 0)
//                {
//                    List<int> scc = new List<int>();
//                    if (explore2(temp, scc, vars))
//                        sccs.Add(scc);
//                    else
//                        return null;
//                }
//            }
//            return sccs;
//        }

//        static bool explore2(node a, List<int> scc, int vars)
//        {
//            Stack<node> s = new Stack<node>();
//            s.Push(a);
//            a.visited = 1;
//            scc.Add(a.key);
//            while (true)
//            {
//                if (s.Count == 0)
//                    break;
//                node temp = s.Pop();
//                foreach (node b in temp.neighbours)
//                {
//                    if (b.visited == 0)
//                    {
//                        b.visited = 1;
//                        s.Push(b);
//                        scc.Add(b.key);
//                    }
//                }
//            }
//            return true;
//        }

//        static int getindex(int k)
//        {
//            if (k < 0)
//                return (k * (-1) - 1) * 2 + 1;
//            else
//                return ((k - 1) * 2);
//        }

//        static void dfs(List<node> rnodes, Stack<int> porder, int vars)
//        {
//            foreach (node a in rnodes)
//            {
//                if (a.visited == 0)
//                    explore(a, rnodes, porder);
//            }
//        }

//        static void explore(node a, List<node> nodes, Stack<int> porder)
//        {
//            Stack<node> s = new Stack<node>();
//            //Stack<int> q = new Stack<node>();
//            s.Push(a);
//            a.visited = 1;
//            while (true)
//            {
//                if (s.Count == 0)
//                    break;
//                node temp = s.Peek();
//                bool c = false;
//                foreach (node b in temp.neighbours)
//                {
//                    if (c)
//                        break;
//                    if (b.visited == 0)
//                    {
//                        b.visited = 1;
//                        s.Push(b);
//                        c = true;
//                    }
//                }
//                if (!c)
//                    porder.Push(s.Pop().key);
//            }
//            //porder.Add(q);
//        }


//        static void createGraph(int[] clause, List<node> nodes, List<node> rnodes)
//        {
//            int x = getindex(clause[0]);
//            int y = getindex(clause[1]);
//            int x1, y1;

//            if (clause[0] < 0)
//                x1 = x - 1;
//            else
//                x1 = x + 1;
//            if (clause[1] < 0)
//                y1 = y - 1;
//            else
//                y1 = y + 1;

//            if (x == y)
//            {
//                if (clause[0] < 0)
//                {
//                    nodes[x - 1].neighbours.Add(nodes[y]);
//                    rnodes[y].neighbours.Add(rnodes[x - 1]);
//                }
//                else
//                {
//                    nodes[x + 1].neighbours.Add(nodes[y]);
//                    rnodes[y].neighbours.Add(rnodes[x + 1]);
//                }
//            }
//            else
//            {
//                nodes[x1].neighbours.Add(nodes[y]);
//                nodes[y1].neighbours.Add(nodes[x]);
//                rnodes[y].neighbours.Add(rnodes[x1]);
//                rnodes[x].neighbours.Add(rnodes[y1]);
//            }
//        }
//    }
//}
//}


