// See https://aka.ms/new-console-template for more information
using GrafosT1.Classes;

Console.WriteLine("Meu Grafo");

Grafos g1 = new Grafos(true, false, 10);

Console.WriteLine(g1.Direcionado);
Console.WriteLine(g1.Ponderado);
Console.WriteLine(g1.Vertices);