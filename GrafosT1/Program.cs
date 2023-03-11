using GrafosT1.Classes;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

List<string> nomesLista = new List<string> { "A", "B", "C" };
GrafoLista grafoLista = new GrafoLista(false, true, 3, nomesLista);

// Adiciona algumas arestas
grafoLista.AdicionarAresta(0, 1, 2);
grafoLista.AdicionarAresta(1, 2, 3);
grafoLista.AdicionarAresta(2, 0, 1);

Console.WriteLine("Grafo Lista");
Console.WriteLine("\r");
// Exibe a lista de adjacência
grafoLista.ImprimeGrafoLista();

// Adiciona um novo vértice e exibe a nova lista de adjacência
grafoLista.AdicionarVertice("D");
grafoLista.AdicionarAresta(3, 2, 5);
Console.WriteLine("\r");
Console.WriteLine("Grafo Linha com novo vertice e aresta");
Console.WriteLine("\r");
grafoLista.ImprimeGrafoLista();

Console.WriteLine("\r");
Console.WriteLine("Existe aresta nos vertices 1 e 2?");
Console.WriteLine(grafoLista.ExisteAresta(1, 2));

Console.WriteLine("\r");
Console.WriteLine("Existe aresta nos vertices 3 e 0?");
Console.WriteLine(grafoLista.ExisteAresta(3, 0));

Console.WriteLine("\r"); 
Console.WriteLine("Grafo Matriz");
Console.WriteLine("\r");

List<string> nomesMatriz = new List<string> {"A", "B", "C", "D"};
GrafoMatriz grafoMatriz = new GrafoMatriz(false, true, 4, nomesMatriz);

// Adicionando arestas
grafoMatriz.AdicionarAresta(0, 1, 3);
grafoMatriz.AdicionarAresta(1, 2, 2);
grafoMatriz.AdicionarAresta(2, 3, 4);
grafoMatriz.AdicionarAresta(3, 0, 5);

// Imprimindo grafo

grafoMatriz.ImprimirGrafoMatriz();

Console.WriteLine("\r");
Console.WriteLine("Existe aresta nos vertices 1 e 2?");
Console.WriteLine(grafoMatriz.ExisteAresta(1, 2));

Console.WriteLine("\r");
Console.WriteLine("Existe aresta nos vertices 3 e 1?");
Console.WriteLine(grafoMatriz.ExisteAresta(3, 1));
