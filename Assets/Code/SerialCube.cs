using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialCube : MonoBehaviour {

	public SerialHandlerIn serialHandlerIn;
	public Text text;
	public GameObject cube;

	void Start () {
		//信号を受信したときに、そのメッセージの処理を行う
		//serialHandler.OnDataReceived += OnDataReceived;
	}

	// Update is called once per frame
	void Update () {
	}

	/*
	 * シリアルを受け取った時の処理
	 * 以下は加速度センサのテスト用
	 */
	void OnDataReceived(string message) {
		try {
			string[] angles = message.Split(',');
			text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "z:" + angles[2] + "\n" + "Speed:" + angles[3] + "\n"; // シリアルの値をテキストに表示
			Vector3 angle = new Vector3(float.Parse(angles[0]), float.Parse(angles[2]), float.Parse(angles[1]));
			cube.transform.rotation = Quaternion.Euler(angle);
		} catch (System.Exception e) {
			Debug.LogWarning(e.Message);
		}
	}
}
