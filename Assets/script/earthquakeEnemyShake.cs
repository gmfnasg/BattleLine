using UnityEngine;
using System.Collections;

public class earthquakeEnemyShake : MonoBehaviour {
	public float shakeTime,shakeOldTime;
	public bool wakeUp=true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!wakeUp && Time.time < shakeOldTime+shakeTime)
		{
			print("sleep");
			gameObject.rigidbody.velocity = Vector3.zero;
		}
		else if(!wakeUp && Time.time > shakeOldTime+shakeTime)
		{
			wakeUp = true;
		}

	}

	void onShake()
	{
		print ("get message void onShake()");
		wakeUp=false;
		shakeOldTime = Time.time;
		SendMessageUpwards("callGmEnemyOnSleepCreatEenmeyLater", shakeTime+Time.time);
	}
}
