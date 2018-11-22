using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerExperiencia : MonoBehaviour {

    public GameObject[] modelos1;
    public GameObject[] modelos2;
    public GameObject[] modelos3;
    public GameObject[] modelos4;
    private int i = 0;

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Landscape;
        i = 0;
	}

    public void Derecha()
    {
        i++;
        if(i > modelos1.Length - 1)
        {
            i = modelos1.Length - 1;
        }
        CambiarModelo();
    }
    public void Izquierda()
    {
        i--;
        if (i < 0)
        {
            i = 0;
        }
        CambiarModelo();
    }

    public void CambiarModelo()
    {
        for (int i = 0; i < modelos1.Length; i++)
        {
            modelos1[i].SetActive(false);
            modelos2[i].SetActive(false);
            modelos3[i].SetActive(false);
            modelos4[i].SetActive(false);
        }
        modelos1[i].SetActive(true);
        modelos2[i].SetActive(true);
        modelos3[i].SetActive(true);
        modelos4[i].SetActive(true);
    }

    public void Volver()
    {
        SceneManager.LoadScene("Lobby");
    }
}

