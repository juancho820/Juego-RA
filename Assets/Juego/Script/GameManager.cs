using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    public GameObject lose;
    private int scoreCoins;
    public Text tiempoText;
    private float tiempo = 40;
    public Text finalScore;


    public static GameManager Instance { set; get; }

    void Start () {
        Time.timeScale = 1;
        Instance = this;
        score.text = "Score: " + scoreCoins.ToString("0");
    }

    private void FixedUpdate()
    {
        tiempo -= Time.fixedDeltaTime;
        tiempoText.text = "Segundos: " + tiempo.ToString("0");

        if (tiempo <= 0)
        {
            Loser();
        }
    }

    public void GetCoin()
    {
        scoreCoins++;
        score.text = "Score: " + scoreCoins.ToString("0");
    }

    public void Loser()
    {
        lose.SetActive(true);
        finalScore.text = "Final Score: " + scoreCoins.ToString("0");
    }

    public void Resetiar()
    {
        SceneManager.LoadScene("AR");
    }
    
}
