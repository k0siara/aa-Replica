using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuUI;

    private void Update() {
        
    }

    public void onPlayButtonTouch() {
        mainMenuUI.active = false;
    }

    public void onQuitButtonTouch() {
        Application.Quit();
        Debug.Log("QUIT !");
    }
}
