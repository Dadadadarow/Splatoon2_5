using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnComponent : MonoBehaviour
{
    public Image olive;
    public Image goma;
    public Text oliveWIN;
    public Text gomaWIN;

    public Text draw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.countTime <= 165.0f){
            olive.enabled = true;
            goma.enabled = true;
            if(paintcubeController.yellowPoint > paintcubeController.redPoint){
                oliveWIN.enabled = true;
            }
            if(paintcubeController.yellowPoint < paintcubeController.redPoint){
                gomaWIN.enabled = true;
            }
            else{
                draw.enabled = true;
            }
        }
    }
}
