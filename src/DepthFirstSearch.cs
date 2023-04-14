using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DepthFirstSearch
    {
        //private int numVertices;
        private List<int>[] adjacency;
        private Graph graph;

        public DepthFirstSearch(Graph graph)
        {
            this.graph = graph;
            adjacency = new List<int>[graph.Nodes];
            for (int i = 0; i < graph.Nodes; i++)
            {
                adjacency[i] = new List<int>();
            }
        }

        public void AdicionarAresta(int origem, int destino)
        {
            adjacency[origem].Add(destino);
        }

        public void BuscaProfundidade(int verticeInicial)
        {
            bool[] visitado = new bool[graph.Nodes];
            BuscaProfundidadeRecursiva(verticeInicial, visitado);
        }

        private void BuscaProfundidadeRecursiva(int vertice, bool[] visitado)
        {
            visitado[vertice] = true;
            Console.Write(vertice + " ");

            foreach (int adjacente in adjacency[vertice])
            {
                if (!visitado[adjacente])
                {
                    BuscaProfundidadeRecursiva(adjacente, visitado);
                }
            }
        }
    }
}
