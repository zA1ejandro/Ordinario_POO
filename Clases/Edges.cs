using System;

namespace ordinario.Clases;

public class Edges<T>
{
    public int idIncialNode{get;set;}
    public int idFinalNode{get;set;}
    public bool isBidirectional{get;set;}
    public T value{get;set;}
    public int state{get;set;}
    public Edges(int idNode1,int idNode2,bool bidirectional,T edgevalue,int stateOfEdge)
    {
        idIncialNode=idNode1;
        idFinalNode=idNode2;
        isBidirectional=bidirectional;
        value=edgevalue;
        state=stateOfEdge; 
    }
}
