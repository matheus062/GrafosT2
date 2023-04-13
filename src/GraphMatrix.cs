namespace Graph
{
    public class GraphMatrix : Graph
    {
        public int[,] Matrix;
        public List<string> NodeNames;

        public GraphMatrix(
            bool directed = false,
            bool weighted = false,
            int nodes = 0,
            int edges = 0,
            List<string>? nodeNames = null
        ) : base(directed, weighted, nodes, edges)
        {
            NodeNames = nodeNames ?? new List<string>();
            Matrix = new int[NodeNames.Count, NodeNames.Count];
            Edges = NodeNames.Count;

            for (int i = 0; i < NodeNames.Count; i++)
            {
                for (int j = 0; j < NodeNames.Count; j++)
                {
                    if (i == j)
                    {
                        Matrix[i, j] = -1;

                        continue;
                    }

                    EdgeInsert(i, j, 0);
                }
            }
        }

        public override bool NodeInsert(string name)
        {
            Nodes++;
            int[,] newMatrix = new int[Nodes, Nodes];

            for (int i = 0; i < Nodes - 1; i++)
            {
                for (int j = 0; j < Nodes; j++)
                {
                    if (i == Nodes - 1)
                    {
                        newMatrix[Nodes - 1, j] = 0;

                        continue;
                    }
                    else if (j == Nodes - 1)
                    {
                        newMatrix[i, Nodes - 1] = 0;

                        continue;
                    }

                    newMatrix[i, j] = Matrix[i, j];
                }
            }

            newMatrix[Nodes - 1, Nodes - 1] = -1;
            Matrix = newMatrix;
            NodeNames.Add(name);

            return true;
        }

        public override bool NodeDelete(string name)
        {
            if (Nodes == 0)
            {
                return false;
            }

            int indexDel = NodeNames.IndexOf(name);

            if (indexDel == -1)
            {
                return false;
            }

            NodeNames.Remove(name);
            Nodes--;

            int indexI = 0, indexJ = 0;
            int[,] newMatrix = new int[Nodes, Nodes];

            for (int i = 0; i < Nodes + 1; i++)
            {
                if (i == indexDel)
                {
                    continue;
                }

                for (int j = 0; j < Nodes + 1; j++)
                {
                    if (j == indexDel)
                    {
                        //if (Matriz[i, j] > 0)
                        //{
                        //    Arestas--;
                        //}

                        continue;
                    }

                    newMatrix[indexI, indexJ] = Matrix[i, j];
                    indexJ++;
                }

                indexJ = 0;
                indexI++;
            }

            Matrix = newMatrix;

            return true;
        }

        public override string NodeLabel(int node)
        {
            return NodeNames[node];
        }

        public override List<int> GetNeighbors(int node)
        {
            List<int> neighbors = new List<int>();

            for (var i = 0; i < Nodes; i++)
            {
                if (i == node)
                {
                    continue;
                }

                if (Matrix[node, i] > 0)
                {
                    neighbors.Add(i);
                }
            }

            return neighbors;
        }

        public override bool EdgeInsert(int from, int to, int weight = 1)
        {
            if (from < 0 || from >= Nodes || to < 0 || to >= Nodes)
            {
                throw new Exception("Os vértices de origem e destino devem estar dentro do intervalo [0, Vertices-1]");
            }
            else if (from == to)
            {
                return false;
            }

            weight = Weighted ? weight : 1;
            Matrix[from, to] = weight;
            Edges++;

            if (!Directed)
            {
                Matrix[to, from] = weight;
                Edges++;
            }

            return true;
        }

        public override bool EdgeDelete(int from, int to)
        {
            Matrix[from, to] = 0;
            Edges--;

            if (!Directed)
            {
                Matrix[from, to] = 0;
                Edges--;
            }

            return true;
        }

        public override bool EdgeExists(int from, int to)
        {
            return (Matrix[from, to] > 0) ? true : false;
        }

        public override float EdgeWeight(int from, int to)
        {
            return (Matrix[from, to] > 0) ? Matrix[from, to] : 0;
        }

        public override void GraphPrint()
        {
            Console.Write("  ");

            for (int i = 0; i < Nodes; i++)
            {
                Console.Write(NodeLabel(i) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < Nodes; i++)
            {
                Console.Write(NodeLabel(i) + " ");

                for (int j = 0; j < Nodes; j++)
                {
                    int weight = Matrix[i, j];
                    Console.Write(weight + " ");
                }

                Console.WriteLine();
            }
        }

        public int[,] GetMatrix()
        {
            return Matrix;
        }
    }
}
