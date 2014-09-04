using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colorController : MonoBehaviour {

    public float timer = 3;


    private bool isBlue = false;
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
        checkBlue();
        this.setSprite(currentSpriteIndex);
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasBeenClicked)
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
                checkBlue();
            }
        }
	}

    public bool checkBlue()  {
        if (currentSpriteIndex == 0) {
            isBlue = true;
        }
        else {
            isBlue = false;
        }
        return isBlue;
    }

    public void setBlue()
    {
        hasBeenClicked = true;
        setSprite(0);
    }

    private void setSprite(int newSprite) {
        renderer.sprite = textures[newSprite];
    }

    private void LoadImages(List<Sprite> textures) {
        for (int i = 1; i < 05; i++) {
            string texture = "Ball Textures/0" + i;
            Sprite texTmp = (Sprite)Resources.Load(texture, typeof(Sprite));
            textures.Add(texTmp);
        }
    }
}
