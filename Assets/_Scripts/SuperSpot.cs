using UnityEngine;
using System.Collections;

public class SuperSpot : MonoBehaviour {
    
    SpriteRenderer renderer;
    public Game game;
    
    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = (new HSBColor(new Color(Random.Range(0.2f,0.8f), Random.Range(0.2f,0.8f), Random.Range(0.2f,0.8f)))).ToColor();
    }
    
    // Update is called once per frame
    void Update () {
        renderer.color = (new HSBColor(new Color(Random.Range(0.2f,0.8f), Random.Range(0.2f,0.8f), Random.Range(0.2f,0.8f)))).ToColor();
    }
    
    void OnTriggerEnter2D (Collider2D obj) {
        if (obj.gameObject.name != "Bird") return;
        audio.Play();
        
        Destroy(rigidbody2D);
    }
    
    Color HexToColor(string hex) {
        byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r,g,b, 255);
    }
    
    public void Go () {
        rigidbody2D.AddForce (new Vector2 (0, Random.Range(-25,-55)));
        Vector2 v = transform.position;
        v.x = v.x + Random.Range(-3.0f, 3.0f);
        transform.position = v;
        
    }
}
