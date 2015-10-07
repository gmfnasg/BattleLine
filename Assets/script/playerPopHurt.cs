using UnityEngine;
using System.Collections;

public class playerPopHurt : MonoBehaviour {
	public int blood;
	public GameObject linePlayerPop;
	public GUIText guitextLife;
	missionSetup mSetup;
	public GameObject gm;
	// Use this for initialization
	void Start () {
		mSetup = (missionSetup) gm.GetComponent("missionSetup"); //指定取得指定物件的指定腳本missionSetup裡的變數，該腳本的變數不用宣告為靜態(static)變數
		blood = mSetup.initialPlayerHp;
		guitextLife.text = "Life:" +blood.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void hurt(string playerPopName)
	{
		print("get message void hurt, playerPopName=" + playerPopName.ToString() + ", blood=" + blood.ToString());

		if(playerPopName == linePlayerPop.name)
		{

			if(blood>1)
			{
				blood--;
				guitextLife.text = "Life:" +blood.ToString();
				print (playerPopName +"扣血, 血量目前"+blood.ToString());
			}
			else if(blood==1)
			{
				guitextLife.enabled = false;
				print (playerPopName +"死亡, 血量目前"+blood.ToString());
				BroadcastMessage("playerPopToDeath",playerPopName);
				SendMessageUpwards("soliderDeath",1);
				//Destroy(gameObject);
			}
			SendMessageUpwards("callGmOnHuret");
		}
	}

	void resetup()
	{
		blood = mSetup.initialPlayerHp;
		guitextLife.text = "Life:" +blood.ToString();
		guitextLife.enabled = true;
	}

}
