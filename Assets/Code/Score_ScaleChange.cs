using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_ScaleChange : MonoBehaviour
{
    public Transform Abula_1;
    public Transform Abula_2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Abula_1.transform.localScale = new Vector3(1f, 1.698532f, 1f) *2.0f * (float)(paintcubeController.redPoint)/(float)(paintcubeController.redPoint+paintcubeController.yellowPoint);
        Abula_2.transform.localScale = new Vector3(1f, 1f, 1f)*2.0f * (float)(paintcubeController.yellowPoint)/(float)(paintcubeController.redPoint+paintcubeController.yellowPoint);
    }
}
