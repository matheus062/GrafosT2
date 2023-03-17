using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public abstract class Grafos
    {
        public bool Direcionado { get; }

        public bool Ponderado { get; }

        public int Vertices { get; protected set; }

        public int Arestas { get; protected set; }

        public Grafos(bool direcionado, bool ponderado)
        {
            Direcionado = direcionado;
            Ponderado = ponderado;
            Vertices = 0;
            Arestas = 0;
        }

        public abstract bool inserirVertice(string label);

        public abstract bool removerVertice(string label);

        public abstract string labelVertice(int indice);

        public abstract List<int> retornarVizinhos(int vertice);

        public abstract bool inserirAresta(int origem, int destino, int peso = 1);

        public abstract bool removerAresta(int origem, int destino);

        public abstract bool existeAresta(int origem, int destino);

        public abstract float pesoAresta(int origem, int destino);

        public abstract void imprimeGrafo();

    }

}
