using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;

    private bool isPinned;

    private void Start () {
        isPinned = false;
    }

    private void Update () {
        if (!isPinned) {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Rotator" && !FindObjectOfType<GameManager>().IsGameEnd()) {
            transform.SetParent(col.transform);
            Score.points += 1;
            isPinned = true;
        } else if (col.tag == "Rotator" && FindObjectOfType<GameManager>().IsGameEnd()) {
            transform.SetParent(col.transform);
            isPinned = true;
        } else if (col.tag == "Pin") {
            if (col.transform.parent != null) {
                foreach (Transform child in col.transform.parent) {
                    child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    child.GetComponent<CircleCollider2D>().isTrigger = false;
                    child.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
                }

                FindObjectOfType<GameManager>().EndGame();
                FindObjectOfType<Spawner>().SetTriger(false);
            }
        }
    }
}
