using System;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Xml.Linq;

namespace Graph
{
    public abstract class Graph
    {
        public Graph(
            bool directed = false,
            bool weighted = false,
            int vertexes = 0,
            int nodes = 0
        )
        {
            Directed = directed;
            Weighted = weighted;
            Vertexes = vertexes;
            Nodes = nodes;
        }

        public bool Directed { get; protected set; }

        public bool Weighted { get; protected set; }

        public int Vertexes { get; protected set; }

        public int Nodes { get; protected set; }

        public abstract bool vertexInsert(string name);

        public abstract bool vertexDelete(string name);

        public abstract string vertexLabel(int vertex);

        public abstract List<int> getNeighbors(int vertex);

        public abstract bool nodeInsert(int from, int to, int weight = 1);

        public abstract bool nodeDelete(int from, int to);

        public abstract bool nodeExists(int from, int to);

        public abstract float nodeWeight(int from, int to);

        public abstract void graphPrint();

        public bool loadFile(string path)
        {
            if (!File.Exists(path)) throw new Exception("Arquivo não encontrado.");

            bool setted = false;

            foreach (string line in File.ReadLines(path))
            {
                string[] items = line.Split(' ');

                if (!setted)
                {
                    setted = true;
                    Vertexes = Convert.ToInt32(items[0]);
                    Nodes = Convert.ToInt32(items[1]);
                    Directed = Convert.ToBoolean(items[2]);
                    Weighted = Convert.ToBoolean(items[3]);

                    continue;
                }

                // TODO : Processar as outras linhas do arquivo.
            }


            return true;
        }

    }

}
