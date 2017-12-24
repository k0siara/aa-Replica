using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;

    public static int points;

	void Start () {
        points = 0;
	}
	
	void Update () {
        score.text = points.ToString();
	}
}
