using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class GrafoMatriz: Grafos
    {
        public int[,] Matriz;

        public GrafoMatriz(bool direcionado, bool ponderado, int vertices) : base(direcionado, ponderado, vertices)
        {
            Matriz = new int[vertices, vertices];
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    Matriz[i, j] = -1; // valor inválido para indicar que não há aresta
                }
            }
            Vertices = vertices;
        }

        public int[,] GetMatriz()
        {
            return Matriz;
        }

        public void AdicionarVertice()
        {
            base.AdicionarVertice();

            // Adicionar uma nova linha e uma nova coluna na matriz de adjacência
            int[,] novaMatriz = new int[Vertices, Vertices];
            for (int i = 0; i < Vertices - 1; i++)
            {
                for (int j = 0; j < Vertices - 1; j++)
                {
                    novaMatriz[i, j] = Matriz[i, j];
                }
            }
            Matriz = novaMatriz;
        }

        public override void AdicionarAresta(int origem, int destino, int peso = 0)
        {
            // Verificar se a origem e destino são válidos
            if (origem < 0 || origem >= Vertices || destino < 0 || destino >= Vertices)
                throw new Exception("Os vértices de origem e destino devem estar dentro do intervalo [0, Vertices-1]");

            // Adicionar a aresta na matriz de adjacência
            if (Ponderado)
            {
                if (!Direcionado)
                {
                    Matriz[origem, destino] = peso;
                    Matriz[destino, origem] = peso;
                }
                else
                {
                    Matriz[origem, destino] = peso;
                }
            }
            else
            {
                if (!Direcionado)
                {
                    Matriz[origem, destino] = 1;
                    Matriz[destino, origem] = 1;
                }
                else
                {
                    Matriz[origem, destino] = 1;
                }
            }
        }

        public void ImprimirGrafoMatriz()
        {
            Console.Write("  ");
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < Vertices; j++)
                {
                    int peso = Matriz[i, j];
                    if (Ponderado && peso > 0)
                    {
                        Console.Write(peso + " ");
                    }
                    else if (!Ponderado && peso == 1)
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
