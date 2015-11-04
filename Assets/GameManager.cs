using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGamePaused = false;

    public GameObject squid;
    public Text scoreText;
    public Text highscoreText;

    private int score = 0;
    private int highscore = 0;


    // Use this for initialization
    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = "HIGHSCORE " + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Application.Quit();
            else
                PauseGame();
        }

        UpdateScore();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (isGameOver)
                StartGame();
            if (isGamePaused)
                ResumeGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        if (score > highscore)
            PlayerPrefs.SetInt("HighScore", score);
        squid.GetComponent<SpriteRenderer>().color = Color.black;
        squid.transform.position = new Vector3(squid.transform.position.x, squid.transform.position.y + 0.2f, squid.transform.position.z);
        squid.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        squid.transform.rotation = Quaternion.Euler(0, 0, 90);
        squid.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //  Application.LoadLevel(Application.loadedLevel);
    }

    public void PauseGame()
    {
        isGamePaused = true;
        squid.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        squid.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void StartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void UpdateScore()
    {
        score = (int)Mathf.Clamp(squid.transform.position.y, score, 24242424);
        scoreText.text = "SCORE " + score;
    }
}
