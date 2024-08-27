using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using System;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextPlayer1;
    public TextMeshProUGUI scoreTextPlayer2;
    public TextMeshProUGUI timeText;
    public GameObject gameOverScreen;
    private bool player1ToHit = true;
    public float gameTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextPlayer1.text = scoreTextPlayer1.text + " <";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime > 0) {
            updateTime();
        } else {
            gameOver();
        }
    }

    public void updateScore(int player, int score) {
        // update the respective player's score
        if (player == 1) {
            scoreTextPlayer1.text = "Player " + player + ": " + score;
        } else if (player == 2) {
            scoreTextPlayer2.text = "Player " + player + ": " + score;
        }
    }

    public void updatePossession() {
        player1ToHit = !player1ToHit;
        // use > or < as arrows to indicate who needs to hit next.
        // every time the player hits the ball (contacts it), possession changes
        // thus, we only need to check who should have been hitting, and change to other player
        // when we add > or <, we need to also remove the other from the other player
        if (player1ToHit) {
            scoreTextPlayer1.text = scoreTextPlayer1.text + " <";
            scoreTextPlayer2.text = scoreTextPlayer2.text.Substring(2);
        } else {
            scoreTextPlayer2.text = "> " + scoreTextPlayer2.text;
            int length = scoreTextPlayer1.text.Length - 2;
            scoreTextPlayer1.text = scoreTextPlayer1.text.Substring(0, length);
        }
    }

    void updateTime() {
        gameTime -= Time.deltaTime;
        timeText.text = (Mathf.RoundToInt(gameTime)).ToString();
    }

    void gameOver() {
        // reveal the game over screen 
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
