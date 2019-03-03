using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI scoreEndUI;
    public TextMeshProUGUI highScoreUI;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        scoreUI.text = score.ToString();
        scoreEndUI.text = "Score \n" + score.ToString();
        highScoreUI.text = "High Score \n" + highScore.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Scoreup")
        {
            score++;
        }
    }
}
