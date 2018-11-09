using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLogoEmpresa : MonoBehaviour {

    public void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
