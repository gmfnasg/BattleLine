using UnityEngine;
using System.Collections;

public class useSoundEnemySlowDown : MonoBehaviour {
	public GameObject audioInputObject;
	public float volumeThreshold = 1.0f; //音量門檻
	getMicrophoneInputVolume getMicVolume; //宣告指定自己寫的腳本的變數名稱  但還沒不能用來抓取數值
	
	public float slowDownSpeed;

	#region 顯示音量資訊
	//public GUIText showAttackCount, showVoile;
	public int attackNumber;
	#endregion 顯示音量資訊
	
	void Start() {
		getMicVolume = (getMicrophoneInputVolume) audioInputObject.GetComponent("getMicrophoneInputVolume"); //指定取得指定物件的指定腳本MicrophoneInput裡的變數，該腳本的變數不用宣告為靜態(static)變數
	}
	
	void Update () {
		float nowVolume = getMicVolume.volume ;
		
		//showVoile.text = "目前音量" + getMicVolume. volume.ToString();
		
		if (nowVolume > volumeThreshold) //音量大於門檻
		{
			print("音量大於" + volumeThreshold.ToString());
			gameObject.rigidbody.velocity = new Vector3(gameObject.rigidbody.velocity.x, gameObject.rigidbody.velocity.y + slowDownSpeed, gameObject.rigidbody.velocity.z);
			attackNumber++;
			//showAttackCount.text = "攻擊次數: " + attackNumber.ToString(); 
		}
	}
}