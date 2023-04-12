namespace Graph
{
    public class GrafoLista : Graph
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

        public override bool vertexInsert(string label)
        {
            List<Aresta>[] novaLista = new List<Aresta>[++Vertexes];

            for (int i = 0; i < Vertexes - 1; i++)
            {
                novaLista[i] = Lista[i];
            }

            novaLista[Vertexes - 1] = new List<Aresta>();
            Lista = novaLista;
            NomesVertices.Add(label);

            return true;
        }

        public override bool vertexDelete(string label)
        {
            if (Vertexes == 0)
            {
                return false;
            }


            int indexRemover = NomesVertices.IndexOf(label);

            if (indexRemover == -1)
            {
                return false;
            }

            int indexNovo = 0;
            List<Aresta>[] novaLista = new List<Aresta>[Vertexes - 1];

            NomesVertices.Remove(label);

            for (int i = 0; i < Vertexes; i++)
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
            Vertexes--;

            return true;
        }

        public override string vertexLabel(int indice)
        {
            return NomesVertices[indice];
        }


        public override List<int> getNeighbors(int vertice)
        {
            List<int> vizinhos = new();

            if (vertice >= Lista.Length || vertice < 0)
            {
                return vizinhos;
            }

            vizinhos = Lista.ElementAt(vertice).Select(aresta => aresta.Peso).ToList();

            return vizinhos;
        }

        public override bool nodeInsert(int origem, int destino, int peso = 1)
        {
            if (!Directed)
            {
                Lista[destino].Add(new Aresta(origem, peso));
            }

            Lista[origem].Add(new Aresta(destino, peso));
            Nodes++;

            return true;
        }

        public override bool nodeDelete(int origem, int destino)
        {
            Lista[origem].Remove(Lista[origem].First(a => a.Destino == destino));

            if (!Directed)
            {
                Lista[destino].Remove(Lista[destino].First(b => b.Destino == origem));
            }

            return true;

        }

        public override bool nodeExists(int origem, int destino)
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

        public override float nodeWeight(int origem, int destino)
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



        public override void graphPrint()
        {
            for (int i = 0; i < Vertexes; i++)
            {
                Console.Write(vertexLabel(i));
                foreach (var aresta in Lista[i])
                {
                    Console.Write($"({aresta.Destino}, {aresta.Peso})");
                }
                Console.WriteLine("\r");
            }
        }

        public void ImprimeArestaAdjacente(int i)
        {
            List<int> vizinhos = this.getNeighbors(i);

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
