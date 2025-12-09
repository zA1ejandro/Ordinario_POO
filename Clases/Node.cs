using System;
using System.Data.Common;
using System.Diagnostics.Contracts;

namespace ordinario.Clases;

public class Node<Tn, Te>
{
    public int Id { get; set; }
    public Tn? Value { get; set; }
    public List<Edge<Tn, Te>> Edges { get; set; } = [];

    public Node(int id)
    {
        Id = id;
    }
}
