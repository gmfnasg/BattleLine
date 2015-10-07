using UnityEngine;
using System.Collections;

public class protypeGM : MonoBehaviour {
	static public bool startgame=false;
	static public bool showScoresGuitext=false;
	public GUIText guitextGameOver,guitextGameOverInfomation;

	int playerHP;
	// Use this for initialization
	void Start () {
		startgame = false;
		showScoresGuitext=false;
		guitextGameOver.enabled = false;
		guitextGameOverInfomation.enabled = false;
		playerHP=3;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Escape))
		{
			BroadcastMessage("resetup",1);
		}
	}

	void callGmGameStart()
	{
		startgame = true;
		showScoresGuitext=true;
		BroadcastMessage("callGameStart");
	}
	void resetup()
	{
		startgame = false;
		showScoresGuitext=false;
		guitextGameOver.enabled = false;
		guitextGameOverInfomation.enabled = false;
		playerHP=3;
	}

	void soliderDeath()
	{
		if(playerHP>1)
		{
			playerHP--;
		}
		else if(playerHP==1)
		{
			startgame = false;
			guitextGameOver.enabled = true;
			guitextGameOverInfomation.enabled = true;

		}
	}

	void addScore()
	{
		BroadcastMessage("guitextAddScore",1);
	}

	void callGmEnemyOnSleepCreatEenmeyLater(float sleepTime)
	{
		BroadcastMessage("callEnemyOnSleepCreatEenmeyLater",sleepTime);
	}

	void callGmGateHret()
	{
		BroadcastMessage("callGateHret");
	}

	void geatDeath()
	{
		startgame = false;
		guitextGameOver.enabled = true;
		guitextGameOverInfomation.enabled = true;
	}

	void callGmContinuousKill()
	{
		SendMessage("callContinuousKill");
	}
	void callGmOnHuret()
	{
		SendMessage("callOnHuret");
	}
	
}
