using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class LivesTracker : MonoBehaviour
{
    public static int lives = Lives.lives;
    public Text LivesRemaining;

    private void Start()
    {
        LivesRemaining.text = lives.ToString();
    }
    public void DecreaseLives()
    {
        lives -= 1;
        LivesRemaining.text = lives.ToString();
        Debug.Log(lives);
    }
    public void IncreaseLives()
    {
        lives += 1;
        LivesRemaining.text = lives.ToString();
        Debug.Log(lives);
    }

}
