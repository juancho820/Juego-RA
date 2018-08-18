using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    public GameObject lose;
    public Text Highscore;
    private int scoreCoins;
    private int highscore;
    public Text tiempoText;
    private float tiempo = 0;
    public Text finalScore;
    public Text tiempoFinal;
    private bool muerto;

    public static GameManager Instance { set; get; }

    void Start () {
        Time.timeScale = 1;
        Instance = this;
        score.text = "Puntaje: " + scoreCoins.ToString("0");
    }

    private void FixedUpdate()
    {
        if(muerto == false)
        {
            tiempo += Time.fixedDeltaTime;
        }

        tiempoText.text = "Segundos: " + tiempo.ToString("0");

        //if (tiempo <= 0)
        //{
        //    Loser();
        //    tiempo = 0;
        //    Time.timeScale = 0;
        //}
    }

    public void GetCoin()
    {
        scoreCoins++;
        score.text = "Puntaje: " + scoreCoins.ToString("0");
    }

    public void Loser()
    {
        muerto = true;
        lose.SetActive(true);
        finalScore.text = "Puntaje final: " + scoreCoins.ToString("0");
        tiempoFinal.text = "Tiempo: " + tiempo.ToString("0");

        highscore = PlayerPrefs.GetInt("highscore");
        Highscore.text = "Maximo Puntaje: " + highscore.ToString("0");

        if (scoreCoins > highscore)
        {
            highscore = scoreCoins;
            Highscore.text = "Maximo Puntaje: " + highscore.ToString("0");

            PlayerPrefs.SetInt("highscore", highscore);
        }

    }

    public void Resetiar()
    {
        SceneManager.LoadScene("AR");
    }
    
}
