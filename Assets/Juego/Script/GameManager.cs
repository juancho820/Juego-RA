using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject lose;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text Highscore;
    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Text finalScore;
    [SerializeField]
    private Text tiempoFinal;

    private int scoreCoins;
    private int highscore;
    private float tiempo = 0;
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
