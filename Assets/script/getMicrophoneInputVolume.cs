﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))] // 用來承載錄音用
public class getMicrophoneInputVolume : MonoBehaviour {
	public float volumeScal= 100; //音訊放大倍數
	public float volume = 0; //用來記錄麥克風目前的音量volume

	public int volumeThreshold, overThresholdCount; //音量門檻, 超越門檻次數
	public GUIText showSoundStatic;

	missionSetup mSetup;
	
	void Start() {
		audio.clip = Microphone.Start(null, true, 10, 44100); //開始從麥克風錄音
		audio.loop = true; // Set the AudioClip to loop 用於不斷撥放錄製重複撥放從麥克風錄下的內容，這樣才能不斷抓取麥克風路的音訊內容
		audio.mute = true; // Mute the sound, we don't want the player to hear it 播放錄音內容但是不用給玩家聽到
		while (!(Microphone.GetPosition("Android audio input") > 0)){} // Wait until the recording has started
		audio.Play(); // Play the audio source!
		mSetup = (missionSetup) gameObject.GetComponent("missionSetup"); //指定取得指定物件的指定腳本missionSetup裡的變數，該腳本的變數不用宣告為靜態(static)變數
		if(!mSetup.useShakePhone)
		{
			showSoundStatic.text = "不使用麥克風功能";
		}
	}
	
	void Update(){
		volume = GetAveragedVolume() * volumeScal;  //使用自編的功能取得真實音訊內容並且放大結果數值

		if(mSetup.useShakePhone)
		{
			if(volume>volumeThreshold)
			{
				overThresholdCount++;
			}
			showSoundStatic.text = "[風力:"+((int)volume).ToString()+"] [阻擋次數:"+overThresholdCount.ToString()+"]";
		}
	}
	
	float GetAveragedVolume() //取得真實音量(但數值因為很精密所以很小)
	{ 
		float[] data = new float[256];
		float a = 0;
		audio.GetOutputData(data,0);//用DATA陣列取出音訊中目前正在撥放中音訊軌道0的單個音訊的資料(其中一個不是所有音訊內容)
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		
		#region 列出聲音資訊 看資訊用與功能無關
		if(Input.GetKeyDown(KeyCode.T))
		{
			int count=0;
			foreach(float s in data)
			{
				//print("s"+s.ToString());	
				count++;
			}
			print("count"+count.ToString());
			print("單個音訊中的所有256個數值平均總合a" + a.ToString() + ", 還原a/256=" + (a/256).ToString() + ",  (a/256)*100=" +  ( (a/256)*100  ).ToString()  );
		}
		
		#endregion 列出聲音資訊看資訊用與功能無關
		return a/256;
	}
}