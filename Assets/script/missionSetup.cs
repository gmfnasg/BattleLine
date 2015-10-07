using UnityEngine;
using System.Collections;

public class missionSetup : MonoBehaviour {
	public int enemyNumberMax, initialPlayerHp, initialGateHp, repairGateRang;
	public bool useMicphone = false, useShakePhone = false, useRepairGate=true;
	public bool limitlessGameMode=false, levelGameMode;
	public GUIText showKillEnemyNumber;
	public int nowKillNumber,nowLevel;



	// Use this for initialization
	void Start () {
		#region 檢查是否有多重模式啟動
		int modeNumber=0;
		if(limitlessGameMode){modeNumber++;}
		if(levelGameMode){modeNumber++;}
		if(modeNumber!=1)
		{
			print("   @ 模式設定錯誤，多重模式開啟 @ ");
		}
		#endregion 檢查是否有多重模式啟動
	
		#region 無限模式
		if(limitlessGameMode)
		{
			print("無限模式");
			showKillEnemyNumber.text = "防禦數:"+nowKillNumber.ToString();
		}
		#endregion 無限模式

		#region 關卡模式
		if(levelGameMode)
		{
			print("關卡模式");
			showKillEnemyNumber.text = "防禦數:"+nowKillNumber.ToString()+"/"+enemyNumberMax.ToString();
		}
		#endregion 關卡模式
	}
	
	// Update is called once per frame
	void Update () {

	}

	void callMissionSetupAddEnemy()
	{
		print("殺敵數增加");
		#region 無限模式
		if(levelGameMode)
		{
			nowKillNumber++;
			showKillEnemyNumber.text = "防禦數:"+nowKillNumber.ToString();
		}
		#endregion 關卡模式

		#region 關卡模式
		if(levelGameMode)
		{
			nowKillNumber++;
			if(nowKillNumber < enemyNumberMax-1)
			{
				showKillEnemyNumber.text = "防禦數:"+nowKillNumber.ToString()+"/"+enemyNumberMax.ToString();
			}
			else if(nowKillNumber >= enemyNumberMax-1)
			{
				nowKillNumber--;
				showKillEnemyNumber.text = "完美防禦:"+nowKillNumber.ToString()+"/"+enemyNumberMax.ToString();
			}

		}
		#endregion 關卡模式
	}
}
