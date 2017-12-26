using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuUI;

    public void OnPlayButtonClick() {
        mainMenuUI.SetActive(false);

        // TODO change screen from Menu to Main
    }

    public void OnQuitButtonClick() {
        Application.Quit();
        Debug.Log("QUIT !");
    }
}
