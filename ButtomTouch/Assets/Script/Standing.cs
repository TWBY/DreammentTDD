using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing : MonoBehaviour
{
    private Transform buttonTransform;
    private Transform stairTransform;
    private Vector3 ButtonDropPosition = new Vector3(3.0f, -0.15f, 3.0f);
    private Vector3 stairDropPosition = new Vector3(-1.0f, 1.0f, 4.0f);
    public Quaternion stairStartRotation = Quaternion.Euler(-90, 0, 90);
    public Quaternion stairDropRotation = Quaternion.Euler(0, 90, 0);

    private float DropDownSpeed = 2.0f;
    private float RotateSpeed = 2.0f;
    private bool standing = false;

    GameObject Stair;
    Object SlopeMeterial;
    // Start is called before the first frame update
    void Start()
    {
        SlopeMeterial = Resources.Load("Slope2");
        Stair = Instantiate(SlopeMeterial, new Vector3(-1, 2, 4), stairStartRotation) as GameObject;

        buttonTransform = GameObject.Find("Button").transform;
        stairTransform = Stair.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (standing)
        {
            buttonTransform.position = Vector3.Lerp(buttonTransform.position, ButtonDropPosition, Time.deltaTime * DropDownSpeed);
            Invoke("stairRotate", 0.0f);
            Invoke("stairPosition", 2.0f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        standing = true;
    }

    public void stairRotate()
    {
        stairTransform.rotation = Quaternion.Lerp(stairTransform.rotation, stairDropRotation, Time.deltaTime * RotateSpeed);
    }
    public void stairPosition()
    {
        stairTransform.position = Vector3.Lerp(stairTransform.position, stairDropPosition, Time.deltaTime * DropDownSpeed);
    }
}
