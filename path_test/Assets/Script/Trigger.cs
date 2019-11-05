using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Collider>().name == "Button1")
        {
            GameObject Button1 = GameObject.Find("Button1");
            // Destroy(Button1);
            Destroy(Button1.GetComponent<BoxCollider>());
            Button1.transform.Translate(0, -0.063f, 0);


            GameObject Button1Move = GameObject.Find("Button1Move");
            Button1Move.transform.Translate(Vector3.up);
            //ANCHOR  Button1Move.GetComponent<Animator>().Play("Button1MoveUp", 0, 0);


            // GameObject Toy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // Object Object = Resources.Load("Prefab/Toy2");
            // GameObject Toy = Instantiate(Object, new Vector3(-1, 4.5f, 1), Quaternion.Euler(0, 0, 0)) as GameObject;
            // Toy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            // Toy.transform.position = new Vector3(-1, 4.5f, 1);
            // Toy.gameObject.transform.SetParent(Button1Move.gameObject.transform);
            // Toy.name = "Toy1";
            // Toy.GetComponent<SphereCollider>().isTrigger = true;
        }
        if (collider.GetComponent<Collider>().name == "Toy1")
        {
            GameObject Toy1 = GameObject.Find("Toy1");
            Destroy(Toy1);

            Object Object = Resources.Load("Prefab/Car");
            GameObject Car = Instantiate(Object, new Vector3(-1, 13.06f, 1), Quaternion.Euler(0, 0, 0)) as GameObject;
            Car.isStatic = true;
            Car.name = "Car";
            GameObject blocks = GameObject.Find("blocks");
            Car.gameObject.transform.SetParent(blocks.gameObject.transform);
            Car.AddComponent<BoxCollider>();
            Car.AddComponent<Rigidbody>();
            Car.GetComponent<Rigidbody>().isKinematic = true;
            Car.GetComponent<Rigidbody>().useGravity = false;
            Car.tag = "Drag";
            Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            GameObject Track = GameObject.Find("Track");
            Track.gameObject.transform.SetParent(blocks.gameObject.transform);
            GameObject Button1Move = GameObject.Find("Button1Move");
            Button1Move.gameObject.transform.SetParent(Car.gameObject.transform);
        }
        if (collider.GetComponent<Collider>().name == "Button2")
        {
            GameObject Button2 = GameObject.Find("Button2");
            // Destroy(Button2);
            Destroy(Button2.GetComponent<BoxCollider>());
            Button2.transform.Translate(0, -0.063f, 0);


            GameObject cube1 = GameObject.Find("cube1");
            GameObject cube2 = GameObject.Find("cube2");
            GameObject BridgeTransformCube1 = GameObject.Find("BridgeTransformCube1");
            GameObject cube3 = GameObject.Find("cube3");
            BridgeTransformCube1.transform.Translate(0, 1, -1);
            cube1.transform.Translate(0, 1.5f, -1);
            cube2.transform.Translate(0, 2, -2);
            cube3.transform.Translate(0, 3, -3);

            // Object Object = Resources.Load("Prefab/cube");
            // GameObject cube1 = Instantiate(Object, new Vector3(0, 4.5f, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            // cube1.name = "cube1";
            // GameObject blocks = GameObject.Find("blocks");
            // cube1.gameObject.transform.SetParent(blocks.gameObject.transform);

            // GameObject Toy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // Toy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            // Toy.transform.position = new Vector3(0, 5.5f, -2);
            Object Object = Resources.Load("Prefab/Toy2");
            GameObject Toy = Instantiate(Object, new Vector3(0, 5.5f, -2), Quaternion.Euler(0, 0, 0)) as GameObject;
            Toy.name = "Toy2";
            // Toy.GetComponent<SphereCollider>().isTrigger = true;
        }
        if (collider.GetComponent<Collider>().name == "Toy2")
        {
            GameObject Toy2 = GameObject.Find("Toy2");
            Destroy(Toy2);

            GameObject Rotate = GameObject.Find("Rotate");
            GameObject FrontCastleRot = GameObject.Find("FrontCastleRot");
            FrontCastleRot.gameObject.transform.SetParent(Rotate.gameObject.transform);
            Rotate.transform.Rotate(90, 0, 0);
            GameObject TopCastle = GameObject.Find("TopCastle");
            TopCastle.transform.Translate(0, 3, 0);
            GameObject NeedDestroy = GameObject.Find("NeedDestroy");
            Destroy(NeedDestroy);
        }
    }
}
