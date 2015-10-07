using UnityEngine;
using System.Collections;

public class changColor : MonoBehaviour {

	Color[] elementColor;
	int nowColorID;

	public GameObject[] solider;

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		elementColor = new Color[3];
		elementColor[0]=Color.red;
		elementColor[1]=Color.yellow;
		elementColor[2]=Color.green;
		int rnd  =Random.Range(0,2);
		gameObject.renderer.material.color = elementColor[rnd];
		nowColorID = rnd;

		for(int i=0;i<3;i++)
		{
			if(i != nowColorID)
			{
				solider[i].SetActive(false);
			}
			if(i == nowColorID)
			{
				solider[i].SetActive(true);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray , out hit , 1000))
			{
				print(hit.collider.name);
				if(hit.collider.name == gameObject.name)
				{
					print("click player ball");
					if(nowColorID<2)
					{
						nowColorID++;
					}
					else if(nowColorID==2)
					{
						nowColorID=0;
					}

					for(int i=0;i<3;i++)
					{
						if(i != nowColorID)
						{
							solider[i].SetActive(false);
						}
						if(i ==nowColorID)
						{
							solider[i].SetActive(true);
						}
					}
					gameObject.renderer.material.color = elementColor[nowColorID];
				}
			}
		}
	}


	void resetup()
	{
		int rnd  =Random.Range(0,2);
		gameObject.renderer.material.color = elementColor[rnd];
		nowColorID = rnd;
		
		for(int i=0;i<3;i++)
		{
			if(i != nowColorID)
			{
				solider[i].SetActive(false);
			}
			if(i == nowColorID)
			{
				solider[i].SetActive(true);
			}
		}
	}
}
