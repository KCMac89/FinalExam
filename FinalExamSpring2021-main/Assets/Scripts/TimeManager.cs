using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text timeLimitText;
 
    private float time = TimeSlider.timeLimit;

    void Start()
    { 
        timeLimitText.text = time.ToString("F2");

    }



    void Update()
    {
        time -= Time.deltaTime;
        if (time >= 0)
        {
            timeLimitText.text = time.ToString("F2");
        }
        else
        {
            //Exit Scene

            FindObjectOfType<NextScene>().LoadNextScene();

         
        }

    }
}
