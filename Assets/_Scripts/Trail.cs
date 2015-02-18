using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {
    public TrailRenderer tr;

	// Use this for initialization
    void Start () {
        tr.sortingLayerName = "l-0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
