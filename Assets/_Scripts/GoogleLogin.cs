﻿using UnityEngine;
using System.Collections;

public class GoogleLogin : MonoBehaviour {

    public Game game;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(collider2D.OverlapPoint(mousePosition))
            {
                Debug.Log("GoogleLogin");
                //Social.ShowAchievementsUI();
                Social.localUser.Authenticate((bool success) => {
                    Debug.Log("logged In");
                });
            }
        }
	}
}
