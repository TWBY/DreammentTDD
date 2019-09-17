using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float m_speed = 8.0f;
    public bool PlayerCanMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCanMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * m_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector3.right * m_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.forward * m_speed * Time.deltaTime);
            }
        }
    }
}

