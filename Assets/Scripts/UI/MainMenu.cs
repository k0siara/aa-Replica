using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuUI;

    public void OnPlayButtonClick() {
        mainMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnQuitButtonClick() {
        Application.Quit();
        Debug.Log("QUIT !");
    }
}
