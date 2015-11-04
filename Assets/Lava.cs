using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour
{
    public Transform squid;
    public float speed;
    //  public float heightOffset;	
    GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver || gameManager.isGamePaused) return;

        transform.position = transform.position + Vector3.up * speed * ((squid.position.y / 100) + 1) * Time.deltaTime;
    }
}
