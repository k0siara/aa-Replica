using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    public Rotator rotator;
    public Spawner spawner;
    public Animator animator;

    [SerializeField]
    private float colDepth;

    [SerializeField]
    private float zPosition;

    private bool isGameEnd;

    private void Start () {
        colDepth = 4f;
        zPosition = 0f;
        isGameEnd = false;

        AddScreenColliders();
    }

    private void AddScreenColliders() {
        // Generate our empty objects
        Transform topCollider = new GameObject().transform;
        Transform bottomCollider = new GameObject().transform;
        Transform rightCollider = new GameObject().transform;
        Transform leftCollider = new GameObject().transform;

        // Add the colliders
        topCollider.gameObject.AddComponent<BoxCollider2D>();
        bottomCollider.gameObject.AddComponent<BoxCollider2D>();
        rightCollider.gameObject.AddComponent<BoxCollider2D>();
        leftCollider.gameObject.AddComponent<BoxCollider2D>();

        // Make them the child of whatever object this script is on, 
        // preferably on the Camera so the objects move with the camera without extra scripting
        topCollider.parent = transform;
        bottomCollider.parent = transform;
        rightCollider.parent = transform;
        leftCollider.parent = transform;

        // Generate world space point information for position and scale calculations
        Vector3 cameraPos = Camera.main.transform.position;

        Vector2 screenSize;
        screenSize.x = Vector2.Distance(
            Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), 
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(
            Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), 
            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        // Change our scale and positions to match the edges of the screen...
        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        topCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        topCollider.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (topCollider.localScale.y * 0.5f), zPosition);
        bottomCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        bottomCollider.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (bottomCollider.localScale.y * 0.5f), zPosition);
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
    }
}