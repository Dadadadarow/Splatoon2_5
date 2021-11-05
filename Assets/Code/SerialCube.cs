using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialCube : MonoBehaviour {

	public SerialHandler serialHandler;
	public Text text;
	public GameObject cube;

	// Use this for initialization
	void Start () {
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
	}

	// Update is called once per frame
	void Update () {

	}

	/*
	 * シリアルを受け取った時の処理
	 */
	void OnDataReceived(string message) {
		try {
			string[] angles = message.Split(',');
			text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "z:" + angles[2] + "\n"; // シリアルの値をテキストに表示
            Debug.Log(">>>>>>>"+angles[0]);
			// Vectorは前から順番にx,y,zだけど、そのままセットすると
			// Unity上の回転の見た目が変になるので、y,zの値を入れ替えている。
			Vector3 angle = new Vector3(float.Parse(angles[0]), float.Parse(angles[2]), float.Parse(angles[1]));
			cube.transform.rotation = Quaternion.Euler(angle);
		} catch (System.Exception e) {
			Debug.LogWarning(e.Message);
		}
	}
}