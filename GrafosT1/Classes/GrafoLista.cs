using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class GrafoLista: Grafos
    {
        public List<Aresta>[] Lista;
        public GrafoLista(bool direcionado, bool ponderado, int vertices) : base(direcionado, ponderado, vertices)
        {
            Lista = new List<Aresta>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                Lista[i] = new List<Aresta>();
            }
        }

        public List<Aresta>[] GetLista()
        {
            return Lista;
        }

        public void AdicionarVertice()
        {
            base.AdicionarVertice();
            List<Aresta>[] novaLista = new List<Aresta>[Vertices];
            for (int i = 0; i < Vertices - 1; i++)
            {
                novaLista[i] = Lista[i];
            }
            novaLista[Vertices - 1] = new List<Aresta>();
            Lista = novaLista;
        }

        public override void AdicionarAresta(int origem, int destino, int peso = 0)
        {
            if (!Direcionado)
            {
                Lista[destino].Add(new Aresta(origem, peso));
            }
            Lista[origem].Add(new Aresta(destino, peso));
            base.Arestas++;
        }

        public void ImprimeGrafoLista()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write($"Vertice {i}: ");
                foreach (var aresta in Lista[i])
                {
                    Console.Write($"({aresta.Destino}, {aresta.Peso})");
                }
                Console.WriteLine("\r");
            }
        }
    }

    public struct Aresta
    {
        public int Destino;
        public int Peso;

        public Aresta(int destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }
}
