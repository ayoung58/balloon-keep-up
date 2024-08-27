using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextPlayer1;
    public TextMeshProUGUI scoreTextPlayer2;
    public TextMeshProUGUI timeText;
    public GameObject gameOverScreen;
    public float gameTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (player == 1) {
            scoreTextPlayer1.text = "Player " + player + ": " + score;
        } else if (player == 2) {
            scoreTextPlayer2.text = "Player " + player + ": " + score;
        }
    }

    void updateTime() {
        gameTime -= Time.deltaTime;
        timeText.text = (Mathf.RoundToInt(gameTime)).ToString();
    }

    void gameOver() {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
