using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour 
{
    Animator gameCanvasAnim;
    GameInterfaceHandler gameCanvas;
    BoxCollider playerCollider;
    Camera cam;
    Plane[] planes;

    float stamina;
    public float _stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public int score = 0;
    public float highScore = 0;
    string highScoreKey = "HighScore";

    void Awake()
    {
        gameCanvas = GameObject.Find("GameCanvas").GetComponent<GameInterfaceHandler>();
        gameCanvasAnim = GameObject.Find("GameCanvas").GetComponent<Animator>();
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        playerCollider = this.GetComponent<BoxCollider>();

        gameCanvas._score = 0f;

        stamina = 12.5f;
    }

    void Start()
    {
        //Get the highScore from player prefs if it is there, 0 otherwise.
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
    }

    void Update()
    {
        //If player falls ofscreen:
        if (!GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds))
            GameOver();
    }

    void FixedUpdate()
    {
        gameCanvas._score++;

        stamina -= 0.015f;

        if (stamina < 0)
            GameOver();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            GameOver();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "BasicFood")
        {
            this.stamina += 10;
            Destroy(collider.gameObject);
        }
    }

    void GameOver()
    {
        this.gameObject.SetActive(false);

        //If our score is greater than the highscore, set new highscore and save.
        if (gameCanvas._score > highScore)
        {
            PlayerPrefs.SetFloat(highScoreKey, gameCanvas._score);
            PlayerPrefs.Save();
        }

        gameCanvasAnim.SetTrigger("GameOver");
        gameCanvas._gameoverText.text = "Game Over!\nScore: " + gameCanvas._score;

        gameCanvas._highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat(highScoreKey, 0);
    }

}
