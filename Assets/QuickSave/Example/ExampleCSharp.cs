using UnityEngine;
using System.Collections;

public class ExampleCSharp : MonoBehaviour
{
	private string stringToEdit = "";
	public Texture2D Texture2D1;
	public Texture2D Texture2D2;
	public Texture2D Texture2D3;
	private Texture2D DrawTexture;
	
	void Start()
	{
		DrawTexture = Texture2D3;
	}
	
	void OnGUI()
	{
		//String
		GUI.Box(new Rect(10, 10, 200, 200), "C# - String");
		if (GUI.Button(new Rect(20, 40, 180, 30), "Save"))
		{
            Save.SaveString("C#String",stringToEdit);
		}
		if (GUI.Button(new Rect(20, 80, 180, 30), "Load"))
		{
            stringToEdit = Load.LoadString("C#String");
		}
		if (GUI.Button(new Rect(20, 120, 180, 30), "Clear"))
		{
            stringToEdit = "";
		}
		stringToEdit = GUI.TextField(new Rect(20, 170, 180, 20), stringToEdit, 25);
		
		
		//Texture2D
		GUI.Box(new Rect(10, 220, 200, 220), "C# - SaveTexture2D");
		GUI.DrawTexture(new Rect(20,250,50,50),Texture2D1);
		if(GUI.Button(new Rect(85,260,110,25),"Use Texture2D"))
		{
			DrawTexture = Texture2D1;
		}
		
		GUI.DrawTexture(new Rect(20,310,50,50),Texture2D2);
		if(GUI.Button(new Rect(85,320,110,25),"Use Texture2D"))
		{
			DrawTexture = Texture2D2;
		}
		
		GUI.DrawTexture(new Rect(20,370,50,50),DrawTexture);
		if(GUI.Button(new Rect(85,370,50,25),"Save"))
		{
			Save.SaveTexture2D("C#Texture2D",DrawTexture);
		}
		if(GUI.Button(new Rect(145,370,50,25),"Load"))
		{
			DrawTexture = Load.LoadTexture2D("C#Texture2D");
		}
		if(GUI.Button(new Rect(85,400,110,25),"Clear"))
		{
			DrawTexture = Texture2D3;
		}
	}
}
