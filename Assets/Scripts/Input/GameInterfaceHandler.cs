using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameInterfaceHandler : MonoBehaviour 
{
    Text scoreText, gameoverText;

    public Text _gameoverText
    { get { return gameoverText; } set { gameoverText = value; } }

    float score;
    public float _score
    {
        get { return score; }
        set { score = value; }
    }

    void Awake()
    {
        scoreText = transform.FindChild("Panel_Score/Text_Score").GetComponent<Text>();
        gameoverText = transform.FindChild("Game Over/Text_GameOver").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;  
    }

    public void RestartGame()
    {
        Application.LoadLevel("LevelFirst");
    }

}
