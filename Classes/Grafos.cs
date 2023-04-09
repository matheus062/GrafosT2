namespace GrafosT1.Classes
{
    public abstract class Grafos
    {
        public Grafos(bool direcionado, bool ponderado, int vertices = 0)
        {
            Direcionado = direcionado;
            Ponderado = ponderado;
            Vertices = vertices;
            Arestas = 0;
        }

        public bool Direcionado { get; }

        public bool Ponderado { get; }

        public int Vertices { get; protected set; }

        public int Arestas { get; protected set; }

        public abstract bool InserirVertice(string label);

        public abstract bool RemoverVertice(string label);

        public abstract string LabelVertice(int indice);

        public abstract List<int> RetornarVizinhos(int vertice);

        public abstract bool InserirAresta(int origem, int destino, int peso = 1);

        public abstract bool RemoverAresta(int origem, int destino);

        public abstract bool ExisteAresta(int origem, int destino);

        public abstract float PesoAresta(int origem, int destino);

        public abstract void ImprimeGrafo();

    }

}
