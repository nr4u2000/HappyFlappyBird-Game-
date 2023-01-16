using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameStates { Playing, Point, GameOver, BeatLevel };
    public gameStates gameState = gameStates.Playing;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject restartButton;
    public GameObject gameOver;
    public AudioClip gameOverSFX;
    public AudioClip pointSFX;
    public AudioClip beatSFX;
    public AudioSource backgroundMusic;
    private int score;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        backgroundMusic.volume = 0.15f;
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        restartButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i=0; i<pipes.Length;i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        restartButton.SetActive(true);
        backgroundMusic.volume = 0f;

        AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);

        gameState = gameStates.GameOver;
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        gameState = gameStates.GameOver;

        if(score == 10||score == 20 || score == 30 || score == 40 || score == 50 || score == 60 || score == 70 || score == 80 || score == 90 || score == 100 ||
            score == 110 || score == 120 || score == 130 || score == 140 || score == 150 || score == 160 || score == 170 || score == 180 || score == 190 || score == 200 ||
            score == 210 || score == 220 || score == 230 || score == 240 || score == 250 || score == 260 || score == 270 || score == 280 || score == 290 || score == 300)
        {
            AudioSource.PlayClipAtPoint(beatSFX, gameObject.transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(pointSFX, gameObject.transform.position);
        }
    }

}
