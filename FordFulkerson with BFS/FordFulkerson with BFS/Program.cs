using System;
using System.Collections.Generic;
namespace FordFulkerson_with_BFS
{
    class edges
    {
        public int start;
        public int end;
        public int flow;
        public int capacity;
        public int state;

        public edges(int s, int e, int f , int c)
        {
            start = s;
            end = e;
            capacity = c + capacity;
            flow = f + flow;
        }

        public edges(int s, int e, int f, int c,  int st)
        {
            start = s;
            end = e;
            capacity = c + capacity;
            flow = f + flow;
            state = st;
        }
    }

    class node
    {
        public int key;
        public Dictionary<int,edges> neighbours = new Dictionary<int, edges>();
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

            node[] cities = new node[int.Parse(input[0])];
            node[] rcities = new node[int.Parse(input[0])]; 

            for(int i = 0; i < int.Parse(input[0]); i++)
            {                
                rcities[i] = new node();
                rcities[i].key = i;                
            }

            for(int i = 0; i < int.Parse(input[1]); i++)
            {
                string[] temp = Console.ReadLine().Split();
                if (int.Parse(temp[0]) != int.Parse(temp[1]))
                {
                    if (!rcities[int.Parse(temp[0]) - 1].neighbours.ContainsKey(int.Parse(temp[1]) - 1))
                    {
                        edges fwd = new edges(int.Parse(temp[0]) - 1, int.Parse(temp[1]) - 1, int.Parse(temp[2]), int.Parse(temp[2]));
                        edges backwd = new edges(int.Parse(temp[1]) - 1, int.Parse(temp[0]) - 1, 0, int.Parse(temp[2]), 1);
                        rcities[int.Parse(temp[0]) - 1].neighbours.Add(int.Parse(temp[1]) - 1, fwd);
                        rcities[int.Parse(temp[1]) - 1].neighbours.Add(int.Parse(temp[0]) - 1, backwd);
                    }
                    else
                    {
                        rcities[int.Parse(temp[0]) - 1].neighbours[int.Parse(temp[1]) - 1].capacity = rcities[int.Parse(temp[0]) - 1].neighbours[int.Parse(temp[1]) - 1].capacity + int.Parse(temp[2]);
                        rcities[int.Parse(temp[0]) - 1].neighbours[int.Parse(temp[1]) - 1].flow = rcities[int.Parse(temp[0]) - 1].neighbours[int.Parse(temp[1]) - 1].flow + int.Parse(temp[2]);
                        rcities[int.Parse(temp[1]) - 1].neighbours[int.Parse(temp[0]) - 1].capacity = rcities[int.Parse(temp[1]) - 1].neighbours[int.Parse(temp[0]) - 1].capacity + int.Parse(temp[2]);
                    }
                }
            }

            int flow = 0;
            while(true)
            {
                Dictionary<int, map> resultmaps = new Dictionary<int, map>();
                int min = bfs2(rcities,int.Parse(input[0]) - 1, resultmaps);
                if (min != -1)
                {
                    updateResidualGraph(rcities, int.Parse(input[0]) - 1, resultmaps, min);
                    flow = flow + min;
                }
                else
                    break;
            }
            Console.Write(flow);
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
