using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReaction : MonoBehaviour
{
    TimeCountDown Timer;
    float IvanDisappearTime = 2.0f;
    float ResetTheTime;

    Move move;

    public GameObject CubePrefab;

    private string ToyTag;
    private int ToyIndex = 0;
    private int TagIndex = 2;
    Vector3[] ToyPosition = { new Vector3 { x = 1.0f, y = 0.0f, z = 0.0f },
                            new Vector3 { x = 3.0f, y = 0.0f, z = 0.0f} };


    void Start()
    {
        Timer = GameObject.Find("CountDownText").GetComponent<TimeCountDown>();
        move = GameObject.Find("Character").GetComponent<Move>();
    }

    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        move.PlayerCanMove = false;

        ToyTag = other.tag;
        switch (ToyTag)
        {
            case "toy1":
                ResetTheTime = 8.0f;
                break;
            case "toy2":
                ResetTheTime = 6.0f;
                break;
            default:
                ResetTheTime = 4.0f;
                break;
        }

        Invoke("ResetTime", IvanDisappearTime + 0.3f);
        if (ToyIndex < 2)
        {
            Invoke("generateToy", IvanDisappearTime + 0.4f);
        }
    }

    private void ResetTime()
    {
        Timer.resetCountDownTime(ResetTheTime);
        move.PlayerCanMove = true;
    }

    public void generateToy()
    {
        Debug.Log("genetator the toy");
        GameObject cube = Instantiate(CubePrefab, ToyPosition[ToyIndex], new Quaternion(0, 0, 0, 0));
        cube.AddComponent<ToyOne>();
        cube.tag = "toy" + TagIndex;

        ToyIndex++;
        TagIndex++;
    }
}
