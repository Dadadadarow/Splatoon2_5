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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision");
        if (other.gameObject.tag == "yellow_bullet")
        {
            Material mat = this.GetComponent<Renderer>().material;
            mat.color = new Color(1.0f,1.0f,0.0f,0.3f);
            if (color == 0 || color==2)
            {
                yellowPoint += 1;
            }
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
            if (color == 0 || color == 1)
            {
                redPoint += 1;
            }
            if (color == 1)
            {
                yellowPoint -= 1;
            }
            color = 2 ;//赤色状態
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(yellowPoint);
    }
}
