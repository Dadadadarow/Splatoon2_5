using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static float countTime;
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
        // countTimeに、ゲームが開始してからの秒数を格納
        countTime += Time.deltaTime;
        //Time = 180.0f - countTime;
        // 小数2桁にして表示
        GetComponent<Text>().text = countTime.ToString("F1");
        if (countTime >= 180.0f)
        {
            FinalCamera.SetActive(true);
        }
    }
}
