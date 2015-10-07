using UnityEngine;
using System.Collections;

public class mapLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.mainTextureOffset = new Vector2(gameObject.renderer.material.mainTextureOffset.x , gameObject.renderer.material.mainTextureOffset.y +1);
	}
}
