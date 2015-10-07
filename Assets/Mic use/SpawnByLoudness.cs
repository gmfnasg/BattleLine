using UnityEngine;
using System.Collections;

public class SpawnByLoudness : MonoBehaviour {
	
	public GameObject audioInputObject;
	public float threshold = 1.0f;
	public GameObject objectToSpawn;
	MicrophoneInput micIn; //宣告指定自己寫的腳本的變數名稱  但還沒不能用來抓取數值
	
	
	
	#region 顯示音量資訊
	public GUIText showAttackCount, showVoile;
	public int attackNumber;
	#endregion 顯示音量資訊
	
	void Start() {
		if (objectToSpawn == null)
			Debug.LogError("You need to set a prefab to Object To Spawn -parameter in the editor!");
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("AudioInputObject");

		print(" error  "+audioInputObject.name);
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput"); //指定取得指定物件的指定腳本MicrophoneInput裡的變數，該腳本的變數不用宣告為靜態(static)變數
	}
	
	void Update () {
		float l = micIn.loudness;
		
		showVoile.text = "目前音量" + micIn.loudness.ToString();
		
		if (l > threshold)
		{
			print("音量大於");
			attackNumber++;
			showAttackCount.text = "攻擊次數: " + attackNumber.ToString(); 
			//Vector3 scale = new Vector3(l,l,l);
			//GameObject newObject = (GameObject)Instantiate(objectToSpawn, this.transform.position, Quaternion.identity);
			//newObject.transform.localScale += scale;
		}
	}
}