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

           for(int l = 0; l < 50000; l++)
           { 
            //string[] inputs = Console.ReadLine().Split();
            Random r = new Random();
            int[] inputs = new int[2];
            inputs[0] = r.Next(1, 4);
            inputs[1] = r.Next(1, 8);

            Console.WriteLine(inputs[0] + " " + inputs[1]);
            List<int[]> clauses = new List<int[]>();

            List<node> nodes = new List<node>();
            List<node> rnodes = new List<node>();

            List<node> nodes2 = new List<node>();
            List<node> rnodes2 = new List<node>();

            for (int j = 0; j < inputs[0]; j++)
            {
                node n = new node(j + 1);
                node rn = new node(j + 1);
                node n_neg = new node(-(j + 1));
                node rn_neg = new node(-(j + 1));
                nodes.Add(n);
                nodes.Add(n_neg);
                rnodes.Add(rn);
                rnodes.Add(rn_neg);
            }

            for (int j = 0; j < inputs[0]; j++)
            {
                node n = new node(j + 1);
                node rn = new node(j + 1);
                node n_neg = new node(-(j + 1));
                node rn_neg = new node(-(j + 1));
                nodes2.Add(n);
                nodes2.Add(n_neg);
                rnodes2.Add(rn);
                rnodes2.Add(rn_neg);
            }

            

            

            for (int i = 0; i < inputs[1]; i++)
            {
                    int[] clause = new int[2];
                    clause[0] = r.Next(-inputs[0], inputs[0]);
                    clause[1] = r.Next(-inputs[0], inputs[0]);
                    if (clause[0] == 0)
                        clause[0] = clause[0] + 1;
                    if (clause[1] == 0)
                        clause[1] = clause[1] + 1;
                    Console.WriteLine(clause[0] + " " + clause[1]);
                    //string[] temp = Console.ReadLine().Split();               

                    createGraph(clause, nodes, rnodes);
                    
            

                //string[] temp = Console.ReadLine().Split();

                   createGraph(clause, nodes2, rnodes2);
                   clauses.Add(clause);
            }

            List<node> postorder = new List<node>();
            List<List<node>> scc = getscc(nodes, rnodes, postorder);
            int result = checkscc(scc, inputs[0]);

            List<List<node>> scc2 = getscc2(nodes2, rnodes2, postorder);
            int result2 = checkscc(scc2, inputs[0]);

            if (result != result2)
            {
                Console.Read();
            }
            else
                Console.WriteLine("Okay");
            //if (result > 0)
            //{
            //    int count = 0;
            //    Console.WriteLine("SATISFIABLE");
            //    int[] vars = new int[int.Parse(inputs[0])];
            //    foreach (List<node> sc in scc)
            //    {
            //        foreach (node a in sc)
            //        {
            //            if (a.key > 0 && vars[a.key - 1] == 0)
            //            {
            //                vars[a.key - 1] = 1;
            //                count++;
            //            }
            //            if (a.key < 0 && vars[(-1) * a.key - 1] == 0)
            //            {
            //                vars[(-1) * a.key - 1] = -1;
            //                count++;
            //            }
            //        }
            //        if (count == vars.Length - 1)
            //            break;
            //    }
            //    for (int i = 0; i < int.Parse(inputs[0]); i++)
            //    {
            //        if (vars[i] == 1)
            //            Console.Write(i + 1 + " ");
            //        else
            //            Console.Write(-(i + 1) + " ");
            //    }
            //    ////Console.Read();
            //}
        }
        }

        static int checkscc(List<List<node>> sccs, int vars)
        {
            foreach (List<node> scc in sccs)
            {
                int[] temp = new int[vars];
                foreach (node a in scc)
                {
                    if (a.key > 0 && temp[a.key - 1] == 0)
                        temp[a.key - 1] = 1;
                    else if (a.key < 0 && temp[-1 * a.key - 1] == 0)
                        temp[-1 * a.key - 1] = -1;
                    else if ((a.key < 0 && temp[-1 * a.key - 1] == 1) || (a.key > 0 && temp[a.key - 1] == -1))
                    {
                        Console.Write("UNSATISFIABLE");
                        return 0;
                    }
                }
            }
            return 1;
        }

        static List<List<node>> getscc(List<node> nodes, List<node> rnodes, List<node> postorder)
        {
            List<List<node>> sccs = new List<List<node>>();
            dfs(rnodes, postorder);
            //for (int i = porder.Count - 1; i >= 0; i--)
            //{
            //    while (porder[i].Count != 0)
            //    {
            //        node temp = nodes[getindex(porder[i].Dequeue().key)];
            //        if (temp.visited == 0)
            //        {
            //            List<node> scc = new List<node>();
            //            explore2(temp, scc);
            //            sccs.Add(scc);
            //        }
            //    }
            //}

            for (int i = postorder.Count - 1; i >= 0; i--)
            {
                node temp = nodes[getindex(postorder[i].key)];
                if (temp.visited == 0)
                {
                    List<node> scc = new List<node>();
                    explore2(temp, scc);
                    sccs.Add(scc);
                }
            }

            return sccs;
        }

        static List<List<node>> getscc2(List<node> nodes, List<node> rnodes, List<node> postorder)
        {
            List<List<node>> sccs = new List<List<node>>();
            List<Queue<node>> porder = new List<Queue<node>>();
            dfs2(rnodes, porder);
            for (int i = porder.Count - 1; i >= 0; i--)
            {
                while (porder[i].Count != 0)
                {
                    node temp = nodes[getindex(porder[i].Dequeue().key)];
                    if (temp.visited == 0)
                    {
                        List<node> scc = new List<node>();
                        explore2(temp, scc);
                        sccs.Add(scc);
                    }
                }
            }

            //for (int i = postorder.Count - 1; i >= 0; i--)
            //{
            //    node temp = nodes[getindex(postorder[i].key)];
            //    if (temp.visited == 0)
            //    {
            //        List<node> scc = new List<node>();
            //        explore2(temp, scc);
            //        sccs.Add(scc);
            //    }
            //}

            return sccs;
        }

        static void explore2(node a, List<node> scc)
        {
            Stack<node> s = new Stack<node>();
            s.Push(a);
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
                        scc.Add(b);
                    }
                }
                if (temp.visited == 0)
                {
                    temp.visited = 1;
                    scc.Add(temp);
                }
            }
            //if (a.visited == 1)
            //    return;
            //a.visited = 1;
            //scc.Add(a);            
            //foreach (node b in a.neighbours)
            //{
            //    if (b.visited == 0)
            //        explore2(b, scc);
            //}
        }

        static int getindex(int k)
        {
            if (k < 0)
                return (k * (-1) - 1) * 2 + 1;
            else
                return ((k - 1) * 2);
        }

        static void dfs(List<node> rnodes, List<node> porder)
        {

            int ordercount = 0;
            foreach (node a in rnodes)
            {
                if (a.visited == 0)
                    explore(a, rnodes, porder, ref ordercount);
            }
        }

        static void dfs2(List<node> rnodes, List<Queue<node>> porder)
        {

            int ordercount = 0;
            foreach (node a in rnodes)
            {
                if (a.visited == 0)
                    explore2r(a, rnodes, porder, ref ordercount);
            }
        }


        static void explore(node a, List<node> nodes, List<node> porder, ref int ordercount)
        {
            //Stack<node> s = new Stack<node>();
            //s.Push(a);
            //porder.Add(a);
            //a.visited = 1;
            //while (true)
            //{
            //    if (s.Count == 0)
            //        break;
            //    node temp = s.Pop();

            //    foreach (node b in temp.neighbours)
            //    {
            //        if (b.visited == 0)
            //        {
            //            porder.Add(b);
            //            b.visited = 1;
            //            s.Push(b);
            //        }
            //    }
            //}

            if (a.visited == 1)
                return;
            a.visited = 1;
            foreach (node b in a.neighbours)
            {
                if (b.visited == 0)
                    explore(b, nodes, porder, ref ordercount);
            }
            porder.Add(a);

        }

        static void explore2r(node a, List<node> nodes, List<Queue<node>> porder, ref int ordercount)
        {
            Stack<node> s = new Stack<node>();
            Queue<node> q = new Queue<node>();
            s.Push(a);
            q.Enqueue(a);
            a.visited = 1;
            while (true)
            {
                if (s.Count == 0)
                    break;
                node temp = s.Pop();
                q.Enqueue(temp);
                foreach (node b in temp.neighbours)
                {
                    if (b.visited == 0)
                    {
                        b.visited = 1;
                        s.Push(b);
                    }
                }
            }
            porder.Add(q);


            //if (a.visited == 1)
            //    return;
            //a.visited = 1;
            //foreach (node b in a.neighbours)
            //{
            //    if (b.visited == 0)
            //        explore(b, nodes, porder, ref ordercount);
            //}
            //porder.Add(a);

        }


        static void createGraph(int[] clause, List<node> nodes, List<node> rnodes)
        {
         
            int x = getindex(clause[0]);
            int y = getindex(clause[1]);
            int x1, y1;

            if (clause[0] < 0)
                x1 = x - 1;
            else
                x1 = x + 1;
            if (clause[1] < 0)
                y1 = y - 1;
            else
                y1 = y + 1;

            if (x == y)
            {
                if (clause[0] < 0)
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
