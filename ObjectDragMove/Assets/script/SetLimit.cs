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
                case "SildeCube1":
                    SettingInfo(5, -5, "XAxis");
                    break;
                case "SildeCube2":
                    SettingInfo(5, -3, "ZAxis");
                    break;
                case "SildeCube3":
                    SettingInfo(8, 4, "YAxis");
                    break;

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
