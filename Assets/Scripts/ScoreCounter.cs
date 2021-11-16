using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreDisplayer;

    public static int scoreCount;
    void Start()
    {
        scoreCount = 0;
    }

    public void AddScore(int score)
    {
        scoreCount += score;
        RedrawDisplayer();
    }

    private void RedrawDisplayer()
    {
        scoreDisplayer.text = scoreCount.ToString();
    }
}
