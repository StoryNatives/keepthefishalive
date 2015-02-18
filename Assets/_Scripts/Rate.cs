using UnityEngine;
using System.Collections;

public class Rate : MonoBehaviour {

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
                Debug.Log("Rate");
				string rateText = "If you enjoy playing Keep The Fish Alive, please take a moment to rate it. Thanks for your support!";
				
				//example link to your app on android market
				string rateUrl = "market://details?id=com.storynatives.keepthefishalive";
				
				AndroidRateUsPopUp rate = AndroidRateUsPopUp.Create("Rate Us", rateText, rateUrl);
            }
        }
	}
	
	private void onRatePopUpClose(AndroidDialogResult result) {
		switch(result) {
		case AndroidDialogResult.RATED:
			Debug.Log ("Rate button pressed");
			break;
		case AndroidDialogResult.REMIND:
			Debug.Log ("Remind button pressed");
			break;
		case AndroidDialogResult.DECLINED:
			Debug.Log ("Decline button pressed");
			break;
			
		}
		
		AndroidToast.ShowToastNotification(result.ToString() + " button pressed");
	}
}
