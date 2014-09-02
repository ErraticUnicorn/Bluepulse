using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colorController : MonoBehaviour {

    private List<Sprite> textures;
    private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<SpriteRenderer>();
        textures = new List<Sprite>();
        LoadImages(textures);

        this.setSprite(textures[(int) (Random.Range(0, textures.Count))]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void setSprite(Sprite newSprite) {
        renderer.sprite = newSprite;
    }

    private void LoadImages(List<Sprite> textures) {
        for (int i = 1; i < 05; i++) {
            string texture = "Ball Textures/0" + i;
            Sprite texTmp = (Sprite)Resources.Load(texture, typeof(Sprite));
            textures.Add(texTmp);
        }
    }
}
