using UnityEngine;
using System.Collections;

public class micTest : MonoBehaviour {
	public AudioSource myRec, myMusicAS;
	public AudioClip myMusicAC;

	// Use this for initialization
	void Start() {
		foreach (string device in Microphone.devices) {
			print("Name: " + device);
		}
		//audio.clip = Microphone.Start("Built-in Microphone", true, 20, 44100);
		//myRec.clip = Microphone.Start("Built-in Microphone", true, 3, 44100);
	}
		
		// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow) && !Microphone.IsRecording(""))
		{
			print("@  開始錄音");
			myRec.clip = Microphone.Start("Built-in Microphone", true, 99, 44100);
		}

		if(Microphone.IsRecording(""))
		{
			print("錄音中....");
		}

		if(Input.GetKeyDown(KeyCode.DownArrow) && Microphone.IsRecording(""))
		{
			print("@ 停止錄音");
			Microphone.End("");
		}
		
		if(Input.GetKeyDown(KeyCode.RightArrow) && !Microphone.IsRecording(""))
		{
			print("播放");
			myRec.Play();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) && !Microphone.IsRecording(""))
		{
			print("停止放");
			myRec.Stop();
		}

		if(Input.GetKeyDown(KeyCode.F1) && !Microphone.IsRecording(""))
		{
			print("錄製到MP3");
			myMusicAS = myRec;
		}


		if(Input.GetKeyDown(KeyCode.P))
		{
			myMusicAS.PlayOneShot(myMusicAC, 0.7F);
			//myMusicAS.Play();
		}
		if(Input.GetKeyDown(KeyCode.O))
		{
			myMusicAS.Stop();
		}
		int max=0,min=0;
		Microphone.GetDeviceCaps("",out min, out max);
		print("error Microphone.GetDeviceCaps  min" + min.ToString() + ", max" +max.ToString() );

		
	}
	
	/*void doublecalculateVolume(short[] buffer)
	{
		double sumVolume = 0.0;
		double avgVolume = 0.0;
		double volume = 0.0;
		for(int i = 0; i < buffer.Length;i+=2)
		{
			sumVolume += Mathf.Abs(buffer[i] );
		}
		avgVolume = sumVolume / buffer.Length;
		volume = Mathf.Log10(1 + (float)avgVolume) * 10;
		return volume;
	}*/
}
