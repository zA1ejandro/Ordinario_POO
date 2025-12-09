namespace ordinario.Clases;

class Program
{
    static void Main(string[] args)
    {
        var dijkstra = new Dijkstra<string, int[]>();
        dijkstra.GenerateMap("graph.txt", dijkstra.DefaultGraphGen);
    }

}
