using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private const float JUMP_AMOUNT = 100f;
    private Rigidbody2D birdRigidbody2D;
    // Start is called before the first frame update
    private void Awake()
    {
        birdRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
    private void Jump()
    {
        birdRigidbody2D.velocity = Vector2.up * JUMP_AMOUNT;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log("Dead");
    }
}
