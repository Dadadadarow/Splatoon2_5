using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shoot2 : MonoBehaviour {
 
    // bullet prefab
    public GameObject bullet;
 
    // 弾丸発射点
    public Transform muzzle;
 
    // 弾丸の速度
    public float speed = 1000;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // z キーが押された時
        if (playerController_2ino.pre_trigger2 == 0 && playerController_2ino.trigger2 == 1){
            
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;
 
            Vector3 force;
 
            force = this.gameObject.transform.forward * speed;
 
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);
 
            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;
        }
		playerController_2ino.pre_trigger2 = playerController_2ino.trigger2;
	}
}