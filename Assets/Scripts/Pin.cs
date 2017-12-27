using System;
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
        if (col.tag == "Rotator") {
            transform.SetParent(col.transform);
            isPinned = true;

            Score.points += 1;

        } else if (col.tag == "Pin") {
            GameManager.instance.EndGame();
        }
    }

    public void Fall() {
        isPinned = true;
        SetTrigger(false);
        SetBodyType(RigidbodyType2D.Dynamic);
    }

    public void SetTrigger(bool triger) {
        transform.GetComponent<CircleCollider2D>().isTrigger = triger;
        transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = triger;
    }

    public void SetBodyType(RigidbodyType2D bodyType) {
        transform.GetComponent<Rigidbody2D>().bodyType = bodyType;
    }

}
