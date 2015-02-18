using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    float scale = 0.05f;
    public TrailRenderer tr;

	// Use this for initialization
	void Start () {
        tr.sortingLayerName = "l-0";
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Vector3 v = rigidbody2D.velocity;
			v.y = 5.0f;
			rigidbody2D.velocity = v;
            audio.Play();
		}

		if (rigidbody2D.velocity.x < 0) {
            Vector3 sc = transform.localScale;
            sc.x = -1.0f * scale;
            transform.localScale = sc;
        } else {
            Vector3 sc = transform.localScale;
            sc.x = scale;
            transform.localScale = sc;
        }
	
	}
}
