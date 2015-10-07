using UnityEngine;
using System.Collections;

public class showNumber : MonoBehaviour {
	public bool show=true;
	public Texture2D[] numberPic;  //要使用的數字圖片類型  
	public float showX,showY, textureW, textureH;
	public bool useOrgTextureWH=true; //是否要使用原始圖片大小
	public int num;  //要顯示的數字
	
	void Start() 
	{ 
	} 
	
	void OnGUI() 
	{ 
		if(show)
		{
			drawNumberImage(showX,showY,num,numberPic);  //使用繪製數字串功能繪製圖片
		}
	} 

	void drawNumberImage(float x, float y ,int number,Texture2D[] texes) //XY座標為圖片左上方為原點
	{ 
		char[] chars = number.ToString().ToCharArray();  //將數字轉為文字型態後再利用.ToCharArray()分割字串同時轉換成char文字型態並紀錄在char文字型態的陣列中

		float width, height;  
		if(useOrgTextureWH)//由程式自動取得單張數字圖片高度與寬度
		{
			width = numberPic[0].width;  
			height =  numberPic[0].height;  
		}
		else 
		{
			width = textureW;  
			height =  textureH;  
		}

		foreach(char s in chars) //繪製所有字串陣列中的文字
		{ 
			int i = int.Parse(s.ToString());  //將每個文字轉換成整數型態
			GUI.DrawTexture(new Rect(x,0,width,height),texes[i]);  //利用每個陣列的整數型態對應繪製指定的數字圖
			x += width;  	//每繪製一張圖就將下一張圖繪製在目前這張圖的右邊
		} 
		
	} 
}