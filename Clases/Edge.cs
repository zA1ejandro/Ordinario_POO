using System;

namespace ordinario.Clases;

public class Edge<Tn, Te>
{
    public bool Bidirectional { get; set; }
    public Te? Value { get; set; }
    public Node<Tn, Te>? NodeA { get; set; }
    public Node<Tn, Te>? NodeB { get; set; }

    public Edge(bool bidirectional)
    {
        Bidirectional = bidirectional;
    }
}
