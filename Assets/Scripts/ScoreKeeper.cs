using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    private int score = 0;
    public Text scoreDisplay;
    public void AddScore(int val)
    {
        score += val;
        //Debug.Log("Entered AddScore" + score);
        UpdateScore();
    }

    void UpdateScore()
    {
        //Debug.Log("Entered UpdateScore");
        displayScore();
    }

    private void displayScore()
    {
        //Debug.Log("The ref here is : " + scoreDisplay);
        scoreDisplay.text = "Score : " + score.ToString();
    }
}
