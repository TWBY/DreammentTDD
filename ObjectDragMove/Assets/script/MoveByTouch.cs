using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{

    Rigidbody rb;
    Vector3 touchPoint;
    public GameObject BeTouchObj;
    public string MoveAxis;

    public bool IsTouch = false;
    public bool BeTouchObjectExist = false;

    public float HighLimit;
    public float LowLimit;
    float StopPosition;
    float velocitySpeed = 5;

    void start()
    {
        Application.targetFrameRate = -1;
    }
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    BeTouchObj = hit.transform.gameObject;
                }

                if (BeTouchObj.tag == "drag")
                {
                    rb = BeTouchObj.GetComponent<Rigidbody>();
                    IsTouch = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && IsTouch == true)
            {
                touchPoint = WorldToScreenToWorld(BeTouchObj.transform.position);
                Hold(touchPoint);
            }
            else if (touch.phase == TouchPhase.Ended && IsTouch == true)
            {
                touchPoint = WorldToScreenToWorld(BeTouchObj.transform.position);
                adjustPosition(touchPoint);
                IsTouch = false;
            }

            Vector3 WorldToScreenToWorld(Vector3 BeTouchObjPosition)
            {
                touchPoint = touch.position;
                touchPoint.z = Camera.main.WorldToScreenPoint(BeTouchObjPosition).z;
                return Camera.main.ScreenToWorldPoint(touchPoint);
            }
        }

        if (BeTouchObjectExist)
        {
            if (BeTouchObj.transform.position.x >= StopPosition && rb.velocity.x > 0)
            {
                rb.velocity = Vector3.zero;
                BeTouchObjectExist = false;
            }
            if (BeTouchObj.transform.position.x <= StopPosition && rb.velocity.x < 0)
            {
                rb.velocity = Vector3.zero;
                BeTouchObjectExist = false;
            }
        }
    }
    void Hold(Vector3 WorldPosition)
    {
        switch (MoveAxis)
        {
            case "XAxis":
                if (WorldPosition.x >= HighLimit)
                {
                    WorldPosition = new Vector3(HighLimit, WorldPosition.y, WorldPosition.z);
                }
                if (WorldPosition.x <= LowLimit)
                {
                    WorldPosition = new Vector3(LowLimit, WorldPosition.y, WorldPosition.z);
                }
                break;

            case "YAxis":
                if (WorldPosition.y >= HighLimit)
                {
                    WorldPosition = new Vector3(WorldPosition.x, HighLimit, WorldPosition.z);
                }
                if (WorldPosition.y <= LowLimit)
                {
                    WorldPosition = new Vector3(WorldPosition.x, LowLimit, WorldPosition.z);
                }
                break;

            case "ZAxis":
                if (WorldPosition.z >= HighLimit)
                {
                    WorldPosition = new Vector3(WorldPosition.x, WorldPosition.y, HighLimit);
                }
                if (WorldPosition.z <= LowLimit)
                {
                    WorldPosition = new Vector3(WorldPosition.x, WorldPosition.y, LowLimit);
                }
                break;
        }

        rb.MovePosition(WorldPosition);
    }

    void adjustPosition(Vector3 WorldPosition)
    {
        switch (MoveAxis)
        {
            case "XAxis":
                if (WorldPosition.x % 1 >= 0.5)
                {
                    rb.velocity = Vector3.right * velocitySpeed;
                }
                if (WorldPosition.x % 1 < 0.5)
                {
                    rb.velocity = Vector3.left * velocitySpeed;
                }
                break;

            case "YAxis":
                if (WorldPosition.y % 1 >= 0.5)
                {
                    rb.velocity = Vector3.up * velocitySpeed;
                }
                if (WorldPosition.y % 1 < 0.5)
                {
                    rb.velocity = Vector3.down * velocitySpeed;
                }
                break;

            case "ZAxis":
                if (WorldPosition.z % 1 >= 0.5)
                {
                    rb.velocity = new Vector3(0, 0, 1) * velocitySpeed;
                }
                if (WorldPosition.z % 1 < 0.5)
                {
                    rb.velocity = new Vector3(0, 0, -1) * velocitySpeed;
                }
                break;
        }

        StopPosition = Mathf.Round(WorldPosition.x);
        BeTouchObjectExist = true;
    }
}

