using GrafosT1.Classes;

Console.WriteLine("Meus Grafos", "\n");

Console.WriteLine("Grafo Lista", "\n");

GrafoLista grafoLista = new GrafoLista(false, true, 3);

// Adiciona algumas arestas
grafoLista.AdicionarAresta(0, 1, 2);
grafoLista.AdicionarAresta(1, 2, 3);
grafoLista.AdicionarAresta(2, 0, 1);

// Exibe a lista de adjacência
grafoLista.ImprimeGrafoLista();

// Adiciona um novo vértice e exibe a nova lista de adjacência
grafoLista.AdicionarVertice();
grafoLista.AdicionarAresta(3, 2, 5);

grafoLista.ImprimeGrafoLista();


Console.WriteLine("\n", "Grafo Matriz", "\n");

GrafoMatriz grafoMatriz = new GrafoMatriz(false, true, 4);

// Adicionando arestas
grafoMatriz.AdicionarAresta(0, 1, 3);
grafoMatriz.AdicionarAresta(1, 2, 2);
grafoMatriz.AdicionarAresta(2, 3, 4);
grafoMatriz.AdicionarAresta(3, 0, 5);

// Imprimindo grafo

grafoMatriz.ImprimirGrafoMatriz();

//for (int i = 0; i < grafoMatriz.Vertices; i++)
//{
//    for (int j = 0; j < grafoMatriz.Vertices; j++)
//    {
//        Console.Write(grafoMatriz.Matriz[i, j] + "\t");
//    }
//    Console.WriteLine();
//}