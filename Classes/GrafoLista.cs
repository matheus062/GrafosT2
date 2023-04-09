using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class GrafoLista : Grafos
    {
        public List<Aresta>[] Lista;
        public List<string> NomesVertices;
        public GrafoLista(bool direcionado, bool ponderado, List<string> nomesVertices) : base(direcionado, ponderado, nomesVertices.Count)
        {
            NomesVertices = nomesVertices;
            Lista = new List<Aresta>[nomesVertices.Count];

            for (int i = 0; i < nomesVertices.Count; i++)
            {
                Lista[i] = new List<Aresta>();
            }
        }

        public List<Aresta>[] GetLista()
        {
            return Lista;
        }

        public override bool InserirVertice(string label)
        {
            List<Aresta>[] novaLista = new List<Aresta>[++Vertices];

            for (int i = 0; i < Vertices - 1; i++)
            {
                novaLista[i] = Lista[i];
            }

            novaLista[Vertices - 1] = new List<Aresta>();
            Lista = novaLista;
            NomesVertices.Add(label);

            return true;
        }

        public override bool RemoverVertice(string label)
        {
            if (Vertices == 0)
            {
                return false;
            }


            int indexRemover = NomesVertices.IndexOf(label);

            if (indexRemover == -1)
            {
                return false;
            }

            int indexNovo = 0;
            List<Aresta>[] novaLista = new List<Aresta>[Vertices - 1];

            NomesVertices.Remove(label);

            for (int i = 0; i < Vertices; i++)
            {
                if (indexRemover == i)
                {
                    continue;
                }

                foreach (var aresta in Lista[i])
                {
                    if (aresta.Destino == indexRemover)
                    {
                        Lista[i].Remove(aresta);

                        break;
                    }
                }

                novaLista[indexNovo] = Lista[i];
                indexNovo++;
            }

            Lista = novaLista;
            Vertices--;

            return true;
        }

        public override string LabelVertice(int indice)
        {
            return NomesVertices[indice];
        }


        public override List<int> RetornarVizinhos(int vertice)
        {
            List<int> vizinhos = new();

            if (vertice >= Lista.Length || vertice < 0)
            {
                return vizinhos;
            }

            vizinhos = Lista.ElementAt(vertice).Select(aresta => aresta.Peso).ToList();

            return vizinhos;
        }

        public override bool InserirAresta(int origem, int destino, int peso = 1)
        {
            if (!Direcionado)
            {
                Lista[destino].Add(new Aresta(origem, peso));
            }

            Lista[origem].Add(new Aresta(destino, peso));
            Arestas++;

            return true;
        }

        public override bool RemoverAresta(int origem, int destino)
        {
            Lista[origem].Remove(Lista[origem].First(a => a.Destino == destino));

            if (!Direcionado)
            {
                Lista[destino].Remove(Lista[destino].First(b => b.Destino == origem));
            }

            return true;

        }

        public override bool ExisteAresta(int origem, int destino)
        {
            foreach (var aresta in Lista[origem])
            {
                if (aresta.Destino == destino)
                {
                    return true;
                }
            }

            return false;
        }

        public override float PesoAresta(int origem, int destino)
        {
            foreach (var aresta in Lista[origem])
            {
                if (aresta.Destino == destino)
                {
                    return aresta.Peso;
                }
            }

            return 0;
        }



        public override void ImprimeGrafo()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(LabelVertice(i));
                foreach (var aresta in Lista[i])
                {
                    Console.Write($"({aresta.Destino}, {aresta.Peso})");
                }
                Console.WriteLine("\r");
            }
        }

        public void ImprimeArestaAdjacente(int i)
        {
            List<int> vizinhos = this.RetornarVizinhos(i);

            foreach (int vizinho in vizinhos)
            {
                Console.WriteLine($"{vizinho} ");
            }
        }

    }

    public class Aresta
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
