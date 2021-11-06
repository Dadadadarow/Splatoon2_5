using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.IO.Ports;

public class playerController : MonoBehaviour
{
    float jairo = 225f; //初期の値のRotation.yの値
    //Vector3 jairoDir = new Vector3(0f, 0f, 0f);
    float minAngle = 225f;
	float maxAngle = 225f;
    Rigidbody rigid;
    float force = 45.0f;
    float maxSpeed = 2.0f;
    float wSpeed = 0.0f;
    public SerialHandler serialHandler;

	// private SerialPort serialPort;
	void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        transform.Rotate(0f,225f,0f);
		//serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update() 
    {
        //回転と直進の２つに分割する。

        //回転
        //本来はジャイロセンサーから値を読み取ってjairoに入れ込む
        //今は特別にキー入力とする。
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            jairo += 10;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            jairo -= 10;
        }

        //Debug.Log(jairo);
        maxAngle = jairo;

        //minAngle(225)とmaxAngle(225+jairo)の差分を細かく分けて滑らかに回転
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
		transform.eulerAngles = new Vector3(0, angle, 0);
        //回転終了

        //直進
        float speed = Mathf.Sqrt(rigid.velocity.x*rigid.velocity.x+rigid.velocity.z*rigid.velocity.z);
        if (speed < this.maxSpeed)
        {
            this.rigid.AddForce(force*Mathf.Sin(jairo*Mathf.Deg2Rad), 0, force*Mathf.Cos(jairo*Mathf.Deg2Rad));
        }
        // if (serialPort.IsOpen)
        // {
        //     string data = serialPort.ReadLine();
        //     Debug.Log(data);
        // }
    }
	void OnDataReceived(string message) {
		try {
			string[] angles = message.Split(',');
			wSpeed = float.Parse(angles[3]);
		} catch (System.Exception e) {
			Debug.LogWarning(e.Message);
		}
	}
}
