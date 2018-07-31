using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    private int scoreCoins;

    public static GameManager Instance { set; get; }

    // Use this for initialization
    void Start () {
        Instance = this;
        score.text = "Score: " + scoreCoins.ToString("0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetCoin()
    {
        scoreCoins++;
        score.text = "Score: " + scoreCoins.ToString("0");
    }
    
}
