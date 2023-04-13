﻿using System;
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
            int nodes = 0,
            int edges = 0
        )
        {
            Directed = directed;
            Weighted = weighted;
            Nodes = nodes;
            Edges = edges;
        }

        public bool Directed { get; protected set; }

        public bool Weighted { get; protected set; }

        public int Nodes { get; protected set; }

        public int Edges { get; protected set; }

        public abstract bool NodeInsert(string name);

        public abstract bool NodeDelete(string name);

        public abstract string NodeLabel(int node);

        public abstract List<int> GetNeighbors(int node);

        public abstract bool EdgeInsert(int from, int to, int weight = 1);

        public abstract bool EdgeDelete(int from, int to);

        public abstract bool EdgeExists(int from, int to);

        public abstract float EdgeWeight(int from, int to);

        public abstract void GraphPrint();

        public bool LoadFile(string path)
        {
            if (!File.Exists(path)) throw new Exception("Arquivo não encontrado.");

            bool setted = false;

            foreach (string line in File.ReadLines(path))
            {
                string[] items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!setted)
                {
                    setted = true;
                    Nodes = Convert.ToInt32(items[0]);
                    Edges = Convert.ToInt32(items[1]);
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
