using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnComponent : MonoBehaviour
{
    public Image olive;
    public Image goma;
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
        }
    }
}
