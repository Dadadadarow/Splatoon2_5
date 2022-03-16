using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameobject : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.countTime <= 165.0f){
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(true);
            obj4.SetActive(true);
            obj5.SetActive(true);
            obj6.SetActive(true);
        }
        
    }
}
