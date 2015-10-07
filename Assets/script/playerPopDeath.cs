using UnityEngine;
using System.Collections;

public class playerPopDeath : MonoBehaviour {

	public GameObject solider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playerPopToDeath()
	{
		print("get message playerPopToDeath, gameobject name=" + gameObject.name);
		//Destroy(gameObject);
		solider.SetActive(false);
		//gameObject.renderer.enabled = false;
		gameObject.collider.enabled = false;
	}

	void resetup()
	{
		solider.SetActive(true);
	}

}
