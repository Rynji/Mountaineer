using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenHandler : MonoBehaviour
{
    Text highscoreText;
    string highScoreKey = "HighScore";
    float highScore;

	// Use this for initialization
	void Start () 
    {
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
        highscoreText = transform.FindChild("Background/Text_Highscore").GetComponent<Text>();
        highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat(highScoreKey, 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("LevelFirst");
    }
}
