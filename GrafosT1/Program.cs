// See https://aka.ms/new-console-template for more information
using GrafosT1.Classes;

Console.WriteLine("Meus Grafos", "\n");

Grafos g1 = new Grafos(true, false, 5);
GrafoLista gl1 = new GrafoLista(true, false, 5);
GrafoMatriz gm1 = new GrafoMatriz(true, false, 5);

Console.WriteLine("Grafo!");
Console.WriteLine(g1.Direcionado);
Console.WriteLine(g1.Ponderado);
Console.WriteLine(g1.Vertices);
Console.WriteLine("Grafo Linha!", "\n");
Console.WriteLine(gl1.Direcionado);
Console.WriteLine(gl1.Ponderado);
Console.WriteLine(gl1.Vertices);
Console.WriteLine(gl1.Lista);
Console.WriteLine("Grafo Matriz", "\n");
Console.WriteLine(gm1.Direcionado);
Console.WriteLine(gm1.Ponderado);
Console.WriteLine(gm1.Vertices);
Console.WriteLine(gm1.Matriz);