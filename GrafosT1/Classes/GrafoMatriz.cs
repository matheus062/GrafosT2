using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class GrafoMatriz: Grafos
    {
        public int[,] Matriz { get; }

        public GrafoMatriz(bool direcionado, bool ponderado, int vertices) : base(direcionado, ponderado, vertices)
        {
            Matriz = new int[vertices, vertices];
        }
    }
}
