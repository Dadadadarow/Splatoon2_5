using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static float countTime = 180.0f;
    public static float minutes;
    public static float seconds;
    private GameObject FinalCamera;

    //float Time;
    // Use this for initialization
    void Start()
    {
        FinalCamera = GameObject.Find("FinalCamera");
        FinalCamera.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // countTimeに、ゲームが開始してからの秒数を引く
        countTime -= Time.deltaTime;
        //Time = 180.0f - countTime;
        minutes = Mathf.FloorToInt(countTime/60);
        seconds = Mathf.FloorToInt(countTime%60);
        // 何分何秒で表示
        GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (countTime <= 0.0f)
        {
            FinalCamera.SetActive(true);
        }
    }
}
