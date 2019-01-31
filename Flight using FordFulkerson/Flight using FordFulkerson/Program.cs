using System;
using System.Collections.Generic;
namespace Flight_using_FordFulkerson
{

    class edges
    {
        public int start;
        public int end;
        public int flow;
        public int capacity;
        public int state;

        public edges(int s, int e, int f, int c)
        {
            start = s;
            end = e;
            capacity = c;
            flow = f;
        }

        public edges(int s, int e, int f, int c, int st)
        {
            start = s;
            end = e;
            capacity = c;
            flow = f;
            state = st;
        }
    }

    class node
    {
        public int key;
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
            int len = int.Parse(input[0]) + int.Parse(input[1]) + 2;
            node[] rcities = new node[len];           

            for (int i = 0; i < len; i++)
            {
                rcities[i] = new node();
                rcities[i].key = i;
            }

            for (int i = 1; i < int.Parse(input[0]) + 1; i++)
            {
                string[] temp = Console.ReadLine().Split();
                for (int j = 0; j < int.Parse(input[1]); j++)
                {
                    if (int.Parse(temp[j]) == 1)
                    {
                        edges fwd = new edges(i, j + int.Parse(input[0]) + 1, 1, 1);
                        edges backwd = new edges(j + int.Parse(input[0]) + 1, i, 0, 1);
                        rcities[i].neighbours.Add(j + int.Parse(input[0]) + 1, fwd);
                        rcities[j + int.Parse(input[0]) + 1].neighbours.Add(i, backwd);
                    }
                }
            }

            //add start edge
            for(int i = 0; i < int.Parse(input[0]); i++ )
            {
                edges fwd = new edges(0, i + 1, 1, 1);
                edges backwd = new edges(i + 1, 0, 0, 1);
                rcities[0].neighbours.Add(i + 1, fwd);
                rcities[i + 1].neighbours.Add(0, backwd);
            }
            //add backward node edge
            for (int i = int.Parse(input[0]) + 1; i < len - 1; i++)
            {
                edges fwd = new edges(i , len -1 , 1, 1);
                edges backwd = new edges(len -1 , i, 0, 1);
                rcities[i].neighbours.Add(len -1 , fwd);
                rcities[len -1 ].neighbours.Add(i, backwd);
            }


            int flow = 0;
            while (true)
            {
                Dictionary<int, map> resultmaps = new Dictionary<int, map>();
                int min = bfs2(rcities, len -1 , resultmaps);
                if (min != -1)
                {
                    updateResidualGraph(rcities, len - 1, resultmaps, min);
                    flow = flow + min;
                }
                else
                    break;
            }

            for (int i = 1; i < int.Parse(input[0]) + 1; i++)
            {
                int chek = 0;
                foreach(KeyValuePair<int, edges> a in rcities[i].neighbours)
                {
                    if (a.Value.flow == 0 && a.Value.end != 0)
                    {
                        Console.Write(a.Value.end  - int.Parse(input[0]) + " ");
                        chek = 1;
                    }
                }
                if (chek == 0)
                    Console.Write("-1" + " ");
            }
            //Console.Write(flow);
            Console.Read();
        }

        static void updateResidualGraph(node[] rcities, int len, Dictionary<int, map> resultmaps, int minflow)
        {
            node curr = rcities[len];
            while (curr.key != rcities[0].key)
            {
                rcities[resultmaps[curr.key].parent].neighbours[curr.key].flow = rcities[resultmaps[curr.key].parent].neighbours[curr.key].flow - minflow;
                rcities[curr.key].neighbours[resultmaps[curr.key].parent].flow = rcities[curr.key].neighbours[resultmaps[curr.key].parent].flow + minflow;
                //rcities[curr.key].neighbours[resultmaps[curr.key].parent].state = 0;
               
                //if (rcities[resultmaps[curr.key].parent].neighbours[curr.key].flow == 0)
                //    rcities[resultmaps[curr.key].parent].neighbours[curr.key].state = 1;
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
                        //if key is added already then there is no point in adding it again in map cuz the path will be longer now

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
