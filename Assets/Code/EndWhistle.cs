using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWhistle : MonoBehaviour
{
 
    public AudioClip whistle;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.countTime <= 170.0f)
        {
            audioSource.PlayOneShot(whistle);
        }
    }
}
