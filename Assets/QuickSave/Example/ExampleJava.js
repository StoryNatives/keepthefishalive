#pragma strict

private var stringToEdit : String = "";
public var Texture2D1 : Texture2D;
public var Texture2D2 : Texture2D;
public var Texture2D3 : Texture2D;
private var DrawTexture : Texture2D;

function Start()
{
	DrawTexture = Texture2D3;
}

function OnGUI()
{
	//String
	GUI.Box(Rect(220,10,200,200),"JavaScript - String");
	if (GUI.Button(Rect(230, 40, 180, 30), "Save"))
	{
		Save.SaveString("JavaString",stringToEdit);
	}
	if (GUI.Button(Rect(230, 80, 180, 30), "Load"))
	{
		stringToEdit = Load.LoadString("JavaString");
	}
	if (GUI.Button(Rect(230, 120, 180, 30), "Clear"))
	{
		stringToEdit = "";
	}
	stringToEdit = GUI.TextField (Rect (230, 170, 180, 20), stringToEdit, 25);
	
	//Texture2D
	GUI.Box(Rect(220, 220, 200, 220), "JavaScript - SaveTexture2D");
	GUI.DrawTexture(Rect(230,250,50,50),Texture2D1);
	if(GUI.Button(Rect(300,260,110,25),"Use Texture2D"))
	{
		DrawTexture = Texture2D1;
	}
	
	GUI.DrawTexture(Rect(230,310,50,50),Texture2D2);
	if(GUI.Button(Rect(300,320,110,25),"Use Texture2D"))
	{
		DrawTexture = Texture2D2;
	}
	
	GUI.DrawTexture(Rect(230,370,50,50),DrawTexture);
	if(GUI.Button(Rect(300,370,50,25),"Save"))
	{
		Save.SaveTexture2D("C#Texture2D",DrawTexture);
	}
	if(GUI.Button(Rect(360,370,50,25),"Load"))
	{
		DrawTexture = Load.LoadTexture2D("C#Texture2D");
	}
	if(GUI.Button(Rect(300,400,110,25),"Clear"))
	{
		DrawTexture = Texture2D3;
	}
}