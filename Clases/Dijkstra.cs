using System;

namespace ordinario.Clases;

public class Dijkstra<Tn, Te>
{
    private Graph<Tn, Te>? Graph { get; set; }

    public void GenerateMap(string txtFilename, Func<string[], Graph<Tn, Te>> graphGenerator)
    {
        string fileContent = File.ReadAllText(txtFilename);
        string[] piecesOfData = fileContent.Split(" ");

        Graph = graphGenerator(piecesOfData);

        Graph.TraverseGraph(Graph.FindNode(n => n.Id == 3)!);
    }
}
