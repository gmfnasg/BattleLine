using UnityEngine;
using System.Collections;
public class shakePhpne : MonoBehaviour {
	public float oldY, newY, differenceY; //舊Y座標, 新Y座標, 新舊Y座標差距
	public float differenceMax=2;
	public GUIText showShakePhoneStaticGuitext;
	public int shakeCount;
	missionSetup mSetup;

	// Use this for initialization
	void Start () {
		mSetup = (missionSetup) gameObject.GetComponent("missionSetup"); //指定取得指定物件的指定腳本missionSetup裡的變數，該腳本的變數不用宣告為靜態(static)變數
		if(!mSetup.useShakePhone)
		{
			showShakePhoneStaticGuitext.text = "不使用搖晃功能";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(mSetup.useShakePhone)
		{
			newY=Input.acceleration.y;    
			differenceY=newY-oldY;    
			oldY=newY; 
			if(differenceY>differenceMax)
			{    
				Handheld.Vibrate (); //手機震動
				shakeCount++;
				BroadcastMessage("onShake",differenceY);
				print ("[搖晃值:"+((int)differenceY).ToString() + "] [地震次數"+shakeCount.ToString()+"]");
			}    
			showShakePhoneStaticGuitext.text = "[搖晃值:"+((int)differenceY).ToString() + "] [地震次數"+shakeCount.ToString()+"]";
		}
	}
	
}
