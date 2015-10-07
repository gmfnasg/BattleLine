using UnityEngine;
using System.Collections;

public class changScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Menu))
		{
			switch(Application.loadedLevel)
			{
			case 0:
				Application.LoadLevel(1);
				break;
			case 1:
				Application.LoadLevel(2);
				break;
			case 2:
				Application.LoadLevel(0);
				break;
			}
		}
	}
}
