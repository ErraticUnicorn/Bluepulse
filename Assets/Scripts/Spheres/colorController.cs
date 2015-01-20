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
    private int currentSpriteIndex;
    private List<Sprite> textures;
    private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<SpriteRenderer>();
        textures = new List<Sprite>();
        LoadImages(textures);
        if (!isBlue)
        {
            currentSpriteIndex = (int)(Random.Range(1, textures.Count));
            this.setSprite(currentSpriteIndex);
        }
        else
        {
            this.setSprite(0);
        }
	}
	
	// Update is called once per frame

    public sphereType checkColor()
    {
        if (currentSpriteIndex == 0)
        {
            return sphereType.BLUE;
        }
        else if(currentSpriteIndex == 1)
        {
            return sphereType.GREEN;
        }
        else if (currentSpriteIndex == 2)
        {
            return sphereType.PURPLE;
        }
        else if (currentSpriteIndex == 3)
        {
            return sphereType.RED;
        }
        else 
        {
            return sphereType.YELLOW;
        }
    }

    public void setBlue()
    {
        setSprite(0);
    }

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

    private void setSprite(int newSprite) {
        renderer.sprite = textures[newSprite];
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
