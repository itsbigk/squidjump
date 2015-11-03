using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform squid;
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
        UpdateScore();
    }

    public void GameOver()
    {
        if (score > highscore)
            PlayerPrefs.SetInt("HighScore", score);
		Application.LoadLevel(Application.loadedLevel);
    }

    void UpdateScore()
    {
        score = (int)Mathf.Clamp(squid.position.y, score, 24242424);
        scoreText.text = "SCORE " + score;
    }
}
