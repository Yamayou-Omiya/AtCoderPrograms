using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int n, m;
    static int[] a = new int[200010];
    static int[] u = new int[200010], v = new int[200010], b = new int[200010];
    static List<(int to, int weight)>[] graph;
    static long[] cost; // Changed the type of 'cost' from int[] to long[]
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (n, m) = (int.Parse(input[0]), int.Parse(input[1]));

        input = Console.ReadLine().Split(' ');
        for(int i = 1; i <= n; i++) a[i] = int.Parse(input[i-1]);

        for(int i = 1; i <= m; i++){
            input = Console.ReadLine().Split(' ');
            (u[i], v[i], b[i]) = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
        }

        graph = new List<(int to, int weight)>[n + 1];
        for (int i = 0; i <= n; i++) graph[i] = new List<(int to, int weight)>();
        for (int i = 1; i <= m; i++)
        {
            graph[u[i]].Add((v[i], b[i]));
            graph[v[i]].Add((u[i], b[i]));
        }

        Dijkstra();

        for (int i = 2; i <= n; i++)
        {
            Console.Write(cost[i] + " ");
        }
    }

    static void Dijkstra()
    {
        cost = Enumerable.Repeat(long.MaxValue, n + 1).ToArray();
        var pq = new PriorityQueue<(int vertex, long cost), long>();
        cost[1] = a[1]; 
        pq.Enqueue((1, a[1]), a[1]);

        while (pq.Count > 0)
        {
            var (current, currentCost) = pq.Dequeue();
            if (cost[current] < currentCost) continue;

            foreach (var (next, weight) in graph[current])
            {
                long nextCost = currentCost + weight;
                if (cost[next] > nextCost)
                {
                    cost[next] = nextCost;
                    pq.Enqueue((next, nextCost), nextCost);
                }
            }
        }

        // 頂点の重みを最終コストに加算
        for (int i = 2; i <= n; i++)
        {
            cost[i] += a[i] - a[1];
        }
    }
}
