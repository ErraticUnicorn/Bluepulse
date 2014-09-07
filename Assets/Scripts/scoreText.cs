using UnityEngine;
using System.Collections;

public class scoreText : MonoBehaviour {

    int score;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.guiText.text = score.ToString();
	}

    public void updateScore(int add)
    {
        score += add;
    }
}
