using UnityEngine;
using System.Collections;

public class scoreGuitext : MonoBehaviour {
	public int score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(protypeGM.showScoresGuitext)
		{
			guiText.enabled = true;
		}
		else
		{
			guiText.enabled = false;
		}
	}

	void guitextAddScore()
	{
		score++;
		guiText.text = "Score: " + score.ToString();
	}

	void resetup()
	{
		score = 0;
		guiText.text = "Score: " + score.ToString();
	}

}
