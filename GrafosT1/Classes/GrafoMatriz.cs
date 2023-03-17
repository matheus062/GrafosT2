using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1.Classes
{
    public class GrafoMatriz : Grafos
    {
        public int[,] Matriz;
        public List<string> NomesVertices;

        public GrafoMatriz(bool direcionado, bool ponderado, List<string> nomesVertices) : base(direcionado, ponderado)
        {
            Matriz = new int[nomesVertices.Count, nomesVertices.Count];
            NomesVertices = nomesVertices;
            Vertices = nomesVertices.Count;

            for (int i = 0; i < nomesVertices.Count; i++)
            {
                for (int j = 0; j < nomesVertices.Count; j++)
                {
                    if (i == j)
                    {
                        Matriz[i, j] = -1;

                        continue;
                    }

                    InserirAresta(i, j, 0);
                }
            }
        }

        public int[,] GetMatriz()
        {
            return Matriz;
        }

        public override bool InserirVertice(string nome)
        {
            Vertices++;
            int[,] novaMatriz = new int[Vertices, Vertices];

            for (int i = 0; i < Vertices - 1; i++)
            {
                for (int j = 0; j < Vertices; j++)
                {
                    if (i == Vertices - 1)
                    {
                        novaMatriz[Vertices - 1, j] = 0;

                        continue;
                    }
                    else if (j == Vertices - 1)
                    {
                        novaMatriz[i, Vertices - 1] = 0;

                        continue;
                    }

                    novaMatriz[i, j] = Matriz[i, j];
                }
            }

            novaMatriz[Vertices - 1, Vertices - 1] = -1;
            Matriz = novaMatriz;
            NomesVertices.Add(nome);

            return true;
        }
        public override string LabelVertice(int indice)
        {
            return NomesVertices[indice];
        }


        public override bool InserirAresta(int origem, int destino, int peso = 1)
        {
            if (origem < 0 || origem >= Vertices || destino < 0 || destino >= Vertices)
            {
                throw new Exception("Os vértices de origem e destino devem estar dentro do intervalo [0, Vertices-1]");
            }
            else if (origem == destino)
            {
                return false;
            }

            peso = Ponderado ? peso : 1;
            Matriz[origem, destino] = peso;
            Arestas++;

            if (!Direcionado)
            {
                Matriz[destino, origem] = peso;
                Arestas++;
            }

            return true;
        }

        public override bool ExisteAresta(int origem, int destino)
        {
            return (Matriz[origem, destino] > 0) ? true : false;
        }

        public override float PesoAresta(int origem, int destino)
        {
            return (Matriz[origem, destino] > 0) ? Matriz[origem, destino] : 0;
        }

        public override void ImprimeGrafo()
        {
            Console.Write("  ");

            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(LabelVertice(i) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(LabelVertice(i) + " ");

                for (int j = 0; j < Vertices; j++)
                {
                    int peso = Matriz[i, j];
                    Console.Write(peso + " ");
                }

                Console.WriteLine();
            }
        }

        public override bool RemoverAresta(int origem, int destino)
        {
            Matriz[origem, destino] = 0;
            Arestas--;

            if (!Direcionado)
            {
                Matriz[destino, origem] = 0;
                Arestas--;
            }

            return true;
        }

        public override bool RemoverVertice(string label)
        {
            if (Vertices == 0)
            {
                return false;
            }

            int indexRemover = NomesVertices.IndexOf(label);

            if (indexRemover == -1)
            {
                return false;
            }

            NomesVertices.Remove(label);
            Vertices--;

            int indexI = 0, indexJ = 0;
            int[,] novaMatriz = new int[Vertices, Vertices];

            for (int i = 0; i < Vertices + 1; i++)
            {
                if (i == indexRemover)
                {
                    continue;
                }

                for (int j = 0; j < Vertices + 1; j++)
                {
                    if (j == indexRemover)
                    {
                        //if (Matriz[i, j] > 0)
                        //{
                        //    Arestas--;
                        //}

                        continue;
                    }

                    novaMatriz[indexI, indexJ] = Matriz[i, j];
                    indexJ++;
                }
                
                indexJ = 0;
                indexI++;
            }

            Matriz = novaMatriz;

            return true;
        }

        public override List<int> RetornarVizinhos(int origem)
        {
            List<int> lista = new List<int>();

            for (var i = 0; i < Vertices; i++)
            {
                if (i == origem)
                {
                    continue;
                }

                if (Matriz[origem, i] > 0)
                {
                    lista.Add(i);
                }
            }

            return lista;
        }
    }
}
