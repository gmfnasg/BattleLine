using UnityEngine;
using System.Collections;

public class textureOffset : MonoBehaviour {
	public float scrollSpeed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetTextureOffset ("_MainTex",new Vector2(renderer.material.mainTextureOffset.x , renderer.material.mainTextureOffset.y + scrollSpeed));

	}
}
