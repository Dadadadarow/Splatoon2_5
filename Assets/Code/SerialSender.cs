using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialSender : MonoBehaviour
{
    //SerialHandler.cのクラス
    public SerialHandlerOut serialHandlerOut;

    void Update() //ここは0.001秒ごとに実行される
    {
        if(playerController_1ino.sflag1 == 1)
        {
            serialHandlerOut.Write("1");
            Debug.Log("send serial code 1");
            playerController_1ino.sflag1 = 0;
        }
        if(playerController_2ino.sflag2 == 1)
        {
            serialHandlerOut.Write("2");
            Debug.Log("send serial code 2");
            playerController_2ino.sflag2 = 0;
        }
    }
}
