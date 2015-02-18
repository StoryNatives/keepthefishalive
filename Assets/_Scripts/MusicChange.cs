using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicChange : MonoBehaviour {

    public Game game;
    private bool isMusicPlaying = true;
    public Text text;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(collider2D.OverlapPoint(mousePosition))
			{
				Debug.Log("Leaderboards");
            	isMusicPlaying = !isMusicPlaying;
            	
            	if (isMusicPlaying) {
					audioSource.Play();
					text.text = "";
				} else {
					audioSource.Stop();
					text.text = "";
            	}
            }
        }
	}
}
