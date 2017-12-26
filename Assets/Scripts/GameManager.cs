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
    public bool isGameEnd; // TODO try to remove

    private void Start () {
        gameOverMenuUI.SetActive(false);
        isGameEnd = false;
    }

    public void EndGame () {
        if (!isGameEnd) {
            isGameEnd = true;

            DisableRotatorAndSpawner();
            animator.SetTrigger("EndGame");

            spawner.SetTriger(false);

            MakePinsFall(rotator.transform);
        }

        gameOverMenuUI.SetActive(true);
    }

    private void MakePinsFall(Transform pins) { 
        foreach (Transform child in pins) {
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            child.GetComponent<CircleCollider2D>().isTrigger = false;
            child.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
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
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameEnd = false;
    }
}