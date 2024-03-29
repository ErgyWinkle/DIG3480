﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hardModeText;

    private bool gameOver;
    private bool restart;
    private int score;
    private BGScroller background;

    void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        winText.text = "";
        hardModeText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        GameObject backgroundObject = GameObject.FindWithTag("Background");
        {
            if (backgroundObject != null)
            {
                background = backgroundObject.GetComponent<BGScroller>();
            }
            if (backgroundObject == null)
            {
                Debug.Log("Cannot find 'BGScroller' Script");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Space Shooter HM");
            }
        

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Space Shooter");
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'E' for restart on normal mode";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 200)
        {
            winText.text = "You win! Game created by Ethan Wood";
            gameOver = true;
            restart = true;
            hardModeText.text = "Press 't' for Hard Mode";
            background.scrollSpeed = -2;
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over! Game made by Ethan Wood";
        gameOver = true;
    }
}
