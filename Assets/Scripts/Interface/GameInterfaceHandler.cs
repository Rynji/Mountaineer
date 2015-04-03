﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameInterfaceHandler : MonoBehaviour 
{
    Text scoreText, gameoverText, debugText;

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
        debugText = transform.FindChild("Panel_Debug/Text_Debug").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        debugText.text =
            "Obstacles Alive" + "\nLane 01: " + s_SpawnHandler._instance._laneObjectsAlive[0]
             + "\nLane 02: " + s_SpawnHandler._instance._laneObjectsAlive[1]
              + "\nLane 03: " + s_SpawnHandler._instance._laneObjectsAlive[2]
               + "\nLane 04: " + s_SpawnHandler._instance._laneObjectsAlive[3]
                + "\nLane 05: " + s_SpawnHandler._instance._laneObjectsAlive[4]
                 + "\nLane 06: " + s_SpawnHandler._instance._laneObjectsAlive[5]
                  + "\nLane 07: " + s_SpawnHandler._instance._laneObjectsAlive[6];
    }

    public void RestartGame()
    {
        Application.LoadLevel("LevelFirst");
    }

}
