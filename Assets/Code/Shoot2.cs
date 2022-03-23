using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shoot2 : MonoBehaviour {
 
    // bullet prefab
    public GameObject bullet2;
 
    // 弾丸発射点
    public Transform muzzle2;
 
    // 弾丸の速度
    public float speed = 1000;

    private AudioSource audioSource;
 
	// Use this for initialization
	void Start ()
    {
		audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
	}
	
    public void Shot2(){
        audioSource.Play();
            
        // 弾丸の複製
        GameObject bullets2 = Instantiate(bullet2) as GameObject;

        Vector3 force;

        force = this.gameObject.transform.forward * speed;

        // Rigidbodyに力を加えて発射
        bullets2.GetComponent<Rigidbody>().AddForce(force);

        // 弾丸の位置を調整
        bullets2.transform.position = muzzle2.position;
    }

	// Update is called once per frame
	void Update () {
        // z キーが押された時
        // if(Input.GetKeyDown(KeyCode.Z))

        // if (playerController_2ino.pre_trigger2 == 0 && playerController_2ino.trigger2 == 1)
        // {
        //     //SEを鳴らす
        //     audioSource.Play();
            
        //     // 弾丸の複製
        //     GameObject bullets2 = Instantiate(bullet2) as GameObject;
 
        //     Vector3 force;
 
        //     force = this.gameObject.transform.forward * speed;
 
        //     // Rigidbodyに力を加えて発射
        //     bullets2.GetComponent<Rigidbody>().AddForce(force);
 
        //     // 弾丸の位置を調整
        //     bullets2.transform.position = muzzle2.position;
        // }
		//playerController_2ino.pre_trigger2 = playerController_2ino.trigger2;
	}
}