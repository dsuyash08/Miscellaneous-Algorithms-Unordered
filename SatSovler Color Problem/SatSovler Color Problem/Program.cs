using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatSovler_Color_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int[] nodes = new int[int.Parse(input[0])];
            int[] colors = new int[] { 1, 2, 3 };
            List<int[]> edges = new List<int[]>();
            List<List<int>> clauses = new List<List<int>>();

            for (int i = 0; i < int.Parse(input[0]); i++)
                nodes[i] = i + 1;

            for(int i = 0; i < int.Parse(input[1]); i++)
            {
                string[] temps = Console.ReadLine().Split();
                int[] edg = new int[2];
                edg[0] = int.Parse(temps[0]);
                edg[1] = int.Parse(temps[1]);
                edges.Add(edg);
            }

            //every row should have only one colour
            foreach(int i in nodes)
            {
                List<int> temp = new List<int>();
                foreach (int k in colors)
                    temp.Add(varnum(i, k));
                addPrimaryClause(temp,clauses);
            }

            for (int i = 0; i < int.Parse(input[1]); i++)
                addSecClauses(clauses, edges[i]);

            Console.WriteLine(clauses.Count + " " + int.Parse(input[0]) * 3);
            foreach (List<int> a in clauses)
            {
                foreach (int b in a)
                {
                    Console.Write(b + " ");
                }
                Console.Write(0 + " \n");
            }

            Console.Read();

        }

        static void addSecClauses(List<List<int>> clauses, int[] edge)
        {           
            for(int i = 0; i < 3; i++)
            {                
                List<int> negative = new List<int>();
                negative.Add(-varnum(edge[0], i + 1));
                negative.Add(-varnum(edge[1], (i + 1)));
                clauses.Add(negative);
            }

        }

        static int varnum(int i, int j)
        { return 3 * (i - 1) + j; }

        static void addPrimaryClause(List<int> temp, List<List<int>> clauses)
        {
            clauses.Add(temp);
            for (int i = 0; i < 2; i++)
            {                
                for (int j = i + 1; j < 3; j++)
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
