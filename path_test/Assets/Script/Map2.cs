using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : IMapData
{
    Build[] builds = {
        new Build("TopCastle", new Vector3(0.6f, 2, -5)),// FIXME
        new Build("BottomCastle", new Vector3(0, 1, -3)),
        new Build("FrontCastle", new Vector3(-3, 1, -3)),
        new Build("FrontCastleRot", new Vector3(-1,3,-3)),
        new Build("DragObject", new Vector3(-4,1,-1)),
        // new Build("DragObjectTest", new Vector3(-7,3,-2)),
        // new Build("Car", new Vector3(-1,12.06f,1)),// FIXME
        new Build("Track", new Vector3(-1,11.5f,4)),// FIXME
        new Build("Rope", new Vector3(-1,3,1)),// FIXME
        new Build("Toy1Platform", new Vector3(-1,2.5f,1)),// FIXME
        new Build("BridgeTransformCube", new Vector3(0,3,1)),
        new Build("BridgeTransformCube", new Vector3(0,2,1)),
        new Build("BridgeTransformCube", new Vector3(0,1,1)),
        new Build("Other",new Vector3(-1,1,6)),
        new Build("Button2",new Vector3(-4,4.539f,-1)),
        new Build("Button2",new Vector3(-3,4.539f,-3)),
        new Build("Toy2",new Vector3(-1,3.5f,1)),

        new Build("cube",new Vector3(0,6.5f,6)),
        new Build("cube",new Vector3(0,6.5f,5)),
        new Build("cube",new Vector3(0,6.5f,4)),
        new Build("cube",new Vector3(0,6.5f,3)),

        new Build("cube",new Vector3(1,6.5f,6)),
        new Build("cube",new Vector3(1,6.5f,5)),
        new Build("cube",new Vector3(1,6.5f,4)),

        new Build("cube",new Vector3(-1,3.5f,6)),
        new Build("cube",new Vector3(-1,3.5f,5)),
        new Build("cube",new Vector3(-1,3.5f,4)),
        new Build("cube",new Vector3(-1,3.5f,3)),
        new Build("cube",new Vector3(-1,3.5f,2)),
        new Build("cube",new Vector3(-2,3.5f,2)),
        new Build("cube",new Vector3(-3,3.5f,2)),
        new Build("cube",new Vector3(-4,3.5f,2)),
        new Build("cube",new Vector3(-4,3.5f,1)),
        new Build("cube",new Vector3(-4,3.5f,0)),

        // new Build("cube",new Vector3(-1,3.5f,-3)),
        new Build("cube",new Vector3(-3,4.5f,-3)),

        new Build("cube",new Vector3(1,4.5f,-5)),

    };
    Vector3 playerStartPos = new Vector3(0, 6.5f, 6);
    public Build[] Builds { get { return builds; } }
    public Vector3 PlayerStartPos { get { return playerStartPos; } }
}
