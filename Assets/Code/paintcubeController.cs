using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintcubeController : MonoBehaviour
{
    int color;
    public static int yellowPoint;
    public static int redPoint;
    void Start()
    {
      // 現在使用されているマテリアルを取得
      Material mat = this.GetComponent<Renderer>().material;
      // マテリアルの色設定に赤色を設定
      mat.color = new Color(1.0f,1.0f,1.0f,0.3f);
    }

    void OnColisionEnter(Collider other)
    {
        if (other.gameObject.tag == "yellow_bullet")
        {
            Material mat = this.GetComponent<Renderer>().material;
            mat.color = new Color(1.0f,1.0f,0.0f,0.3f);
            yellowPoint += 1;
            if (color == 2)
            {
                redPoint -= 1;
            }
            color  =  1 ; //黄色状態
        }

        else if (other.gameObject.tag == "red_bullet")
        {
            Material mat = this.GetComponent<Renderer>().material;
            mat.color = new Color(1.0f,0.0f,0.0f,0.3f);
            redPoint += 1;
            if (color == 1)
            {
                yellowPoint -=1;
            }
            color = 2 ;//赤色状態
        }
        Debug.Log(yellowPoint);
        Debug.Log(redPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
