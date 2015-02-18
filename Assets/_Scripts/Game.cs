using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;

//using GoogleMobileAds.Api;

public class Game : MonoBehaviour {
    
    public Spot SpotTemplate;
    public SuperSpot SuperSpotTemplate;
    public GameObject bird;
    public GameObject HomeUI;
    public ArrayList spots = new ArrayList();
	private int genSpeed = 30, genCount = 30, points = 0;
	public Text pointsText;
	public Text highScoreText;
	public int highScore = 0;
	public bool gameActive = false;
    public GameObject rightSide, leftSide, background, splash;
    private int splashTime = 180;
    private bool started = false;
    public HSBColor HSB;
    public ArrayList sprites = new ArrayList();
    public ArrayList levelColors = new ArrayList();
//    public GoogleMobileAdsDemoScript GADS;
    private int gameCount = 1;
    public SpriteRenderer birdAliveSprite;
    public SpriteRenderer birdDeadSprite;
    public AudioSource audioSource;
    public Rigidbody2D splashRB;
	
	// Use this for initialization
    void Start () {
		
		GooglePlayManager.ActionSoreSubmited += OnScoreSubmited;
		GooglePlayConnection.ActionConnectionResultReceived += ActionConnectionResultReceived;
		GooglePlusAPI.instance.clearDefaultAccount();
    
        levelColors = new ArrayList();
        levelColors.Add(new Color32(117, 214, 0, 255));
        levelColors.Add(new Color32(146, 14, 14, 255));
        levelColors.Add(new Color32(255, 170, 21, 255));
		levelColors.Add(new Color32(255, 13, 138, 255));
		levelColors.Add(new Color32(96, 0, 253, 255));
		levelColors.Add(new Color32(70, 70, 70, 255));
		levelColors.Add(new Color32(255, 100, 100, 255));
		AudioListener.volume = 1;
		
		//        PlayGamesPlatform.DebugLogEnabled = true;
//        PlayGamesPlatform.Activate();
        
		GooglePlayConnection.instance.connect ();
//		Social.localUser.Authenticate((bool success) => {
//            Debug.Log("logged In");
//        });
		
		highScore = Load.LoadInt("highScore");
	}
    
	
	// Update is called once per frame
	void Update () {
	
		//REAL START APPLICATION
		if (splashTime-- < 0 && !started) {
			//splash.SetActive(false);
			splashRB.gravityScale = -5;
			//splashTime--;
			started = true;
			audioSource.Play();
			points = 0;
			EndGame();
		}
        
        if (gameActive) {
            gameLogic();
        }
    }
    
    public void NewGame() {
        background.GetComponent<SpriteRenderer>().color = new Color32(21, 100, 255, 255);
        gameActive = true;
        bird.SetActive(true);
        bird.transform.position = new Vector2(0,0);
        
		HomeUI.SetActive(false);
        
        bird.rigidbody2D.AddForce (new Vector2 (150, 150));
        leftSide.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.9f);
        rightSide.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.9f);
        birdAliveSprite.enabled = true;
        birdDeadSprite.enabled = false;
        bird.transform.rotation = Quaternion.Euler(0,0,0);
        gameCount++;
        
        //RandomColor();
        try {
        	foreach (Spot spot in spots) Destroy(spot.gameObject);
        } catch (MissingReferenceException e) {
        	Debug.Log ("test");
        }
        spots = new ArrayList();
        sprites = new ArrayList();
        
        ResetPoints();
    }
    
    public void RandomColor() {
        HSB = new HSBColor(new Color(Random.Range(0.2f,0.8f), Random.Range(0.2f,0.8f), Random.Range(0.2f,0.8f)));
        background.GetComponent<SpriteRenderer>().color = HSB.ToColor();
    }
    
    public void StopSpots() {
        Debug.Log("StopSpots()");
        bird.rigidbody2D.angularVelocity = -2500;
        bird.rigidbody2D.velocity = new Vector2(bird.rigidbody2D.velocity.x / 2,10);
        birdAliveSprite.enabled = false;
        birdDeadSprite.enabled = true;
//        foreach (Spot spot in spots) {
//            if (spot.GetComponent<Rigidbody2D>() != null) {
//                spot.rigidbody2D.velocity = new Vector2(0,0);
//            }
//        }
    }
    
    public void EndGame() {
		if (highScore < points) {
			highScore = points;
		}
		
		highScoreText.text = highScore + "";
		Save.SaveInt("highScore", highScore);
		
		gameActive = false;
        
		HomeUI.SetActive(true);
        
        bird.SetActive(false);
        audio.Play();
        
        if (gameCount % 3 == 2) {
            Debug.Log ("RequestInterstitial");
//            GADS.RequestInterstitial();
        }
        
        if (gameCount % 3 == 0) {
            Debug.Log ("ShowInterstitial");
//            GADS.ShowInterstitial();
        }
        
		
		if (gameCount == 5) {
			string rateText = "If you enjoy playing Keep The Fish Alive, please take a moment to rate it. Thanks for your support!";
			
			//example link to your app on android market
			string rateUrl = "market://details?id=com.storynatives.keepthefishalive";
			
			AndroidRateUsPopUp rate = AndroidRateUsPopUp.Create("Rate Us", rateText, rateUrl);
		}
        
		GooglePlayManager.instance.SubmitScoreById ("CgkImYyu0YAREAIQAQ", points);
		GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQBg");
		
		if (points >= 5) {
			GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQAg");
        }
        
		if (points >= 10) {
			GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQAw");
        }
        
		if (points >= 20) {
			GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQBA");
        }
        
		if (points >= 30) {
			GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQBQ");
		}
		
		if (points >= 40) {
			GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQBw");
		}
		
		if (points >= 50) {
			GooglePlayManager.instance.UnlockAchievementById("CgkImYyu0YAREAIQCQ");
		}
        
		GooglePlayManager.instance.incrementAchievementById ("CgkImYyu0YAREAIQCg", points);
    }
    
    public void AddPoint () {
		Debug.Log ("Adding Point" + points);
        points++;
		
		Debug.Log ("Set Point" + points);
        pointsText.text = "" + points;
        if (points % 10 == 0) {
            Debug.Log(levelColors);
            Debug.Log(levelColors[0]);
            Debug.Log((points / 10) - 1);
            background.GetComponent<SpriteRenderer>().color = (Color32) levelColors[(points / 10) - 1];
        }
    }
    
    public void ResetPoints () {
        points = 0;
        pointsText.text = "0";
    }
    
    public void gameLogic () {
        if (genCount-- < 0) {
            genCount = genSpeed;
            Spot s = Instantiate(SpotTemplate) as Spot;
            spots.Add(s);
            s.Go();
            
            
            //SuperSpot su = Instantiate(SuperSpotTemplate) as SuperSpot;
            //spots.Add(s);
            //su.Go();
        }
    }
    
	private void OnScoreSubmited(GP_GamesResult result) {
		GooglePlayManager.ActionSoreSubmited -= OnScoreSubmited;
		
		string leaderboardId = result.leaderboardId;
		string msg = result.message;
		Debug.Log("Score Submit Result for leaderboard " + leaderboardId + " :" + msg);
	}
	
	private void ActionConnectionResultReceived(GooglePlayConnectionResult result) {
		if(result.IsSuccess) {
			Debug.Log("Connected!");
		} else {
			Debug.Log("Cnnection failed with code: " + result.code.ToString());
		}
	}
}
