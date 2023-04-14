using Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graph
{
    public class Dijkstra
    {
        private List<Fragas> adjacencyList = new List<Fragas>();
        private Graph graph;
        private int[] _distances;
        public Dijkstra(Graph graph)
        {
            this.graph = graph;

            for (int i = 0; i < graph.Nodes; i++)
            {
                adjacencyList.Add(new Fragas(i));
            }
        }

        //public void AddEdge(int source, int destination, int weight)
        //{
        //    adjacencyList[source].Add((destination, weight));
        //    adjacencyList[destination].Add((source, weight));
        //}

        public int[] FuncaoDijkstra(int source)
        {
            adjacencyList[source].distance = 0;
            List<int> neighbors = new List<int>();
            bool allClosed = false;           

           /* do
            {
                neighbors = graph.GetNeighbors(source);

                foreach (int index in neighbors)
                {
                    //graph.EdgeWeight(source, index)

                    int currentVertex = GetMinimumDistance(adjacencyList[source].distance, graph.EdgeWeight(source, index));
                }

            } while (allClosed);


            foreach (int i = 0; i < graph.Nodes - 1; i++)
            {
                int currentVertex = GetMinimumDistance(distances, visited);

                visited[currentVertex] = true;

                foreach ((int, int) neighbor in adjacencyList[currentVertex])
                {
                    int adjacentVertex = neighbor.Item1;
                    int edgeWeight = neighbor.Item2;

                    if (!visited[adjacentVertex] && distances[currentVertex] != int.MaxValue
                        && distances[currentVertex] + edgeWeight < distances[adjacentVertex])
                    {
                        distances[adjacentVertex] = distances[currentVertex] + edgeWeight;
                    }
                }
            }
            this._distances = distances;


            //return distances;
           */
            return new int[] { 0 };
        }

        private int GetMinimumDistance(int[] distances, bool[] visited)
        {
            int minDistance = int.MaxValue;
            int minVertex = 0;

            for (int i = 0; i < graph.Nodes; i++)
            {
                if (!visited[i] && distances[i] <= minDistance)
                {
                    minDistance = distances[i];
                    minVertex = i;
                }
            }

            return minVertex;
        }

        public void PrintTest()
        {
            //int[] distances = graph.FuncaoDijkstra();
            for (int i = 0; i < _distances.Length; i++)
            {
                Console.WriteLine($"\r\nDistância mais curta do vértice 0 ao vértice {i} é {_distances[i]}");
            }
        }


        //public void ImprimeGrafoDijkstra()
        //{
        //    Dijkstra graph = new Dijkstra(6);

        //    graph.AddEdge(0, 1, 2);
        //    graph.AddEdge(0, 2, 4);
        //    graph.AddEdge(1, 2, 1);
        //    graph.AddEdge(1, 3, 7);
        //    graph.AddEdge(2, 4, 3);
        //    graph.AddEdge(3, 4, 1);
        //    graph.AddEdge(3, 5, 5);
        //    graph.AddEdge(4, 5, 2);

        //    int[] distances = graph.FuncaoDijkstra(0);

        //    for (int i = 0; i < distances.Length; i++)
        //    {
        //        Console.WriteLine($"\r\nDistância mais curta do vértice 0 ao vértice {i} é {distances[i]}");
        //    }
        //}

    }


    public class Fragas
    {
        public int index { get; set; }
        public bool closed { get; set; }
        public int distance { get; set; }
        public int lastIndex { get; set; }

        public Fragas(int index, bool closed = false, int distance = -1, int lastIndex = 9999)
        {
            this.index = index;
            this.closed = closed;
            this.distance = distance;
            this.lastIndex = lastIndex;
        }
    }

}
