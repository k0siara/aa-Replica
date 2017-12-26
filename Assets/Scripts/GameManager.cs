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

    public GameObject gameOverUI;

    public Rotator rotator;
    public Spawner spawner;
    public Animator animator;

    public bool isGameEnd; // TODO try to remove

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

            MakePinsFall(rotator.transform);
            spawner.SetTriger(false);

            DisableRotatorAndSpawner();
            animator.SetTrigger("EndGame");
        }

        // gameOverUI.SetActive(false);
    }

    private void MakePinsFall(Transform pins) {
        foreach (Transform child in pins) {
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            if (child.childCount > 0) {
                child.GetChild(0).parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameEnd = false;
    }
}