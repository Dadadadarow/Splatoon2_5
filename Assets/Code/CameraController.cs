using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        
    }
    float distance = 10.0f;
    // Update is called once per frame
    void Update()
    {
        //位置
        Vector3 playerPos = GameObject.Find("player_red").transform.position;
        float playerRot = GameObject.Find("player_red").transform.rotation.y;
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        Vector3 cameraPos = new Vector3(playerPos.x - distance * Mathf.Sin(Mathf.Deg2Rad*localAngle.y), playerPos.y + 5.0f, playerPos.z - distance * Mathf.Cos(Mathf.Deg2Rad * localAngle.y));
        this.gameObject.transform.position = new Vector3(cameraPos.x,cameraPos.y,cameraPos.z);

        //角度 下も塗りたくなったらここのx,yも変更しよう
        //localAngle.x = 0;
        localAngle.y = playerRot;
        //localAngle.z = 0;
        myTransform.localEulerAngles = localAngle;

    }
}
