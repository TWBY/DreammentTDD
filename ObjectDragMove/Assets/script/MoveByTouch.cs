using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{
    Rigidbody rb;
    Vector3 touchPoint;
    public GameObject BeTouchObj = null;
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
            Vector3 BeTouchObjPos = BeTouchObj.transform.position;
            switch (MoveAxis)
            {
                case "XAxis":
                    if ((BeTouchObjPos.x - StopPosition) * rb.velocity.x > 0)
                    {
                        rb.velocity = Vector3.zero;
                        Vector3 endPosition = new Vector3(StopPosition, BeTouchObjPos.y, BeTouchObjPos.z);
                        rb.MovePosition(endPosition);
                        BeTouchObjectExist = false;
                        BeTouchObj = null;
                    }
                    break;
                case "YAxis":
                    if ((BeTouchObjPos.y - StopPosition) * rb.velocity.y > 0)
                    {
                        rb.velocity = Vector3.zero;
                        Vector3 endPosition = new Vector3(BeTouchObjPos.x, StopPosition, BeTouchObjPos.z);
                        rb.MovePosition(endPosition);
                        BeTouchObjectExist = false;
                        BeTouchObj = null;
                    }
                    break;

                case "ZAxis":
                    if ((BeTouchObjPos.z - StopPosition) * rb.velocity.z > 0)
                    {
                        rb.velocity = Vector3.zero;
                        Vector3 endPosition = new Vector3(BeTouchObjPos.x, BeTouchObjPos.y, StopPosition);
                        rb.MovePosition(endPosition);
                        BeTouchObjectExist = false;
                        BeTouchObj = null;
                    }
                    break;
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
                Debug.Log("WorldPosition = " + WorldPosition);
                if (WorldPosition.x >= HighLimit)
                {
                    WorldPosition = new Vector3(HighLimit, WorldPosition.y, WorldPosition.z);
                }
                if (WorldPosition.x <= LowLimit)
                {
                    WorldPosition = new Vector3(LowLimit, WorldPosition.y, WorldPosition.z);
                }

                if (WorldPosition.x % 1 >= 0.5)
                {
                    rb.velocity = Vector3.right * velocitySpeed;
                }
                if (WorldPosition.x % 1 < 0.5)
                {
                    rb.velocity = Vector3.left * velocitySpeed;
                }
                StopPosition = Mathf.Round(WorldPosition.x);
                break;

            case "YAxis":
                Debug.Log("WorldPosition = " + WorldPosition);
                if (WorldPosition.y >= HighLimit)
                {
                    WorldPosition = new Vector3(WorldPosition.x, HighLimit, WorldPosition.z);
                }
                if (WorldPosition.y <= LowLimit)
                {
                    WorldPosition = new Vector3(WorldPosition.x, LowLimit, WorldPosition.z);
                }

                if (WorldPosition.y % 1 >= 0.5)
                {
                    rb.velocity = Vector3.up * velocitySpeed;
                }
                if (WorldPosition.y % 1 < 0.5)
                {
                    rb.velocity = Vector3.down * velocitySpeed;
                }
                StopPosition = Mathf.Round(WorldPosition.y);
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

                if (WorldPosition.z % 1 >= 0.5)
                {
                    rb.velocity = Vector3.forward * velocitySpeed;
                }
                if (WorldPosition.z % 1 < 0.5)
                {
                    rb.velocity = Vector3.back * velocitySpeed;
                }
                StopPosition = Mathf.Round(WorldPosition.z);
                break;
        }
        BeTouchObjectExist = true;
    }
}

