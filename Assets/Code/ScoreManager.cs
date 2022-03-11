using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Score_Slider").GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = 1000;
        slider.value = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "REDPOINTS:" + paintcubeController.redPoint + "YELLOWPOINTS:" + paintcubeController.yellowPoint;
        slider.value = 1000*(paintcubeController.redPoint)/(paintcubeController.redPoint+paintcubeController.yellowPoint);
        Debug.Log(slider.value);
    }
}
