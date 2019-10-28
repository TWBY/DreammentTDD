using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_test : MonoBehaviour
{
    public GameObject It;
    public Rigidbody rb;
    public void RotateIt()
    {
        It.transform.Translate(new Vector3(0, 10, 0));
    }

    public void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     It.transform.Translate(new Vector3(0, 1, 0));
        // }
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            // It.transform.Translate(new Vector3(0.1f, 0, 0));
            rb.MovePosition(new Vector3(5, 0, 0));
        }
    }
}
