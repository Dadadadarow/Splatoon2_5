using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InkTank1 : MonoBehaviour
{
    public Shoot1 shot1;
    public Slider ink;
    public  GameObject player1;
    public AudioClip reloadsound;
    public AudioClip OutOfBullets;
    private AudioSource audioSource;
    private float tank;
    public float fulltank1;
    public float reloadtime1 = 2.0f;
    private float loadtime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
        ink = GameObject.Find("Ink_1").GetComponent<Slider>();
        ink.minValue = 0.0f;
        ink.maxValue = fulltank1;
        ink.value = fulltank1;
        tank = fulltank1;
    }

    void Reload(){
        tank = fulltank1;
        ink.value = tank;
        player1.GetComponent<Shoot1>().enabled = true;
        //reloadtime1 = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if((playerController_1ino.pre_trigger1 == 0 && playerController_1ino.trigger1 == 1) && tank > 0){
            shot1.Shot1();
            tank -= 1.0f;
            ink.value = tank;
        }

        if(tank <= 0){
            //player1.GetComponent<Shoot1>().enabled = false;
            if(playerController_1ino.pre_trigger1 == 0 && playerController_1ino.trigger1 == 1){
                audioSource.PlayOneShot(OutOfBullets);
            }
        }

        if(playerController_1ino.trigger1 == 1){
            if(loadtime <= reloadtime1){
                loadtime += Time.deltaTime;
            }
        }

        if(playerController_1ino.trigger1 == 0){
            loadtime = 0.0f;
        }

        if(loadtime >= reloadtime1){
            audioSource.PlayOneShot(reloadsound);
            //player1.GetComponent<Shoot1>().enabled = false;
            Reload();
            loadtime = 0.0f;
        }
        playerController_1ino.pre_trigger1 = playerController_1ino.trigger1;
        
    }
}
