using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    #region Singleton

    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    public Rotator rotator;
    public Spawner spawner;
    public Animator animator;

    public GameObject gameOverMenuUI;
    public bool isGameEnd;

    private void Start() {
        gameOverMenuUI.SetActive(false);
        isGameEnd = false;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            spawner.SpawnPin();
        }
    }

    public void EndGame () {
        if (!isGameEnd) {
            isGameEnd = true;

            DisableRotatorAndSpawner();
            animator.SetTrigger("EndGame");

            spawner.SetTriger(false);

            foreach (Pin pin in FindObjectsOfType<Pin>()) {
                pin.Fall();
            }
        }

        gameOverMenuUI.SetActive(true);
    }

    private void DisableRotatorAndSpawner() {
        rotator.enabled = false;
        spawner.enabled = false;
    }

    public void RestartGame() {
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameEnd = false;
    }
}