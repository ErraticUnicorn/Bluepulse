using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour {

	public Ability ability;
    public GameObject Ship;

	void OnMouseDown ()
	{
		if (ability != null)
    	{
			Generator generator = GetComponent<Generator>();
			if (generator != null && generator.isReady())
			{
				generator.Activate();
				ability.Use();
			}
		}
	}
}
