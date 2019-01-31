using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatSolver_Hamiltonian
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int varCount = int.Parse(input[0]);
            int[] nodes = new int[int.Parse(input[0])];
            int[] path = new int[int.Parse(input[0])];
            List<int[]> edges = new List<int[]>();
            List<List<int>> clauses = new List<List<int>>();

            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                nodes[i] = i + 1;
                path[i] = i + 1;
            }

            List<int[]> edgeinfo = new List<int[]>();
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                int[] temp = new int[int.Parse(input[0])];
                edgeinfo.Add(temp);
            }

            for (int i = 0; i < int.Parse(input[1]); i++)
            {
                string[] temps = Console.ReadLine().Split();
                int[] edg = new int[2];
                edg[0] = int.Parse(temps[0]);
                edg[1] = int.Parse(temps[1]);

                edgeinfo[edg[0] - 1][edg[1] - 1] = 1;
                edgeinfo[edg[1] - 1][edg[0] - 1] = 1;
                edges.Add(edg);
            }

            //every row should have only one colour
            foreach (int i in nodes)
            {
                List<int> temp = new List<int>();
                foreach (int k in path)
                    temp.Add(varnum(i, k, varCount));
                addPrimaryClause(temp, clauses);
            }

            //every column should have only one colour
            foreach (int i in path)
            {
                List<int> temp = new List<int>();
                foreach (int k in nodes)
                    temp.Add(varnum(k, i,varCount));
                addPrimaryClause(temp, clauses);
            }

            addSecClauses(clauses, edges ,edgeinfo, int.Parse(input[0]));
            Console.WriteLine(clauses.Count + " " + varCount*varCount);
            foreach(List<int> a in clauses)
            {
                foreach(int b in a)
                {
                    Console.Write(b + " ");
                }
                Console.Write(0 + " \n");
            }


            Console.Read();

        }

        static void addSecClauses(List<List<int>> clauses, List<int[]> edge, List<int[]> edgeinfo, int varCount)
        {

            for(int i = 0; i < edgeinfo.Count; i++)
            {
                for (int j = 0; j < varCount; j++)
                {
                    if (edgeinfo[i][j] == 0  && i != j)
                    {
                        for (int k = 1; k < varCount; k++)
                        {                            
                            List<int> negative = new List<int>();
                                                        
                            negative.Add(-varnum((i + 1), (k), varCount));
                            negative.Add(-varnum((j + 1), (k + 1), varCount));

                            clauses.Add(negative);
                        }
                    }
                }
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    List<int> positive = new List<int>();
            //    List<int> negative = new List<int>();
            //    for (int j = 0; j < 2; j++)
            //    {
            //        positive.Add(varnum(edge[j], i + 1));
            //        negative.Add(varnum(-edge[j], -(i + 1)));
            //    }
            //    clauses.Add(positive);
            //    clauses.Add(negative);
            //}

        }

        static int varnum(int i, int j, int varCount)
        { return varCount * (i - 1) + j; }

        static void addPrimaryClause(List<int> temp, List<List<int>> clauses)
        {
            clauses.Add(temp);
            for (int i = 0; i < temp.Count - 1; i++)
            {
                for (int j = i + 1; j < temp.Count; j++)
                {
                    List<int> tmp = new List<int>();
                    tmp.Add(-temp[i]);
                    tmp.Add(-temp[j]);
                    clauses.Add(tmp);
                }
            }
        }

    }
}
