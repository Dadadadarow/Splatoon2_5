using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialReceiver : MonoBehaviour {
	private static SerialPort sp = new SerialPort("COM7", 115200);
	
	// Use this for initialization
	void Start () {
		OpenConnection();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) {
			Debug.Log("Send message " + Input.mousePosition.x);
			sp.Write(Input.mousePosition.x.ToString() + "\0");
		}
	}
	 
	void OnApplicationQuit() 
	{
		sp.Close();
	}
	
	void OpenConnection() {
		if(sp != null) {
			if(sp.IsOpen) {
				sp.Close();
				Debug.LogError("Failed to open Serial Port, already open!");
			} else {
				sp.Open();
				sp.ReadTimeout = 50;
				Debug.Log("Open Serial port");
			}
		}
	}
}
