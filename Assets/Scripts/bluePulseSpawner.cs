using UnityEngine;
using System.Collections;

public class bluePulseSpawner : MonoBehaviour {

    public bool isBlueBallPresent = true;
    private GameObject bluepulse;
    private Vector3 startPos;

    void Awake()
    {
        bluepulse = GameObject.Find("bluepulse");
        startPos = bluepulse.transform.position;
    }

    void OnMouseDown()
    {
        if (!isBlueBallPresent)
        {

            bluepulse.rigidbody2D.Sleep();
            bluepulse.transform.position = startPos;
            bluepulse.rigidbody2D.Sleep();
            bluepulse.rigidbody2D.WakeUp();
            isBlueBallPresent = true;
        }
    }


}
