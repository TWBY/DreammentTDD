using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyOne : MonoBehaviour
{
    private Animator ToyOneAnim;
    TimeCountDown Timer;
    float IvanDisappearTime = 0.5f;
    void Start()
    {
        Timer = GameObject.Find("CountDownText").GetComponent<TimeCountDown>();
        ToyOneAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Timer.CancelTimeRun();

        ToyOneAnim.Play("colorChange", 0, 0.0f);
        Invoke("ToyFadeOut", IvanDisappearTime);
        Invoke("DestoryToy", IvanDisappearTime + 0.5f);
    }

    private void ToyFadeOut()
    {
        ToyOneAnim.Play("ToyOneFadeOut", 0, 0.0f);
    }
    private void DestoryToy()
    {
        Debug.Log("destory the object");
        Destroy(gameObject);
        Timer.TimeRunning();
    }
}
