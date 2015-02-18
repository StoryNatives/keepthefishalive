using UnityEngine;
using System.Collections;

public class Side : MonoBehaviour {
    
    public Game game;
    public GameObject otherSide;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
    }
    
    void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Bird") {
			Debug.Log("Birdy Hit Side");
            
            otherSide.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.9f);
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.9f);
            //game.RandomColor();
            
            game.AddPoint();
            audio.Play();
        }
    }
}