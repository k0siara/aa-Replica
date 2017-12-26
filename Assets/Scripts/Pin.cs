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
        if (col.tag == "Pin") {
            if (Collider2DUtils.HasParent(col)) {
                GameManager.instance.EndGame();
                    
                MakePinsFall(col.transform.parent);

                
                FindObjectOfType<Spawner>().SetTriger(false);
            }
        } else if (col.tag == "Rotator") {
            transform.SetParent(col.transform);
            isPinned = true;

            if (!GameManager.instance.isGameEnd) {
                Score.points += 1;
            }
        }
    }

    

    private void MakePinsFall(Transform pins) {
        foreach (Transform child in pins) {
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            child.GetComponent<CircleCollider2D>().isTrigger = false;
            child.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
