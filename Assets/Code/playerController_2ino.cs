using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using System.IO.Ports;

public class playerController_2ino : MonoBehaviour
{
    float jairo = 0f; //初期の値のRotation.yの値
    //Vector3 jairoDir = new Vector3(0f, 0f, 0f);
    float minAngle = 0f;
	float maxAngle = 0f;
    Rigidbody rigid;
    float force = 45.0f;
    float maxSpeed = 2.0f;
    float wSpeed = 0.0f;
    // float control = 0.0f;
    float gyro = 0.0f;
    public static int trigger = 0;
    public SerialHandlerIn2 serialHandlerIn;
	public Text text;

    int state;

	// private SerialPort serialPort;
    // test
	void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        transform.Rotate(0f,0f,0f);
		serialHandlerIn.OnDataReceived += OnDataReceived;
    }
    void Respawn() 
    {
        transform.Rotate(0f, 0f, -90f);
        this.rigid.constraints = RigidbodyConstraints.FreezeRotationZ;
        transform.position = new Vector3(4.89f, 4.5f, 29.66f);
        //MainCamera1.SetActive(true);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "yellow_bullet" && state != 3)
        {
            state += 1;
        }
        if (other.gameObject.tag == "yellow_bullet" && state==3)
        {
            state = 0;
            //this.rigid = this.GetComponent<Rigidbody>();
            //this.rigid.constraints = RigidbodyConstraints.None;
            //this.rigid.constraints = RigidbodyConstraints.FreezeRotationX;
            //transform.Rotate(0f, 0f, 90f);
            transform.position = new Vector3(4.89f, -4.5f, 29.66f);
            //MainCamera1.SetActive(false);
            Invoke(nameof(Respawn), 3f);
            
        }
    }
    void Update() 
    {

        if (trigger == 1){
            GetComponent<AudioSource>().Play();
        }

        //回転と直進の２つに分割する。
        //回転
        //本来はジャイロセンサーから値を読み取ってjairoに入れ込む
        //今は特別にキー入力とする。
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        if (gyro < -1.2f)
        {
            jairo += 1;
        }
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (gyro > 1.2f)
        {
            jairo -= 1;
        }

        //Debug.Log(jairo);
        maxAngle = jairo;

        //minAngle(225)とmaxAngle(225+jairo)の差分を細かく分けて滑らかに回転
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
		transform.eulerAngles = new Vector3(0, angle, 0);
        //回転終了

        //直進
        if (wSpeed > 1.0f)
            maxSpeed = 5.0f;
        else
            maxSpeed = 2.0f;
        float speed = Mathf.Sqrt(rigid.velocity.x*rigid.velocity.x+rigid.velocity.z*rigid.velocity.z);
        if (speed < this.maxSpeed)
        {
            this.rigid.AddForce(force*Mathf.Sin(jairo*Mathf.Deg2Rad), 0, force*Mathf.Cos(jairo*Mathf.Deg2Rad));
        }
    }
	void OnDataReceived(string message) {
		try {
			string[] angles = message.Split(',');
            // text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "z:" + angles[2] + "\n" + "Speed:" + angles[3] + "Gyro:" + angles[4] + "\n"; // シリアルの値をテキストに表示
			wSpeed = float.Parse(angles[0]);
            //control = float.Parse(angles[1]);
            gyro = float.Parse(angles[1]);
            // Debug.Log(gyro);
            trigger = int.Parse(angles[2]);

            if (wSpeed > 1.1f)
                text.text = "Running!!!\n";
		} catch (System.Exception e) {
			Debug.LogWarning(e.Message);
		}
	}
}
