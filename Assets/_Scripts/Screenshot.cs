using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {

    public Game game;
    private Texture T2D;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(collider2D.OverlapPoint(mousePosition))
            {
				
				int width = Screen.width;
				int height = Screen.height;
				Texture2D Screenshot = new Texture2D( width, height, TextureFormat.RGB24, false );
				
				// Read screen contents into the texture
				Screenshot.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
				Screenshot.Apply();
				
				AndroidSocialGate.StartShareIntent(
					"Share your top score!", "OMG! I just got " + game.highScore + " on Keep The Fish Alive! @KeepFishAlive https://play.google.com/store/apps/details?id=com.storynatives.keepthefishalive", 
					Screenshot
				);
            }
        }
	}
}
