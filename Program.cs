namespace ordinario.Clases;

class Program
{
    static void Main(string[] args)
    {
        var dijkstra = new Dijkstra<string, int[]>();
        dijkstra.GenerateMap("graph.txt", DefaultGraphGen);
    }

    static Graph<string, int[]> DefaultGraphGen(string[] piecesOfData)
    {
        var graph = new Graph<string, int[]>();

        for (int i = 0; i < piecesOfData.Length; i++)
        {
            string currentPiece = piecesOfData[i];

            switch (currentPiece)
            {
                case "N":
                    int nodeId = Convert.ToInt32(piecesOfData[i + 1]);
                    string nodeValue = piecesOfData[i + 2];
                    Node<string, int[]> node = new Node<string, int[]>(nodeId);
                    graph.AddNode(node);
                    graph.SetNodeValue(node, nodeValue);

                    break;
                case "A":
                    int nodeAId = Convert.ToInt32(piecesOfData[i + 1]);
                    int nodeBId = Convert.ToInt32(piecesOfData[i + 2]);
                    Node<string, int[]>? nodeA = graph.FindNode(n => n.Id == nodeAId);
                    Node<string, int[]>? nodeB = graph.FindNode(n => n.Id == nodeBId);
                    if (nodeA is null || nodeB is null)
                        throw new Exception(
                            "No nodes found with corresponding ids, for graph creation"
                        );
                    bool bidirectional = piecesOfData[i + 3] == "B" ? true : false;
                    int distance = Convert.ToInt32(piecesOfData[i + 4]);
                    int state = Convert.ToInt32(piecesOfData[i + 5]);

                    Edge<string, int[]> edge = new Edge<string, int[]>(bidirectional);
                    graph.AddEdge(nodeA, nodeB, edge);
                    graph.SetEdgeValue(nodeA, nodeB, [distance, state]);

                    break;
            }
        }

        return graph;
    }
}
