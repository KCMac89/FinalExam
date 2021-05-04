using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour

{
    public Text timeText;

    public Slider slider;
    public static float timeLimit = 45.0f;

   

   
    void Update()
    {
      //  timeLimit = slider.value;

        timeText.text = slider.value.ToString();
    }

    public void UpdateTime()
    {
        timeLimit = slider.value;
    }
}
