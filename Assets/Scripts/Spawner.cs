using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject pinPrefab;

    public void SpawnPin() {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }

    public void SetTriger(bool triger) {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
