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


    private bool hasBeenHitByBluePulse = false;
    private bool hasBeenClicked = false;
    private int currentSpriteIndex;
    private List<Sprite> textures;
    private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<SpriteRenderer>();
        textures = new List<Sprite>();
        LoadImages(textures);
        currentSpriteIndex = (int)(Random.Range(0, textures.Count));
        this.setSprite(currentSpriteIndex);
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasBeenClicked)
            if (!hasBeenHitByBluePulse)
            {

                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        timer = 5f;
                        currentSpriteIndex++;
                        if (currentSpriteIndex > textures.Count - 1)
                        {
                            currentSpriteIndex = 0;
                        }
                        this.setSprite(currentSpriteIndex);
                        sphereColor = checkColor();

                    }
                }
            }
	}

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
        hasBeenClicked = true;
        setSprite(0);
    }

    public bool bluePulseActive()
    {
        if (sphereColor == sphereType.BLUE && hasBeenClicked)
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
