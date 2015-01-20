using UnityEngine;
using System.Collections;

public class shipController : MonoBehaviour {

    public float timeToCrossSpace;
    private scoreText score;

	// Use this for initialization
	IEnumerator Start () {
        Vector2 startPoint = this.transform.position;
        Vector2 endPoint = new Vector2(startPoint.x + 7, startPoint.y);
        while(true){
            yield return StartCoroutine(MoveObject(this.transform, startPoint, endPoint, timeToCrossSpace));
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator MoveObject(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
