using System;
using System.Collections.Generic;
namespace stock_charts_google
{

    class edges
    {
        public int start;
        public int end;
        public int flow;
        public int capacity;

        public edges(int s, int e, int f, int c)
        {
            start = s;
            end = e;
            capacity = c;
            flow = f;
        }        
    }

    class node
    {
        public int key;
        public int[] keys;
        public Dictionary<int, edges> neighbours = new Dictionary<int, edges>();
    }

    class map
    {
        public int parent;
        public int minflow;

        public map() { }
        public map(int e, int min)
        {
            parent = e;
            minflow = min;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int len = int.Parse(input[0]);
            node[] rcities = new node[len * 2 + 2];

            for (int i = 1; i <= len; i++)
            {
                rcities[i] = new node();
                rcities[i].key = i;
                rcities[i].keys = new int[int.Parse(input[1])];
                string[] key = Console.ReadLine().Split();
                for (int j = 0; j < int.Parse(input[1]); j++)
                {
                    rcities[i].keys[j] = int.Parse(key[j]);
                }

                rcities[i + len] = new node();
                rcities[i + len].key = i + len;
                rcities[i + len].keys = new int[int.Parse(input[1])];                
                for (int j = 0; j < int.Parse(input[1]); j++)
                {
                    rcities[i + len].keys[j] = int.Parse(key[j]);
                }
            }

            createGraph(rcities, int.Parse(input[0]), int.Parse(input[1]));           

            //add start edge
            rcities[0]  = new node();
            
            rcities[len *2 + 2- 1]  = new node();
            rcities[len * 2 + 2 - 1].key = len * 2 + 2 - 1;
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                edges fwd = new edges(0, i + 1, 1, 1);
                edges backwd = new edges(i + 1, 0, 0, 1);
                rcities[0].neighbours.Add(i + 1, fwd);
                rcities[i + 1].neighbours.Add(0, backwd);
            }
            //add backward node edge
            for (int i = int.Parse(input[0]) + 1; i < (2 * len + 2) - 1; i++)
            {
                edges fwd = new edges(i, (2*len +2) - 1, 1, 1);
                edges backwd = new edges((2 * len + 2) - 1, i, 0, 1);
                rcities[i].neighbours.Add((2 * len + 2) - 1, fwd);
                rcities[(2 * len + 2) - 1].neighbours.Add(i, backwd);
            }

            int flow = calcFlow(rcities, len * 2 + 2);
            Console.Write(int.Parse(input[0]) - flow);
            Console.Read();
        }

        static void createGraph(node[] rcities, int len,int nofKeys)
        {
            List<node> lastnodes = new List<node>();
            for(int i = 1; i <= len; i++)
            {
                foreach(node a in lastnodes)
                {
                    if (checknode(rcities[i], a, nofKeys))
                        createEdge(rcities[a.key + len], rcities[i]);
                }
                lastnodes.Add(rcities[i]);
            }
        }


        static node getNode(List<node> lastnodes, node a, int nofTime)
        {
            for(int i = 0; i < lastnodes.Count; i++)
            {
                if (checknode(a, lastnodes[i], nofTime))
                {
                    lastnodes[i] = a;
                    return null;
                }
            }
            return a;
        }

        static bool checknode(node a, node b, int nofTime)
        {
            int count = 0;
            int count2 = 0;
            for(int i = 0; i < nofTime; i++)
            {
                if (a.keys[i] < b.keys[i])
                    count++;
                else
                    count2++;
            }
            if (count == nofTime || count2 == nofTime)
                return true;
            else
                return false;
        }

        static void  createEdge(node a, node b)
        {
            edges fwd = new edges(a.key, b.key, 0, 1);
            edges bckwd = new edges(b.key, a.key, 1, 1);
            a.neighbours.Add(b.key, fwd);
            b.neighbours.Add(a.key, bckwd);
        }

        static int calcFlow(node[] rcities,int len)
        {
            int flow = 0;
            while (true)
            {
                Dictionary<int, map> resultmaps = new Dictionary<int, map>();
                int min = bfs2(rcities, len - 1, resultmaps);
                if (min != -1)
                {
                    updateResidualGraph(rcities, len -1, resultmaps, min);
                    flow = flow + min;
                }
                else
                    break;
            }
            return flow;
        }


        static void updateResidualGraph(node[] rcities, int len, Dictionary<int, map> resultmaps, int minflow)
        {
            node curr = rcities[len];
            while (curr.key != rcities[0].key)
            {
                rcities[resultmaps[curr.key].parent].neighbours[curr.key].flow = rcities[resultmaps[curr.key].parent].neighbours[curr.key].flow - minflow;
                rcities[curr.key].neighbours[resultmaps[curr.key].parent].flow = rcities[curr.key].neighbours[resultmaps[curr.key].parent].flow + minflow;
                curr = rcities[resultmaps[curr.key].parent];
            }
        }

        static int bfs2(node[] rcities, int end, Dictionary<int, map> resultmaps)
        {
            Queue<node> q = new Queue<node>();
            resultmaps.Add(0, new map(-1, int.MaxValue));
            q.Enqueue(rcities[0]);
            while (q.Count != 0)
            {
                node temp = q.Dequeue();
                foreach (KeyValuePair<int, edges> a in temp.neighbours)
                {
                    if (a.Value.flow != 0 && !resultmaps.ContainsKey(a.Value.end))
                    {
                        q.Enqueue(rcities[a.Value.end]);                        
                        if (resultmaps[temp.key].minflow > a.Value.flow)
                            resultmaps.Add(a.Value.end, new map(temp.key, a.Value.flow));
                        else
                            resultmaps.Add(a.Value.end, new map(temp.key, resultmaps[temp.key].minflow));
                        if (a.Value.end == end)
                            return resultmaps[a.Value.end].minflow;
                    }
                }
            }
            return -1;
        }
    }
}
