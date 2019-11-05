using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    Cube[] cubes;
    GameObject BuildObject(string Name)
    {
        string url = "Prefab/" + Name;
        Object Object = Resources.Load(url);
        GameObject G_Object = Instantiate(Object, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
        // G_Object.AddComponent<BoxCollider>();
        G_Object.isStatic = true;
        G_Object.name = Name;
        //REVIEW  G_Object.tag = "Floor";
        return G_Object;
    }
    void Start()
    {
        MakeMap(new Map2());

    }
    void MakeMap(IMapData MapData)
    {
        // STUB
        // GameObject G_BottomCastle = MakeBottomCastle();
        // G_BottomCastle.transform.position = MapData.BottomCastlePos;
        // GameObject G_FrontCastleRotPos = MakeFrontCastleRotPos();
        // G_FrontCastleRotPos.transform.position = MapData.FrontCastleRotPos;

        /*TODO 移除方塊(前一關卡)
        GameObject[] Objs = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] Objs2 = GameObject.FindGameObjectsWithTag("CanNotStandSlope");
        foreach (GameObject Obj in Objs)
            //在關卡轉換的時候，將前一關的物件移除
            GameObject.DestroyImmediate(Obj);
        foreach (GameObject Obj2 in Objs2)
            GameObject.DestroyImmediate(Obj2);
        */
        foreach (Build B in MapData.Builds)
        {
            GameObject Object = BuildObject(B.ObjectName);
            Object.transform.position = B.ObjectPos;
        }
        //設定角色的初始位置
        {
            //Player 是原本已經擺放至場景當中
            GameObject Player = GameObject.Find("Player");
            Player.transform.position = new Vector3(MapData.PlayerStartPos.x, MapData.PlayerStartPos.y, MapData.PlayerStartPos.z);
        }

        GameObject blocks = GameObject.Find("blocks");
        cubes = Object.FindObjectsOfType<Cube>();

        foreach (var c in cubes)
        {
            c.gameObject.transform.SetParent(blocks.gameObject.transform);
        }

        GameObject DragedObject = GameObject.Find("DragedObject");
        GameObject DragObject = GameObject.Find("DragObject");
        GameObject DragObject2 = GameObject.Find("DragObject2");
        DragObject.gameObject.transform.SetParent(DragedObject.gameObject.transform);
        DragObject2.gameObject.transform.SetParent(DragedObject.gameObject.transform);

        GameObject Button1Move = GameObject.Find("Button1Move");
        // GameObject Car = GameObject.Find("Car");
        GameObject Track = GameObject.Find("Track");
        GameObject Rope = GameObject.Find("Rope");
        GameObject Toy1Platform = GameObject.Find("Toy1Platform");
        GameObject Toy1Platform2 = GameObject.Find("Toy1Platform2");
        // Car.gameObject.transform.SetParent(Button1Move.gameObject.transform);
        Track.gameObject.transform.SetParent(Button1Move.gameObject.transform);
        Rope.gameObject.transform.SetParent(Button1Move.gameObject.transform);
        Toy1Platform.gameObject.transform.SetParent(Button1Move.gameObject.transform);
        Toy1Platform2.gameObject.transform.SetParent(Button1Move.gameObject.transform);

        GameObject cube1 = GameObject.Find("cube1");
        GameObject cube2 = GameObject.Find("cube2");
        GameObject cube3 = GameObject.Find("cube3");
        GameObject BridgeTransformCube1 = GameObject.Find("BridgeTransformCube");
        BridgeTransformCube1.name = "BridgeTransformCube1";
        // BridgeTransformCube1.gameObject.transform.SetParent(cube1.gameObject.transform);
        GameObject BridgeTransformCube2 = GameObject.Find("BridgeTransformCube");
        BridgeTransformCube2.name = "BridgeTransformCube2";
        BridgeTransformCube2.gameObject.transform.SetParent(cube2.gameObject.transform);
        GameObject BridgeTransformCube3 = GameObject.Find("BridgeTransformCube");
        BridgeTransformCube3.name = "BridgeTransformCube3";
        BridgeTransformCube3.gameObject.transform.SetParent(cube3.gameObject.transform);

        GameObject Rotate = GameObject.Find("Rotate");
        GameObject cubeR = GameObject.Find("cubeR");
        GameObject cubeR2 = GameObject.Find("cubeR2");
        GameObject cubeR3 = GameObject.Find("cubeR3");
        GameObject cubeR4 = GameObject.Find("cubeR4");
        cubeR.gameObject.transform.SetParent(Rotate.gameObject.transform);
        cubeR2.gameObject.transform.SetParent(Rotate.gameObject.transform);
        cubeR3.gameObject.transform.SetParent(Rotate.gameObject.transform);
        cubeR4.gameObject.transform.SetParent(Rotate.gameObject.transform);

        GameObject Button1 = GameObject.Find("Button2");
        Button1.name = "Button1";
        Button1.transform.Rotate(0, 45, 0);
        Button1.gameObject.transform.SetParent(DragedObject.gameObject.transform);
        GameObject Button2 = GameObject.Find("Button2");
        Button2.transform.Rotate(0, 45, 0);

        GameObject Toy = GameObject.Find("Toy2");
        Toy.gameObject.transform.SetParent(Button1Move.gameObject.transform);
        Toy.name = "Toy1";



        // GameObject TopCastle = GameObject.Find("TopCastle");
        //ANCHOR  Button1Move.AddComponent<Animator>();
        //ANCHOR  Button1Move.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("AnimatorController/Button1Move") as RuntimeAnimatorController;
        // TopCastle.AddComponent<Animator>();
        // TopCastle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("TopCastle") as RuntimeAnimatorController;
        // TopCastle.GetComponent<Animator>().Play("",0,0);

    }
}