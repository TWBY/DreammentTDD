using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScript : MonoBehaviour
{
    GameObject Character;
    GameObject Toy1;
    GameObject CountDownText;
    // GameObject CountDownText;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Character");
        Toy1 = GameObject.Find("Toy1");
        CountDownText = GameObject.Find("CountDownText");

        Character.AddComponent<Move>();
        Character.AddComponent<ObjectReaction>();
        Toy1.AddComponent<ToyOne>();
        CountDownText.AddComponent<TimeCountDown>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
