using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    void OnCollisionStay(Collision other){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
