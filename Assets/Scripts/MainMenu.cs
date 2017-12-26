using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject pauseMenuUI;

    private void Update() {
        
    }

    public void onPlayButtonTouch() {
        pauseMenuUI.active = false;
    }

    public void onQuitButtonTouch() {
        Application.Quit();
        Debug.Log("QUIT !");
    }
}
