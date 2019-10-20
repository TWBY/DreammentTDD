using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScript : MonoBehaviour
{
    GameObject ButtonTrigger;
    // GameObject CountDownText;
    // Start is called before the first frame update
    void Start()
    {
        ButtonTrigger = GameObject.Find("ButtonTrigger");
        ButtonTrigger.AddComponent<Standing>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
