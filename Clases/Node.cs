using System;
using System.Data.Common;
using System.Diagnostics.Contracts;

namespace ordinario.Clases;

public class Node<T>
{
    public int ID{get;set;}

    public T value{get;set;}

    public Node(int id,T valueType)
    {
        ID=id;
        value=valueType;
    }
}
