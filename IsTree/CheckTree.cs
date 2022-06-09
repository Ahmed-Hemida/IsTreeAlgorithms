using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsATree
{


    public class CheckTree
    {

        //===============================================================================
        //Your Code is Here:
       public static  List<int>[] adj;
        public static int [] visited;// <2 for black 1 to in gray , 0 for white >
        public static bool IsTree(string[] vertices, List<KeyValuePair<string, string>> edges)
        {

            CheckTree.adj = new List<int>[vertices.GetLength(0)];
            CheckTree.visited = new int[vertices.GetLength(0)];
              for (int i = 0; i < vertices.GetLength(0); ++i)
            {
                CheckTree.adj[i] = new List<int>();
                CheckTree.visited[i] =0;
            }
                 

            int v;
            int e;
            foreach (KeyValuePair<string, string> node in edges)
              {
               v = Int32.Parse(node.Key.Trim(new Char[] { 'A' }))-1;
               e = Int32.Parse(node.Value.Trim(new Char[] { 'A' }))-1;
              
                if (v<vertices.GetLength(0)&& e<vertices.GetLength(0))
                {
                //    Console.WriteLine(" v = {0} , e = {1} , v size = {2} , e size = {2}", v,e, CheckTree.adj.GetLength(0), CheckTree.adj[v].Count);
                    CheckTree.adj[v].Add(e);

                }
            }
            int vertice = 0;
          //  Console.WriteLine(" =============================   ");
            foreach (List<int> node in CheckTree.adj)
            {
                bool result = true;
                foreach (int neighbor in node)
                {
                   
                    if (CheckTree.visited[neighbor] == 0)
                    {
                        CheckTree.visited[neighbor]=1; // Gray color 
                        result = dfs_Visit(neighbor);
                        if (!result) return result;
                    }
                  
                }
               CheckTree.visited[vertice]=2; // black color 
                vertice++;
            }


            return true;
        }

        public static bool dfs_Visit(int node)
        {
           bool result = true;
            for (int i = 0; i < CheckTree.adj[node].Count; i++)
            { 
                int neighbor = CheckTree.adj[node][i];
                if (CheckTree.visited[neighbor] == 1 && CheckTree.adj[neighbor].Count > 0)
                {
                    return !result;
                }
                if (CheckTree.visited[neighbor] == 0)
                {
                    CheckTree.visited[neighbor] = 1; // Gray color 
                    result = dfs_Visit(neighbor);
                    if (!result) return result;
                }
                 CheckTree.visited[neighbor] = 2; // black color 
            }
            return result;

        }


        //===============================================================================

        //===============================================================================
    }
}
