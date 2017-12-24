using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Rotator rotator;
    public Spawner spawner;

    public Animator animator;

    private bool isGameEnd;

    private void Start ()
    {
        isGameEnd = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && isGameEnd)
        {
            Restart();
        }
    }

    public void EndGame ()
    {
        if (!isGameEnd)
        {
            isGameEnd = true;

            rotator.enabled = false;
            spawner.enabled = false;

            animator.SetTrigger("EndGame");
        }

        Debug.Log("END GAME");
    }

    public bool IsGameEnd ()
    {
        return isGameEnd;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
