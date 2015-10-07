using UnityEngine;
using System.Collections;

public class creatEnemy : MonoBehaviour {
	public GameObject[] enemypopSphere; // 敵人功能球參考物件
	public GameObject[] enemyLineRefObj;//產生物件要掛在這個物件下面
	public float creatTime=10,SpeeUpTime=0.1f,minCreatInterval=2.5f;
	public float[] oldTime;
	float oldCreatTime;
    public int rndTimeMax,rndTimeMini;
	Vector3[] creatEnemyOrgPos;
	public int creatCount;

	float rndCreatTime=0;

	public GameObject[] soliderType;
	RndEnemySoliderColor resc;

	// Use this for initialization
	void Start () {
		creatEnemyOrgPos = new Vector3[enemyLineRefObj.Length];
		oldTime = new float[enemyLineRefObj.Length];

		for(int i = 0;i<enemyLineRefObj.Length;i++)
		{
			oldCreatTime= creatTime;

			oldTime[i] = oldTime[i] -creatTime;

			creatEnemyOrgPos[i] = enemypopSphere[i].transform.position;

			enemypopSphere[i].transform.position = new Vector3(100,100,-100);
			enemypopSphere[i].renderer.enabled = false;
			enemypopSphere[i].rigidbody.useGravity = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(protypeGM.startgame)
		{
			for(int i = 0;i<enemyLineRefObj.Length;i++)
			{
				rndCreatTime =( Random.Range(rndTimeMini,rndTimeMax)) ;
				rndCreatTime = rndCreatTime/10;
				//print("rndCreatTime"+ rndCreatTime.ToString());
				if( Time.time >oldTime[i]+creatTime )
				{
					oldTime[i] = Time.time +rndCreatTime;
					if(creatTime - SpeeUpTime>=minCreatInterval)//檢查生產敵人會不會過快
					{
						creatTime = creatTime - SpeeUpTime;
					}
					//print("時間 間隔到");
					GameObject newEnemy = GameObject.Instantiate(enemypopSphere[i],creatEnemyOrgPos[i],Quaternion.identity) as GameObject;
					newEnemy.tag = "enemyClone";
					creatCount++;
					newEnemy.name = newEnemy.name + "@" + gameObject.name + "number:" + creatCount.ToString();
					newEnemy.transform.parent = enemyLineRefObj[i].transform;
					//newEnemy.renderer.enabled = true;
					newEnemy.rigidbody.useGravity = true;
					newEnemy.AddComponent("RndEnemySoliderColor");

					resc = (RndEnemySoliderColor) newEnemy.GetComponent("RndEnemySoliderColor");
					resc.soliderType = soliderType;
					resc.creat = false;
				}
			}
		}
		/*#region 手動生產士兵
		if(Input.GetKeyDown(KeyCode.F1))
		{
			GameObject newEnemy = GameObject.Instantiate(enemypopSphere,creatEnemyOrgPos,Quaternion.identity) as GameObject;
			newEnemy.tag = "enemyClone";
			newEnemy.transform.parent = gameObject.transform;
			//newEnemy.renderer.enabled = true;
			newEnemy.rigidbody.useGravity = true;
		}
		#endregion 手動生產士兵*/
	}

	void resetup()
	{
		creatTime =oldCreatTime;
		for(int i = 0;i<enemyLineRefObj.Length;i++)
		{
			oldTime[i] = Time.time - creatTime;
		}
		creatCount = 0;
	}
	void callEnemyOnSleepCreatEenmeyLater(float sleepTime)
	{
		rndCreatTime =( Random.Range(rndTimeMini,rndTimeMax)) ;
		rndCreatTime = rndCreatTime/10;
		for(int i = 0;i<enemyLineRefObj.Length;i++)
		{
			oldTime[i]=sleepTime + rndCreatTime;
		}
	}
}
