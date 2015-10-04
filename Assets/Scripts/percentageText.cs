using UnityEngine;
using System.Collections;

public class percentageText : scoreText {
	// Update is called once per frame
	void Update () {
		this.GetComponent<GUIText>().text = (score / 100).ToString() + "%";
	}
}
