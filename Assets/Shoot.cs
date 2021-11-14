using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shoot : MonoBehaviour {
 
    // bullet prefab
    public GameObject bullet;
 
    // 弾丸発射点
    public Transform muzzle;
 
    // 弾丸の速度
    public float speed = 1000;
    private static int shoot_flag = 0;
    SerialHandler serialHandler;
 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // z キーが押された時
        // if (Input.GetKeyDown(KeyCode.Z)){
        if (shoot_flag == 0 && playerController.trigger == 1){
            
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;
 
            Vector3 force;
 
            force = this.gameObject.transform.forward * speed;
 
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);
 
            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;
        }
        shoot_flag = playerController.trigger;
	}

    // 	void OnDataReceived(string message) {
	// 	try {
	// 		string[] angles = message.Split(',');
    //         trigger = int.Parse(angles[5]);
	// 	} catch (System.Exception e) {
	// 		Debug.LogWarning(e.Message);
	// 	}
	// }
}
