using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build
{
    public Vector3 ObjectPos;
    public string ObjectName;

    public Build(string Name, Vector3 Pos)
    {
        this.ObjectName = Name;
        this.ObjectPos = Pos;
    }
}

public interface IMapData
{
    Build[] Builds { get; }
    Vector3 PlayerStartPos { get; }
}