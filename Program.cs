using Graph;

Console.WriteLine("Meus Grafos");
Console.WriteLine("\r");

Console.WriteLine("Grafo Lista");
Console.WriteLine("\r");

GraphList graphList = new();

//graphList.NodeInsert("A");
//graphList.NodeInsert("B");
//graphList.NodeInsert("C");

//graphList.EdgeInsert(0, 1, 10);
//graphList.EdgeInsert(1, 2, 15);
//graphList.EdgeInsert(2, 0, 20);

graphList.LoadFile("C:\\Users\\mathe\\Documents\\Faculdade\\7º Período\\Grafos\\T2 - Grafos\\graph.txt");
graphList.GraphPrint();

GraphMatrix graphMatrix = new();

//graphMatrix.NodeInsert("A");
//graphMatrix.NodeInsert("B");
//graphMatrix.NodeInsert("C");

//graphMatrix.EdgeInsert(0, 1, 10);
//graphMatrix.EdgeInsert(1, 2, 15);
//graphMatrix.EdgeInsert(2, 0, 20);

graphMatrix.LoadFile("C:\\Users\\mathe\\Documents\\Faculdade\\7º Período\\Grafos\\T2 - Grafos\\graph.txt");
graphMatrix.GraphPrint();
