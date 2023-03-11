using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class GrafoLista: Grafos
    {
        public List<Aresta>[] Lista { get; }

        public GrafoLista(bool direcionado, bool ponderado, int vertices) : base(direcionado, ponderado, vertices)
        {
            Lista = new List<Aresta>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                Lista[i] = new List<Aresta>();
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
