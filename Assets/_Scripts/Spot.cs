using UnityEngine;
using System.Collections;

public class Spot : MonoBehaviour {

	private int lives = 4;
    SpriteRenderer renderer;
    public Game game;
	private int growing = 0;
    private int growingTime = 60;
    
    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0,0,0,0.9f);
	}
	
	// Update is called once per frame
	void Update () {
        if (growing > 0) {
            transform.localScale = transform.localScale * 1.020f;
            growing--;
        }
        
        if (growing == 1) {
            game.EndGame(); 
        }
	}
    
    void OnTriggerEnter2D (Collider2D obj) {
        if (obj.gameObject.name != "Bird") return;
        Debug.Log("Bird Collided");
        audio.Play();
        
        Destroy(rigidbody2D);
        lives--;
        renderer.sortingOrder = 4 - lives;
        
        switch(lives) {
        case 3:
            renderer.color = new Color(1,1,1,0.9f);
            transform.localScale = transform.localScale * 1.5f;
            break;
        case 2:
            transform.localScale = transform.localScale * 1.5f;
            break;
        case 1:
            transform.localScale = transform.localScale * 1.5f;
            break;
        case 0:
            transform.localScale = transform.localScale * 2f;
            break;
        case -1:
            stopGrow();
            break;
        }
    }
    
    public void stopGrow () {
        growing = growingTime;
        game.StopSpots();
        renderer.color = HexToColor("ffffff");
        Handheld.Vibrate();
        
        
    }
    
    public void Go () {
        rigidbody2D.AddForce (new Vector2 (0, Random.Range(-55,-155)));
        Vector2 v = transform.position;
        v.x = v.x + Random.Range(-3.0f, 3.0f);
        transform.position = v;
        
    }
    
    Color HexToColor(string hex) {
        byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r,g,b, 255);
    }
}
