using UnityEngine;
using System.Collections;

public class spherePocket : MonoBehaviour {

    public sphereType currentType;

    //rough hack will fix later
    private scoreText scorer;

    void Start()
    {
        scorer = GameObject.Find("scorer").GetComponent<scoreText>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sphere")
        {
            colorController color = other.gameObject.GetComponent<colorController>();
            if (color.bluePulseActive())
            {
                other.gameObject.SetActive(false);
                scorer.updateScore(-1);
            }

            if (color.hasBeenHitByBlue() && color.sphereColor == this.currentType)
            {
                scorer.updateScore(1);
                other.gameObject.SetActive(false);
            }
        }
    }
}
