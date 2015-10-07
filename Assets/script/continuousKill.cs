using UnityEngine;
using System.Collections;

public class continuousKill : MonoBehaviour {
	public int nowContinuousKillCount, leastContinuousKillCount;
	public GUIText showContinuousKillCountGuitext;
	public bool gameStart=false;
	// Use this for initialization
	void Start () {
		showContinuousKillCountGuitext.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void callContinuousKill()
	{
		#region 累加連殺數
		nowContinuousKillCount++;
		#endregion 累加連殺數
		if(nowContinuousKillCount>leastContinuousKillCount)
		{
			print("達成最少連殺數量");
			showContinuousKillCountGuitext.enabled = true;
			showContinuousKillCountGuitext.text = nowContinuousKillCount.ToString() + "連續防禦";
			BroadcastMessage("OnLeastContinuousKill", nowContinuousKillCount);
		}
	}

	void callOnHuret()
	{
		#region 被攻擊連殺數歸零
		nowContinuousKillCount = 0;
		showContinuousKillCountGuitext.text = nowContinuousKillCount.ToString() + "連續防禦";
		showContinuousKillCountGuitext.enabled = false;
		#endregion 被攻擊連殺數歸零
	}

	void resetup()
	{
		nowContinuousKillCount = 0;
		showContinuousKillCountGuitext.text = nowContinuousKillCount.ToString() + "連續防禦";
		showContinuousKillCountGuitext.enabled = false;
	}
}
