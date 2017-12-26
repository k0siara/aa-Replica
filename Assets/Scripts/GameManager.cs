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

    public bool isGameEnd;

    private void Start () {
        isGameEnd = false;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && isGameEnd) {
            RestartGame();
        }
    }

    public void EndGame () {
        if (!isGameEnd) {
            isGameEnd = true;

            DisableRotatorAndSpawner();
            animator.SetTrigger("EndGame");
        }
    }

    private void DisableRotatorAndSpawner() {
        rotator.enabled = false;
        spawner.enabled = false;
    }

    public bool IsGameEnd () {
        return isGameEnd;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameEnd = false;
    }
}