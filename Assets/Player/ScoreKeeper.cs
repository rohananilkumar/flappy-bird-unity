using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score;
    public int Score { get { return score/2; } }
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = FindObjectOfType<TMP_Text>();
    }

    public void Increment()
    {
        score++;
        scoreText.text = Score.ToString();
    }

}
