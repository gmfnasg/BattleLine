using UnityEngine;
using System.Collections;

public class RndEnemySoliderColor : MonoBehaviour {
	Color[] elementColor;
	public GameObject[] soliderType;
	public int rndSoliderId;
	public bool creat= false;
	// Use this for initialization
	void Start () {

		if(!creat)
		{
			creat = true;
			
			elementColor = new Color[3];
			elementColor[0]=Color.red;
			elementColor[1]=Color.yellow;
			elementColor[2]=Color.green;
			rndSoliderId = Random.Range(0,3);
			
			gameObject.renderer.material.color = elementColor[rndSoliderId];
			//print(soliderType.Length.ToString());
			GameObject newEnemy= GameObject.Instantiate(soliderType[rndSoliderId],  gameObject.transform.position,  soliderType[rndSoliderId].transform.rotation) as GameObject;
			newEnemy.name = newEnemy.name+"[newEnemy2]";
			newEnemy.transform.parent = gameObject.transform;

			print("隨機決定顏色 並複製對應兵種");
		}
		


	}
	
	// Update is called once per frame
	void Update () {

	}
	
	
}
