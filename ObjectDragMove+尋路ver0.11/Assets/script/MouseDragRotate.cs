using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragRotate : MonoBehaviour
{
    float rotationSpeed = 0.2f;
    private Transform MoveCubeTransform;
    private Vector3 MoveCubePosition;

    GameObject RotateObject;
    GameObject MoveObject;

    void Start()
    {
        RotateObject = GameObject.Find("RotateCube");
        MoveObject = GameObject.Find("MoveCube");

        MoveCubeTransform = MoveObject.transform;

    }
    void OnMouseDrag()
    {
        float YAxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(YAxisRotation * 200, 0, 0, Space.Self);
        //只有針對 XYZ 其中一軸移動，無法 "斜向" 的移動
        MoveCubeTransform.position = MoveCubeTransform.position + new Vector3(YAxisRotation * 8f, 0.0f, 0.0f);
    }
}