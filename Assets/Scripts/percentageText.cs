using UnityEngine;
using System.Collections;

public class percentageText : scoreText {
	// Update is called once per frame
	void Update () {
		this.guiText.text = (score / 100).ToString() + "%";
	}
}
