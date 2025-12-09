namespace ordinario.Clases;

public class Graph<Tn, Te>
{
    private List<Node<Tn, Te>> Nodes { get; set; } = [];

    public List<Node<Tn, Te>> GetNodes()
    {
        return Nodes;
    }

    public Node<Tn, Te>? FindNode(Predicate<Node<Tn, Te>> comparsion)
    {
        return Nodes.Find(comparsion);
    }

    public bool IsAdjacent(Node<Tn, Te> nodeA, Node<Tn, Te> nodeB)
    {
        foreach (var edge in nodeA.Edges)
        {
            if (edge.NodeB == nodeB && !edge.Bidirectional)
                return true;
        }
        return false;
    }

    public List<Node<Tn, Te>> GetNeighbors(Node<Tn, Te> node)
    {
        List<Node<Tn, Te>> neighbors = [];
        foreach (var edge in node.Edges)
        {
            if (!edge.Bidirectional)
            {
                neighbors.Add(edge.NodeB!);
                continue;
            }

            bool NodeInPointA = edge.NodeA == node;
            neighbors.Add(NodeInPointA ? edge.NodeB! : edge.NodeA!);
        }
        return neighbors;
    }

    public void AddNode(Node<Tn, Te> node)
    {
        Nodes.Add(node);
    }

    public void RemoveNode(Node<Tn, Te> node)
    {
        Nodes.Remove(node);
    }

    public void AddEdge(Node<Tn, Te> nodeA, Node<Tn, Te> nodeB, Edge<Tn, Te> edge)
    {
        edge.NodeA = nodeA;
        edge.NodeB = nodeB;

        if (edge.Bidirectional)
        {
            nodeA.Edges.Add(edge);
            nodeB.Edges.Add(edge);
            return;
        }

        nodeA.Edges.Add(edge);
    }

    public void RemoveEdge(Node<Tn, Te> nodeA, Node<Tn, Te> nodeB)
    {
        Node<Tn, Te>[] nodes = [nodeA, nodeB];
        foreach (var node in nodes)
        {
            foreach (var edge in node.Edges)
            {
                bool IsInPointA = node == edge.NodeA;
                if ((IsInPointA && edge.NodeB != nodeB) || (!IsInPointA && edge.NodeA != nodeA))
                    continue;

                nodeA.Edges.Remove(edge);
                nodeB.Edges.Remove(edge);
                return;
            }
        }
    }

    public Tn GetNodeValue(Node<Tn, Te> node)
    {
        return node.Value!;
    }

    public void SetNodeValue(Node<Tn, Te> node, Tn value)
    {
        node.Value = value;
    }

    public Te? GetEdgeValue(Node<Tn, Te> nodeA, Node<Tn, Te> nodeB)
    {
        Node<Tn, Te>[] nodes = [nodeA, nodeB];
        foreach (var node in nodes)
        {
            foreach (var edge in node.Edges)
            {
                bool IsInPointA = node == edge.NodeA;
                if ((IsInPointA && edge.NodeB != nodeB) || (!IsInPointA && edge.NodeA != nodeA))
                    continue;

                return edge.Value;
            }
        }
        return default;
    }

    public void SetEdgeValue(Node<Tn, Te> nodeA, Node<Tn, Te> nodeB, Te value)
    {
        Node<Tn, Te>[] nodes = [nodeA, nodeB];
        foreach (var node in nodes)
        {
            foreach (var edge in node.Edges)
            {
                bool IsInPointA = node == edge.NodeA;
                if ((IsInPointA && edge.NodeB != nodeB) || (!IsInPointA && edge.NodeA != nodeA))
                    continue;

                edge.Value = value;
                return;
            }
        }
    }

    public void TraverseGraph(Node<Tn, Te> node)
    {
        TraverseGraph(node, (n) => { });
    }

    public void TraverseGraph(Node<Tn, Te> node, Action<Node<Tn, Te>> action)
    {
        var visitedNodes = new Dictionary<int, bool>();
        Traverse(node, action, visitedNodes);
    }

    private void Traverse(
        Node<Tn, Te> node,
        Action<Node<Tn, Te>> action,
        Dictionary<int, bool> visitedNodes
    )
    {
        visitedNodes.Add(node.Id, true);

        action(node);

        var neighbors = GetNeighbors(node);
        foreach (var neighbor in neighbors)
        {
            if (visitedNodes.ContainsKey(neighbor.Id))
                continue;

            var edgeValue = GetEdgeValue(node, neighbor);
            Console.WriteLine(
                $"Node ID: {node.Id}, Value: {node.Value} -> Node ID: {neighbor.Id}, Value: {neighbor.Value} | {EdgeValueToString(edgeValue!)}"
            );

            Traverse(neighbor, action, visitedNodes);
        }
    }

    private string EdgeValueToString(Te edgeValue)
    {
        if (edgeValue is System.Collections.IEnumerable collection && edgeValue is not string)
            return string.Join(",", collection.Cast<object>());

        return edgeValue!.ToString()!;
    }
}
