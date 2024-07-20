using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = input[0], M = input[1];

        var A = Console.ReadLine().Split().Select(long.Parse).ToArray();

        var G = new List<(int, long)>[N];
        for (int i = 0; i < N; i++)
            G[i] = new List<(int, long)>();

        for (int i = 0; i < M; i++)
        {
            var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int U = edge[0] - 1, V = edge[1] - 1;
            long B = edge[2];
            G[U].Add((V, B + A[V]));
            G[V].Add((U, B + A[U]));
        }

        var dist = Dijkstra(G, 0);

        for (int i = 0; i < N; i++)
            dist[i] += A[0];

        Console.WriteLine(string.Join(" ", dist.Skip(1)));
    }

    static long[] Dijkstra(List<(int, long)>[] G, int s)
    {
        const long INF = 1L << 60;
        var dist = Enumerable.Repeat(INF, G.Length).ToArray();
        dist[s] = 0;

        var pq = new PriorityQueue<(long, int), long>();
        pq.Enqueue((0, s), 0);

        while (pq.TryDequeue(out var item, out _))
        {
            var (d, v) = item;
            if (d > dist[v]) continue;

            foreach (var (u, weight) in G[v])
            {
                var nd = d + weight;
                if (dist[u] > nd)
                {
                    dist[u] = nd;
                    pq.Enqueue((nd, u), nd);
                }
            }
        }

        return dist;
    }
}