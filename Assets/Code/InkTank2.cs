using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InkTank2 : MonoBehaviour
{
    public Shoot2 shot2;
    public Slider ink;
    public  GameObject player2;
    public AudioClip reloadsound;
    public AudioClip OutOfBullets;
    private AudioSource audioSource;
    private float tank;
    public float fulltank2;
    public float reloadtime2 = 2.0f;
    private float loadtime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
        ink = GameObject.Find("Ink_2").GetComponent<Slider>();
        ink.minValue = 0.0f;
        ink.maxValue = fulltank2;
        ink.value = fulltank2;
        tank = fulltank2;
    }

    void Reload(){
        tank = fulltank2;
        ink.value = tank;
        //player2.GetComponent<Shoot2>().enabled = true;
        //reloadtime2 = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if((playerController_2ino.pre_trigger2 == 0 && playerController_2ino.trigger2 == 1) && tank > 0){
            shot2.Shot2();
            tank -= 1.0f;
            ink.value = tank;
        }

        if(tank <= 0){
            //player2.GetComponent<Shoot2>().enabled = false;
            if(playerController_2ino.pre_trigger2 == 0 && playerController_2ino.trigger2 == 1){
                audioSource.PlayOneShot(OutOfBullets);
            }
        }

        if(playerController_2ino.trigger2 == 1){
            if(loadtime <= reloadtime2){
                loadtime += Time.deltaTime;
            }
        }

        if(playerController_2ino.trigger2 == 0){
            loadtime = 0.0f;
        }

        if(loadtime >= reloadtime2){
            audioSource.PlayOneShot(reloadsound);
            //player2.GetComponent<Shoot2>().enabled = false;
            Reload();
            loadtime = 0.0f;
        }
        playerController_2ino.pre_trigger2 = playerController_2ino.trigger2;
     
    }
}
