using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffComponent : MonoBehaviour
{
    public Text time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.countTime <= 170.0f){
            time.enabled = false;
        }
        
    }
}
