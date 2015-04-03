using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour 
{
    Animator gameCanvasAnim;
    GameInterfaceHandler gameCanvas;
    BoxCollider playerCollider;
    Camera cam;
    Plane[] planes;

    void Awake()
    {
        gameCanvas = GameObject.Find("GameCanvas").GetComponent<GameInterfaceHandler>();
        gameCanvasAnim = GameObject.Find("GameCanvas").GetComponent<Animator>();
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        playerCollider = this.GetComponent<BoxCollider>();

        gameCanvas._score = 0f;
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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        this.gameObject.SetActive(false);
        gameCanvasAnim.SetTrigger("GameOver");
        gameCanvas._gameoverText.text = "Game Over!\nScore: " + gameCanvas._score; 
    }
}
