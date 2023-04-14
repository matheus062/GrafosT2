using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class BreadthFirstSearch
    {
        //private int V; // número de vértices
        private List<int>[] adj; // lista de adjacências
        private Graph graph;

        public BreadthFirstSearch(Graph graph)
        {
            //V = v;
            this.graph = graph;

            adj = new List<int>[graph.Nodes];
            for (int i = 0; i < graph.Nodes; i++)
            {
                adj[i] = new List<int>();
            }
        }

        // Faz a busca em largura a partir de um vértice inicial
        public void BFS(int s)
        {
            // Marca todos os vértices como não visitados
            bool[] visited = new bool[graph.Nodes];

            // Cria uma fila para a busca em largura
            Queue<int> queue = new Queue<int>();

            // Marca o vértice inicial como visitado e o adiciona na fila
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Remove o vértice da frente da fila e o imprime
                s = queue.Dequeue();
                Console.Write(s + " ");

                // Pega todos os vértices adjacentes do vértice removido da fila
                // Se um vértice adjacente não foi visitado, ele é marcado como visitado e adicionado na fila
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
