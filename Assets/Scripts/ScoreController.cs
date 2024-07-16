using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private String score;
    private int curScore = 0;
    public Text text;
     public void AddScore()
    {
        score = $"分数：{++curScore}";
        text.text = score;
    }
     
     public void ResetScore()
     {
         curScore = 0;
         score = $"分数：0";
         text.text = score;
     }

    private void OnEnable()
    {
        //score = 
    }
}
