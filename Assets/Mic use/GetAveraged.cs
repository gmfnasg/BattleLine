using UnityEngine;
using System.Collections;

public class GetAveraged : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			audio.clip = Microphone.Start(null, true, 10, 44100);

			float[] data = new float[256];
			audio.GetOutputData(data,0);
			foreach(float s in data)
			{
				print( s.ToString());
			}
		}
	}
}
