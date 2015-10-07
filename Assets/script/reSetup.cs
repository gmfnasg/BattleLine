using UnityEngine;
using System.Collections;

public class reSetup : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void resetup()
	{
		/*if(gameObject.tag == "enemyClone")
		{
			Destroy(gameObject);
		}*/

		GameObject[] allclone;
		allclone =  GameObject.FindGameObjectsWithTag("enemyClone");

		foreach(GameObject colne in allclone)
		{
			Destroy(colne);
		}
		//Destroy(GameObject.Find("enemy Sphere(Clone)"));

		if(gameObject.tag == "playerpop")
		{
			//gameObject.renderer.enabled = true;
			gameObject.collider.enabled = true;
		}
	}
}
