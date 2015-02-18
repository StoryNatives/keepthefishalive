using UnityEngine;
using System.Collections;

public class TutorialChange : MonoBehaviour {

	public GameObject HideMe;
	public GameObject ShowMe;
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
				Debug.Log("RETRYY");
				HideMe.SetActive(false);
				ShowMe.SetActive(true);
				try {
					foreach (Spot spot in game.spots) Destroy(spot.gameObject);
				} catch (MissingReferenceException e) {
					Debug.Log ("Got This");
				}
				game.spots = new ArrayList();
			}
        }
	}
}
