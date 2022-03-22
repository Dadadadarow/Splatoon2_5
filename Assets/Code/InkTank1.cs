using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InkTank1 : MonoBehaviour
{
    public Slider ink;
    public  GameObject player1;
    private float tank;
    public float fulltank;
    public float reloadtime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        ink = GameObject.Find("Ink_1").GetComponent<Slider>();
        ink.minValue = 0.0f;
        ink.maxValue = fulltank;
        ink.value = fulltank;
        tank = fulltank;
    }

    void Reload(){
        tank = fulltank;
        ink.value = tank;
        player1.GetComponent<Shoot1>().enabled = true;
        reloadtime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)&&reloadtime == 2.0f){
            tank -= 1.0f;
            ink.value = tank;
        }

        if(tank <= 0){
            player1.GetComponent<Shoot1>().enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.R)){
            reloadtime -= Time.deltaTime;
            player1.GetComponent<Shoot1>().enabled = false;
            Invoke(nameof(Reload), 2.0f);
        }
    }
}
