using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class Grafos
    {
        public bool Direcionado { get; }
        
        public bool Ponderado { get; }

        public int Vertices { get; }

        public Grafos(bool direcionado, bool ponderado, int vertices)
        {
            Direcionado = direcionado;
            Ponderado = ponderado;
            Vertices = vertices;
        }

    }
}
