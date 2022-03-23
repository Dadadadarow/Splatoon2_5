using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shoot1 : MonoBehaviour {
 
    // bullet prefab
    public GameObject bullet1;
 
    // 弾丸発射点
    public Transform muzzle1;
 
    // 弾丸の速度
    public float speed = 1000;

    private AudioSource audioSource;
 
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
	}
	
    public void Shot1(){
        audioSource.Play();
            
        // 弾丸の複製
        GameObject bullets1 = Instantiate(bullet1) as GameObject;

        Vector3 force;

        force = this.gameObject.transform.forward * speed;

        // Rigidbodyに力を加えて発射
        bullets1.GetComponent<Rigidbody>().AddForce(force);

        // 弾丸の位置を調整
        bullets1.transform.position = muzzle1.position;
    }
	// Update is called once per frame
	void Update () {
        // z キーが押された時
        // if(Input.GetKeyDown(KeyCode.Z))
        // triggerが押された時
        // if (playerController_1ino.pre_trigger1 == 0 && playerController_1ino.trigger1 == 1)
        // {
        //     //SEを鳴らす
        //     audioSource.Play();
            
        //     // 弾丸の複製
        //     GameObject bullets1 = Instantiate(bullet1) as GameObject;
 
        //     Vector3 force;
 
        //     force = this.gameObject.transform.forward * speed;
 
        //     // Rigidbodyに力を加えて発射
        //     bullets1.GetComponent<Rigidbody>().AddForce(force);
 
        //     // 弾丸の位置を調整
        //     bullets1.transform.position = muzzle1.position;
        //}
		//playerController_1ino.pre_trigger1 = playerController_1ino.trigger1;
		
	}
}