using UnityEngine;
using System.Collections;

public class scoreText : MonoBehaviour {

    protected int score;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<GUIText>().text = score.ToString();
	}

    public void updateScore(int add)
    {
        score += add;
    }
}
