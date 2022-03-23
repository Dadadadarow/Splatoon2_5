using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchControl : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.countTime <= 60.0f){
            audioSource.pitch = 1.1f;
        }
    }
}
