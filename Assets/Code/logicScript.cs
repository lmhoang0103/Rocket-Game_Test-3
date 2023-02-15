using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public SnakeController snake;

    private void Start()
    {
        snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeController>();
    }

    [ContextMenu("Increas Score")]
    public void addScore()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        if (playerScore == 10)
        {
            victory();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void victory()
    {
        victoryScreen.SetActive(true);
        snake.stopMoving();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}