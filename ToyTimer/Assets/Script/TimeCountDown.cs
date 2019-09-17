using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCountDown : MonoBehaviour
{
    float time_int = 10.0f;
    private Text time_UI;

    public GameObject Toy1;

    void Start()
    {
        time_UI = gameObject.GetComponent<Text>();
        TimeRunning();
    }

    // Update is called once per frame
    void Update()
    {
        if (time_int != 0)
        {
            time_UI.text = "倒數計時: " + time_int + "";
        }

    }

    public void timer()
    {
        time_int -= 1;
        if (time_int == 0)
        {
            time_UI.text = "Game over";
            CancelTimeRun();
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void resetCountDownTime(float Time)
    {
        time_int = Time;
    }
    public void CancelTimeRun()
    {
        CancelInvoke("timer");
    }

    public void TimeRunning()
    {
        InvokeRepeating("timer", 1, 1);
    }
}




