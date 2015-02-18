using UnityEngine;
using System.Collections;

public class Share : MonoBehaviour {

    public Game game;
    public Texture2D texture;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(collider2D.OverlapPoint(mousePosition))
            {
                Debug.Log("Share");
				AndroidSocialGate.StartShareIntent("Share ", "Check out Keep The Fish Alive! https://play.google.com/store/apps/details?id=com.storynatives.keepthefishalive", texture);
            }
        }
	}
}
