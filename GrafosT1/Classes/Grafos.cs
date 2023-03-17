using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public abstract class Grafos
    {
        public bool Direcionado { get; }

        public bool Ponderado { get; }

        private int vertices;

        public int Vertices { get => vertices; set => vertices = value; }
        public int Arestas { get; protected set; }

        public Grafos(bool direcionado, bool ponderado, int vertices)
        {
            Direcionado = direcionado;
            Ponderado = ponderado;
            Vertices = vertices;
            Arestas = 0;
        }

        public abstract void AdicionarAresta(int origem, int destino, int peso = 0);

        public abstract bool ExisteAresta(int origem, int destino);

        public abstract int PesoAresta(int origem, int destino);

        public abstract void RemoveAresta(int origem, int destino);

        public void AdicionarVertice()
        {
            vertices++;
        }

    }
}
