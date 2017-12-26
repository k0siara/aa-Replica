using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    public void OnRestartButtonClick() {
        GameManager.instance.RestartGame();
    }

    public void OnQuitButtonClick() {
        Application.Quit();
        Debug.Log("Application Quit From GameOverMenu.OnQuitButtonClick()");
    }
}
