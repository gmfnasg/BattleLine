using UnityEngine;
using System.Collections;

public class enemyPopRndSoliderType : MonoBehaviour {

	//  有問題不能用


	Color[] elementColor;
	public GameObject[] soliderType;
	public int rndSoliderId;
	// Use this for initialization
	void Start () {
		elementColor = new Color[3];
		elementColor[0]=Color.red;
		elementColor[1]=Color.yellow;
		elementColor[2]=Color.green;
		rndSoliderId = Random.Range(0,3);


		gameObject.renderer.material.color = elementColor[rndSoliderId];
		//print(soliderType.Length.ToString());
	    GameObject newEnemy= GameObject.Instantiate(soliderType[rndSoliderId],  gameObject.transform.position,  soliderType[rndSoliderId].transform.rotation) as GameObject;
		newEnemy.name = newEnemy.name+"[newEnemy]";
		newEnemy.transform.parent = gameObject.transform;
		print("隨機決定顏色 並複製對應兵種");

		/*#region 關閉不需要顯示的模型
		for(int i=0;i<3;i++)
		{
			if(i != rnd)
			{
				soliderType[i].SetActive(false);
			}
			if(i == rnd)
			{
				soliderType[i].SetActive(true);
			}
		}
		#endregion 關閉不需要顯示的模型*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

}
