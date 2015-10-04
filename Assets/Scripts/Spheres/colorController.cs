using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum sphereType
{
    BLUE,
    GREEN,
    PURPLE,
    RED,
    YELLOW
}

public class colorController : MonoBehaviour {
    

    public float timer = 3;
    public sphereType sphereColor;
    public bool isBlue = false;


    private bool hasBeenHitByBluePulse = false;
    private List<Sprite> textures;
	// Use this for initialization
	void Start () {
        textures = new List<Sprite>();
        LoadImages(textures);
	}
	
	// Update is called once per frame

    public bool bluePulseActive()
    {
        if (sphereColor == sphereType.BLUE && isBlue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void hitByBlue()  {
        hasBeenHitByBluePulse = true;
    }

    public bool hasBeenHitByBlue()
    {
        return hasBeenHitByBluePulse;
    }

    private void LoadImages(List<Sprite> textures) {
        for (int i = 1; i < 06; i++) {
            string texture = "Ball Textures/0" + i;
            Sprite texTmp = (Sprite)Resources.Load(texture, typeof(Sprite));
            textures.Add(texTmp);
        }
    }
}
