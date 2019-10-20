using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private bool IsTouchBorder = false;
    private float TouchPosition;
    public Rigidbody rb;

    public float smoothTime = 3.0F;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Moves the GameObject using it's transform.
        // rb.isKinematic = true;
    }
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        // gameobject 的 world pos 與滑鼠利用換算所得來的 world pos 會有些微得誤差
        // mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    void OnMouseDrag()
    {
        // rb.MovePosition(new Vector3(GetMouseAsWorldPoint().x, transform.position.y, transform.position.z));
        // transform.position = new Vector3(GetMouseAsWorldPoint().x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(GetMouseAsWorldPoint().x, transform.position.y, transform.position.z), ref velocity, smoothTime);
        Debug.Log("TouchPosition = " + TouchPosition);
        if (IsTouchBorder)
        {
            Debug.Log("TouchPosition = " + TouchPosition);
            if (transform.position.x <= TouchPosition)
            {
                // transform.position = new Vector3(TouchPosition, transform.position.y, transform.position.z);
                // rb.MovePosition(new Vector3(TouchPosition, transform.position.y, transform.position.z));
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(TouchPosition, transform.position.y, transform.position.z), ref velocity, smoothTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsTouchBorder = true;

        Debug.Log("collision.transform.position.x = " + collision.transform.position); //-3
        Debug.Log("transform.position.x = " + transform.position.x); //-2
        // float Offset;
        if (collision.transform.position.x < transform.position.x)
        {
            // Offset = 1.0f;
            TouchPosition = collision.transform.position.x + 1.0f;
        }
        if (collision.transform.position.x > transform.position.x)
        {
            // Offset = -1.0f;
            TouchPosition = collision.transform.position.x - 1.0f;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        IsTouchBorder = false;
    }

}