using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    public GameObject Lose;
    private int scoreCoins;

    public static GameManager Instance { set; get; }

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Instance = this;
        score.text = "Score: " + scoreCoins.ToString("0");
    }
	
	// Update is called once per frame
	void Update () {

        //if(scoreCoins >= 5)
        //{
        //    Win.SetActive(true);
        //}
		
	}

    public void GetCoin()
    {
        scoreCoins++;
        score.text = "Score: " + scoreCoins.ToString("0");
    }

    public void Loser()
    {
        Lose.SetActive(true);

    }

    public void Resetiar()
    {
        SceneManager.LoadScene("AR");
    }
    
}
