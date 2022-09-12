﻿/*
* Zach Wilson
* CIS 350 - Group Project
* This script controls the scoreboard and holds the score variable that other scripts use
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text textbox;
    public int defaultIncrament; //the default incramentation value called by the methods if no parameter is passed through
    private int score = 0; //score is privated so that it cant be edited directly but only through the methods
    private const int constInt = -999999999; // a default parameter option so that the default incrament can be somewhat dynamic

    //bool for testing purposes
    public bool forceIncrament = false;
    public bool forceDecrament = false;

    // Start is called before the first frame update
    void Start()
    {
        if (defaultIncrament <= 0) { defaultIncrament = 1; }
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= 0) { score = 0; } //this prevents the allowing of negative scores. (comment out this line if we want that option)
        textbox.text = "Score: " + score;
        if (forceIncrament || forceDecrament) { testerMethod(); }
    }

    public void incramentScore(int awardedPoints = constInt)
    {
        if (awardedPoints == constInt) { awardedPoints = defaultIncrament;  }
        score += awardedPoints;
    }

    public void decramentScore(int removedPoints = constInt)
    {
        if (removedPoints == constInt) { removedPoints = defaultIncrament; }
        score -= removedPoints;
    }

    private void testerMethod()
    {
        if(forceIncrament)
        {
            forceIncrament = false;
            incramentScore();
        }
        else
        {
            forceDecrament = false;
            decramentScore();
        }
    }
}
