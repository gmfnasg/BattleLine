using UnityEngine;
using System.Collections;

public class shoMicDev : MonoBehaviour {
	//顯示有哪些麥克風裝置
	public bool onShow = false;
	public GUIText showDev;
	// Use this for initialization
	void Start () {
		/*foreach (string device in Microphone.devices) {
			print("Name: " + device);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if(!onShow)
		{
			print(" -  - - ↓  - --- - ↓- - - -  - -");
			string allDev="裝置有";
			int count=0;
			foreach (string device in Microphone.devices) {
				//print("Updat Name: " + device);
				allDev = allDev + "device name:" + device +", ";
				count++;
			}
			onShow = true;
			print(allDev);
			allDev = allDev + "count" + count;
			showDev.text = allDev;
			print(" -  - - ↑  - --- - ↑- - - -  - -");
		}
	}
}
