using UnityEngine;
using System.Collections;

public class collisionlEnemy : MonoBehaviour {
	public bool gameStart=false;
	public bool gateUse=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) 
	{
		if(gameStart)
		{
			//print("error 碰到");
			if(collision.gameObject.tag == "enemyClone")
			{
				print(gameObject.name +"敵方元素碰撞");
				if(!gateUse)
				{
					if(collision.gameObject.renderer.material.color == gameObject.renderer.material.color)
					{
						SendMessageUpwards("addScore",1);
						SendMessageUpwards("callMissionSetupAddEnemy");
						SendMessageUpwards("callGmContinuousKill");
						print("顏色一樣");
					}
					//else if(gameObject.renderer.material.color != gameObject.renderer.material.color)
					else
					{
						print("顏色不一樣");
						//BroadcastMessage("hurt",collision.gameObject.name);
						SendMessageUpwards("hurt",gameObject.name);
					}
				}
				if(gateUse)
				{
					SendMessageUpwards("callGmGateHret");
				}
				Destroy(collision.gameObject);
			}
		}
	}

	void callGameStart()
	{
		gameStart=true;
	}
	void resetup()
	{
		gameStart = false;
	}
}
