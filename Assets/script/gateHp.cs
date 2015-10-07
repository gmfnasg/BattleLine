using UnityEngine;
using System.Collections;

public class gateHp : MonoBehaviour {
	public int gateNowHp, gateHurtRang, repairRang;
	public GUIText showGateHpGuitext;
	public string showGateHpString="城門損耗度:";
	missionSetup mSetup;
	public GameObject gm;
	// Use this for initialization
	void Start () {
		mSetup = (missionSetup) gm.GetComponent("missionSetup"); //指定取得指定物件的指定腳本missionSetup裡的變數，該腳本的變數不用宣告為靜態(static)變數
		gateNowHp = mSetup.initialGateHp;
		showGateHpGuitext.text = showGateHpString+gateNowHp.ToString()+"/"+mSetup.initialGateHp.ToString();
		repairRang = mSetup.repairGateRang;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void callGateHret()
	{
		print("@ get message void callGateHret");
		if(gateNowHp - gateHurtRang > 0)
		{
			print("城門受損");
			gateNowHp = gateNowHp - gateHurtRang;
			showGateHpGuitext.text = showGateHpString+gateNowHp.ToString()+"/"+mSetup.initialGateHp.ToString();
		}
		else if (gateNowHp - gateHurtRang <= 0)
		{
			SendMessageUpwards("geatDeath");
			showGateHpGuitext.text ="0/"+mSetup.initialGateHp.ToString();
			gameObject.renderer.enabled = false;
		}
	}

	void OnLeastContinuousKill(int nowContinuousKill)
	{
		//print("get messmage OnLeastContinuousKill");
		if(mSetup.useRepairGate)
		{
			if(gateNowHp+repairRang<=mSetup.initialGateHp)
			{
				print("修復城門");
				gateNowHp = gateNowHp+repairRang;
				showGateHpGuitext.text = showGateHpString+gateNowHp.ToString()+"/"+mSetup.initialGateHp.ToString();
			}
			else if(gateNowHp+repairRang>mSetup.initialGateHp)
			{
				print("修復城門");
				gateNowHp = mSetup.initialGateHp;
				showGateHpGuitext.text = showGateHpString+gateNowHp.ToString()+"/"+mSetup.initialGateHp.ToString();
			}
		}
	}

	void resetup()
	{
		gameObject.renderer.enabled = true;
		gateNowHp = mSetup.initialGateHp;
		showGateHpGuitext.text = showGateHpString+gateNowHp.ToString()+"/"+mSetup.initialGateHp.ToString();
	}
}
