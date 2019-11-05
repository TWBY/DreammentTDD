using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLimit : MonoBehaviour
{

    MoveByTouch moveByTouch;
    void Start()
    {
        moveByTouch = GetComponent<MoveByTouch>(); //獲取遊戲物件的Unit組件
    }

    void Update()
    {
        if (moveByTouch.IsTouch)
        {
            GameObject TouchObj = moveByTouch.BeTouchObj;

            switch (TouchObj.name)
            {
                case "DragedObject":
                    // SettingInfo(-0f, -4.5f, "YAxis");
                    SettingInfo(0, -1, "YAxis");
                    /* 
                    4.5>-3
                    3.5>-4
                    0>-7.5
                    1>-8.5
                    */
                    break;
                case "Car":
                    SettingInfo(1, -2, "ZAxis");
                    /* 
                    2.5>-3.5
                    0.5>-5.5
                    1>-5
                    -2>-8
                    */
                    break;
                    // case "SildeCube2":
                    //     SettingInfo(5, -3, "ZAxis");
                    //     break;
                    // case "SildeCube3":
                    //     SettingInfo(8, 4, "YAxis");
                    //     break;

            }
        }


        void SettingInfo(float HighLimit, float LowLimit, string MoveAxis)
        {
            moveByTouch.HighLimit = HighLimit;
            moveByTouch.LowLimit = LowLimit;
            moveByTouch.MoveAxis = MoveAxis;
        }
    }
}
