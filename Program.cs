//using GrafosT2.src;
using Graph;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

Console.WriteLine("Grafo Lista");
Console.WriteLine("\r");

GraphList graphList = new(false, true);

//graphList.NodeInsert("A");
//graphList.NodeInsert("B");
//graphList.NodeInsert("C");
//graphList.NodeInsert("D");
//graphList.NodeInsert("E");

//graphList.EdgeInsert(0, 2, 5);
//graphList.EdgeInsert(0, 3, 4);
//graphList.EdgeInsert(0, 1, 3);
//graphList.EdgeInsert(0, 4, 8);
//graphList.EdgeInsert(2, 4, 2);
//graphList.EdgeInsert(1, 4, 10);
//graphList.EdgeInsert(1, 3, -2);

//graphList.EdgeInsert(0, 1, 3);
//graphList.EdgeInsert(0, 2, 5);
//graphList.EdgeInsert(0, 3, 6);
//graphList.EdgeInsert(0, 4, 8);
//graphList.EdgeInsert(1, 3, 2);
//graphList.EdgeInsert(1, 4, 11);
//graphList.EdgeInsert(2, 4, 2);

graphList.LoadFile(System.Environment.CurrentDirectory + "/graph.txt");
graphList.GraphPrint();


Console.WriteLine("Imprimindo Dikstra");
Dijkstra dijkstra = new Dijkstra(graphList);
dijkstra.FuncaoDijkstra(0);
dijkstra.PrintTest(0);


//Console.WriteLine("Imprimindo Busca em Largura (BFS): ");

//BreadthFirstSearch bfs = new BreadthFirstSearch(graphList);
//bfs.BFS(graphList.Nodes);


//Console.WriteLine("Imprimindo Busca em Largura (BFS): ");

//DepthFirstSearch dfs = new DepthFirstSearch(graphList);
//dfs.BuscaProfundidade(graphList.Nodes);
