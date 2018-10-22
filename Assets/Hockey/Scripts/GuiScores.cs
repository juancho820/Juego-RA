using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiScores : MonoBehaviour {
    [SerializeField] private Text scorePlayerTxt;
    [SerializeField] private Text scoreAiTxt;

    public GameObject Win, Lose;

    private int scorePlayer;
    private int scoreAi;

    public void SumarPlayer()
    {
        scorePlayer++;
        if(scorePlayer >= 7)
        {
            Win.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SumarAi()
    {
        scoreAi++;
        if (scoreAi >= 7)
        {
            Lose.SetActive(true);
            Time.timeScale = 0;
        }
    } 
	
	void Update () {
        scorePlayerTxt.text = scorePlayer.ToString();
        scoreAiTxt.text = scoreAi.ToString();
	}

    public void resetiar()
    {
        SceneManager.LoadScene("Hockey");
    }
}
