using UnityEngine;
using System.Collections;

public class touchGuitextStart : MonoBehaviour {
	public GUIText guitextLogo;
	// Use this for initialization
	void Start () {
		guiText.enabled = true;
		guitextLogo.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(guiText.enabled)
			{
				if(guiText.HitTest(Input.mousePosition))
				{
					print("click start");
					guiText.enabled = false;
					guitextLogo.enabled = false;
					//BroadcastMessage("gameStart",1);
					SendMessageUpwards("callGmGameStart");
				}
				
				/*Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray , out hit , 1000))
			{
				print(hit.collider.name);
				if(hit.collider.name == gameObject.name)
				{
					print("click start");
					guiText.enabled = false;
					guitextLogo.enabled = false;
					BroadcastMessage("gameStart",1);
					SendMessageUpwards("gameStart",1);
				}
			}*/
			}
		}
	
	}

	void resetup()
	{
		guiText.enabled = true;
		guitextLogo.enabled = true;
	}

}
